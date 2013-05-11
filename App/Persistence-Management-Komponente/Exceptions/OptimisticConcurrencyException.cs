using System;

namespace Persistenzmanager.Exceptions
{
    /// <summary>
    /// Repräsentiert einen Versionsfehler einer Entität.
    /// </summary>
    public class OptimisticConcurrencyException : Exception
    {
        private object entity;

        public OptimisticConcurrencyException(object entity)
        {
            this.entity = entity;
        }

        object Entity
        {
            get
            {
                return entity;
            }
        }
    }
}
