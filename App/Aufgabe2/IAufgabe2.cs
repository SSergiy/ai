using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aufgabe2
{
    interface IAufgabe2
    {
        // Erstellt ein neues Buch und Speichert es in der Persistenz
        Buch ErstelleBuch(String name);
        Buch ÄndereBuch(int id, String name);
        void LöscheBuch(int id);

        Kurs ErstelleKurs(String titel, IList<Buch>bücher );
        Kurs ÄndereKurs(int id, String titel, IList<Buch> bücher);
        void LöscheKurs(int id);

        Notenkonto ErstelleNotenkonto(double gesamtnote);
        Notenkonto ÄndereNotenkonto(int id, double gesamtnote);
        void LöscheNotenkonto(int id);

        Student ErstelleStudent(String name, IList<Kurs> kurse, Notenkonto notenkonto);
        Student ÄndereStudent(int id, String name, IList<Kurs> kurse, Notenkonto notenkonto);
        void LöscheStudent(int id);
    }
}
