using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
namespace Anwendungskern
{
    namespace NullTypenKomponente
    {
        public interface ILieferant
        {
            int Id { get; }
            string Name { get; }
            AdresseTyp Adresse { get; }
            KontoverbindungTyp Kontoverbindung { get; }
            IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; }
            IList<IBestellung> Bestellung { get; }
        }

        public interface IProdukt
        {
            int Id { get; }
            string Name { get; }
            int Lagerbestand { get; }
            IOrderbuch Orderbuch { get; }
            IList<IEinkaufsinfosatz> Einkaufsinfosatz { get; }
            IList<IWarenausgansmeldung> Warenausgansmeldung { get; }
        }

        public interface IWarenausgansmeldung
        {
            int Id { get; }
            DateTime Datum { get; }
            int Menge { get; }
        }
        public interface IEinkaufsinfosatz
        {
            int Id { get; }
            DateTime GültigAb { get; }
            DateTime GültigBis { get; }
            double Planlieferzeit { get; }
            int Normalmenge { get; }
            double Preis { get; }
        }

        public interface IBestellung
        {
            int Id { get; }
            DateTime Bestelldatum { get; }
            int Menge { get; }
            bool Freigabe { get; }
            IWareneingangsmeldung Wareneingangsmeldung { get; }
        }

        public interface IWareneingangsmeldung
        {
            int Id { get; }
            DateTime Datum { get; }
            LieferscheinTyp Lieferschein { get; }
        }

        public interface IOrderbuchsatz
        {
            int Id { get; }
            DateTime GültigAb { get; }
            DateTime GültigBis { get; }
        }

        public interface IOrderbuch
        {
            int Id { get; }
            IList<IOrderbuchsatz> Orderbuchsatz { get; }
        }
    }
}