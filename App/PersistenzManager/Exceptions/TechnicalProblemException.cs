using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;


namespace PersistenzManager.Exceptions
{
    /// <summary>
    /// Kapselt ein technisches Problem.
    /// </summary>
    class TechnicalProblemException : Exception
    {
        public TechnicalProblemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TechnicalProblemException(Exception innerException)
            : base("A technical problem occurred.", innerException)
        {
        }
    }
}
