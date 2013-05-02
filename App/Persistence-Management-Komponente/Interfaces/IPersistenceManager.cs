using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Persistence_Management_Komponente.Interfaces
{
    /// <summary>
    /// Die Typ-0 Schnittstelle zur Kapselung eines Persistenzframeworks.
    /// </summary>
    public interface IPersistenceManager
    {
        /// <summary>
        /// Liefert eine Instanz des Typs T.
        /// </summary>
        /// <typeparam name="T">Beliebiger Referenztyp für den Typ der zu lesenden Instanz.</typeparam>
        /// <typeparam name="I">Beliebiger Wertetyp für den Schlüsseltyp.</typeparam>
        /// <param name="id">Schlüsselwert, für den die Instanz gelesen werden soll.</param>
        /// <param name="shouldLock">Angabe, ob die Instanz in der Persistenz gesperrt werden soll.</param>
        /// <returns></returns>
        T GetById<T, I>(I id, bool shouldLock) where T : class;

        /// <summary>
        /// Liefert alle Instanzen eines gegebenen Typs zurück.
        /// </summary>
        /// <typeparam name="T">Beliebiger Referenztyp für den Typ der zu lesenden Instanzen.</typeparam>
        /// <returns></returns>
        IList<T> GetAll<T>() where T : class;

        /// <summary>
        /// Liefer eine Instanz der System.Linq.IQueryable-Schnittstelle mit dessen Hilfe Linq-Abfragen definiert werden können.
        /// </summary>
        /// <typeparam name="T">Referenztyp, für den eine Abfrage definiert werden soll.</typeparam>
        /// <returns></returns>
        IQueryable<T> LinqQuery<T>() where T : class;

        /// <summary>
        /// Führt eine Datenbank-Anweisung durch, welche in einer Konfiguration abgelegt ist.
        /// </summary>
        /// <param name="queryName">Name der Datenbank-Anweisung aus der Konfiguration.</param>
        /// <param name="queryParameters">Parameter für die Datenbank-Anweisung.</param>
        /// <pre>queryName != null && queryName.Length > 0</pre>
        /// <pre>queryParameters != null</pre>
        /// <returns></returns>
        IList ExecuteNamedQuery(string queryName, IDictionary<string, object> queryParameters);

        /// <summary>
        /// Speichert einen Referenztyp in der Persistenz.
        /// </summary>
        /// <typeparam name="T">Typ der zu speichernden Instanz.</typeparam>
        /// <param name="entity">Zu speichernde Instanz.</param>
        /// <returns>Die gespeicherte Instanz.</returns>
        T Save<T>(T entity) where T : class;

        /// <summary>
        /// Löscht eine gegebene Instanz aus der Persistenz.
        /// </summary>
        /// <typeparam name="T">Referenztyp der zu löschenden Instanz.</typeparam>
        /// <param name="entity">Die zu löschende Instanz.</param>
        void Delete<T>(T entity) where T : class;
    }
}
