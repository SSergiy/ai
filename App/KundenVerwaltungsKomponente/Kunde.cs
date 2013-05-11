using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anwendungskern.NullTypenKomponente;
using FluentNHibernate.Mapping;

namespace Anwendungskern
{
    namespace KundenVerwaltungsKomponente
    {
        public class Kunde : IKunde
        {
            public virtual Int32 id { get; private set; }
            public virtual KundeNummerTyp nummer { get;  set; }
            public virtual String name { get; set; }
            public virtual AdresseTyp adresse { get; set; }
            //public virtual IList<Angebot> angebote { get; set; }

            /// <summary>
            /// Nullable Constructor für NHibernate
            /// </summary>
            public Kunde(){}

            public Kunde(KundeNummerTyp nummer, String name, AdresseTyp adresse)
            {
                this.nummer = nummer;
                this.name = name;
                this.adresse = adresse;
            }
        }
        public class KundeMap : ClassMap<Kunde>
        {
            public KundeMap()
            {
                Id(x => x.id);
                Component<KundeNummerTyp>(x => x.nummer, m => // hiermit mappen wir einen fachlichen Datentyp innerhalb einer Entität
                {
                    m.Map(x => x.nummer);
                }).Unique(); //Unique() eigentlich unnötig da der NummerTyp hochgezält wird

                Map(x => x.name);

                Component<AdresseTyp>(x => x.adresse, m => // hiermit mappen wir einen fachlichen Datentyp innerhalb einer Entität
                {
                    m.Map(x => x.strasse);
                    m.Map(x => x.hausnummer);
                    m.Map(x => x.postleitzahl);
                    m.Map(x => x.ort);
                    m.Map(x => x.land);
                });

            }
        }
    }
}