using System;

namespace Persistence_Management_Komponente.Exceptions
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
