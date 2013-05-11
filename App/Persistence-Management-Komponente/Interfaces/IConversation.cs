using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistenzmanager.Interfaces
{
    public interface ITransactionControl
    {
        /// <summary>
        /// Setzt den Transaktionsstatus auf 'Rollback' und zeigt damit an, dass die aktuelle Konversation zurückgesetzt werden soll.
        /// </summary>
        void SetRollbackOnly();
    }

    /// <summary>
    /// Delegate für transaktional auszuführenden Code.
    /// </summary>
    /// <typeparam name="T">Rückgabetyp des Codestücks.</typeparam>
    /// <param name="status">Tansaktionsstatus, über den ein durchzuführender Rollback angezeigt werden kann.</param>
    /// <returns>Einen beliebiger Wert des Typs T.</returns>
    public delegate T TransactionalCode<T>(ITransactionControl status);

    public interface IConversationFactory
    {
        /// <summary>
        /// Startet eine neue Konversation.
        /// </summary>
        /// <returns></returns>
        IConversation NewConversation();
    }

    public interface IConversation : IDisposable
    {
        /// <summary>
        /// Führt das übergebene Codestück innerhalb einer eigenen Transaktion durch.
        /// </summary>
        /// <typeparam name="T">Typ des Rückgabeparameters.</typeparam>
        /// <param name="body">Der transaktional auszuführende Code. Parameter für den Delegate ist eine Datenstruktur des Typs ITransactionControl, mit
        /// dessen Hilfe ein Rollback angezeigt werden kann.</param>
        /// <returns></returns>
        T ExecuteTransactional<T>(TransactionalCode<T> body);

        /// <summary>
        /// Beendet die aktuelle Session.
        /// </summary>
        void End();

        /// <summary>
        /// Beendet die aktuelle Session und beginnt eine neue Session.
        /// </summary>
        void Reset();
    }
}
