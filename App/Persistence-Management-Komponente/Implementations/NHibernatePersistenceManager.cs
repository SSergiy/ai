using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using Persistenzmanager.Exceptions;
using Persistenzmanager.Interfaces;

namespace Persistenzmanager.Implementations.NHibernateImplementation
{
    public sealed class NHibernatePersistenceManager : IPersistenceManager, IConversationFactory
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISessionFactory sessionFactory;

        public NHibernatePersistenceManager(Configuration configuration)
        {
            Contract.Requires(configuration != null, "NHibernatePersistenceManager must be configured.");
            try
            {
                configuration.Properties.Add("current_session_context_class", "NHibernate.Context.CallSessionContext");
                this.sessionFactory = configuration.BuildSessionFactory();

                log.Debug("NHibernatePersistenceManager has been successfully initialized.");
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        private ISession CurrentSession
        {
            get
            {
                try
                {
                    ISession currentSession = sessionFactory.GetCurrentSession();
                    return currentSession;
                }
                catch (HibernateException ex)
                {
                    throw new TechnicalProblemException("Error retrieving session. Perhaps a current session has not been provided.", ex);
                }
            }
        }

        #region IPersistenceManager Members

        public T GetById<T, I>(I id, bool shouldLock) where T : class
        {
            try
            {
                T entity;
                if (shouldLock)
                {
                    entity = CurrentSession.Load<T>(id, LockMode.Upgrade);
                }
                else
                {
                    entity = CurrentSession.Load<T>(id);
                }
                return entity;
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        public IQueryable<T> LinqQuery<T>() where T : class
        {
            try
            {
                return CurrentSession.Linq<T>();
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        public IList ExecuteNamedQuery(string queryName, IDictionary<string, object> queryParameters)
        {
            Contract.Assert(queryName != null);
            Contract.Assert(queryName.Length > 0);
            Contract.Assert(queryParameters != null);
            try
            {
                IQuery sqlQuery = CurrentSession.GetNamedQuery(queryName);
                foreach (string key in queryParameters.Keys)
                {
                    Contract.Assert(key != null, "A parameter name is needed.");
                    Contract.Assert(key.Length > 0, "A parameter name is needed.");
                    Contract.Assert(queryParameters[key] != null, "A parameter object is needed for key '" + key + "'.");

                    sqlQuery = sqlQuery.SetParameter(key, queryParameters[key]);
                }
                return sqlQuery.List();
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        public IList<T> GetAll<T>() where T : class
        {
            try
            {
                return CurrentSession.CreateCriteria<T>().List<T>();
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        public T Save<T>(T entity) where T : class
        {
            try
            {
                CurrentSession.SaveOrUpdate(entity);
                return entity;
            }
            catch (StaleObjectStateException)
            {
                throw new OptimisticConcurrencyException(entity);
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            try
            {
                CurrentSession.Delete(entity);
            }
            catch (StaleObjectStateException)
            {
                throw new OptimisticConcurrencyException(entity);
            }
            catch (HibernateException ex)
            {
                throw new TechnicalProblemException(ex);
            }
        }

        #endregion

        #region IConversationFactory Members

        public IConversation NewConversation()
        {
            return new NHibernateConversation(sessionFactory);
        }

        #endregion
    }

    public sealed class NHibernateConversation : IConversation
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISessionFactory sessionFactory;
        private ISession session;

        internal NHibernateConversation(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            this.session = null;

            Reset();
        }

        #region IConversation Members

        public void Reset()
        {
            if (this.session != null)
            {
                try
                {
                    End();
                }
                catch (Exception)
                {
                }
            }

            this.session = sessionFactory.OpenSession();
            Contract.Assert(this.session != null, "Unable to create a new session.");

            this.session.FlushMode = FlushMode.Commit;

            log.Debug("Session " + session.GetHashCode().ToString() + " opened.");
        }

        public void End()
        {
            this.session.Close();
            log.Debug("Session " + session.GetHashCode().ToString() + " closed.");
        }

        public T ExecuteTransactional<T>(TransactionalCode<T> body)
        {
            ITransaction transaction = null;
            try
            {
                transaction = session.BeginTransaction();
                NHibernateTransactionControl transactionControl = new NHibernateTransactionControl();

                log.Debug("About to execute transaction " + transaction.GetHashCode().ToString() + ".");
                log.Debug("Binding callcontext.");
                NHibernate.Context.CallSessionContext.Bind(session);

                log.Debug("Invoking transactional code.");
                T result = body.Invoke(transactionControl);

                if (transactionControl.RollbackOnly)
                {
                    log.Debug("Rolling back because of RollbackOnly was set to 'true'.");
                    transaction.Rollback();
                }
                else
                {
                    log.Debug("Committing.");
                    transaction.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                try
                {
                    log.Debug("Rolling back transaction " + transaction.GetHashCode().ToString() + " due do exception " + ex.ToString());
                    transaction.Rollback();
                }
                catch (Exception)
                {
                }
                throw ex;
            }
            finally
            {
                log.Debug("Unbinding callcontext.");
                NHibernate.Context.CallSessionContext.Unbind(this.session.SessionFactory);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            End();
        }

        #endregion
    }

    internal class NHibernateTransactionControl : ITransactionControl
    {
        private bool rollbackOnly = false;

        public NHibernateTransactionControl()
        {
        }

        #region ITransactionStatus Members

        public bool RollbackOnly
        {
            get
            {
                return rollbackOnly;
            }
        }

        public void SetRollbackOnly()
        {
            rollbackOnly = true;
        }

        #endregion
    }
}
