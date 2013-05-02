using System;

namespace Persistence_Management_Komponente.Exceptions
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
