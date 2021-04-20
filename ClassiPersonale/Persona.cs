using System;

namespace ClassiPersonale
{
    public class Persona
    {
        public string CodiceFiscale { get; private set; }
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string Tipologia { get; private set; }
        public string Qualifica { get; set; }
        public string Area { get; set; }

        public Persona(string cod, string n, string c, int tipo)
        {
            CodiceFiscale = cod;
            Nome = n;
            Cognome = c;
            if (tipo == 0)
                Tipologia = "Aziendale";
            if (tipo == 0)
                Tipologia = "SubFornitore";
            if (tipo == 0)
                Tipologia = "Fornitore";
            if (tipo == 0)
                Tipologia = "Consulente";
        }

        public string Descrizione()
        {
            return $"{CodiceFiscale}, {Nome} {Cognome}, {Tipologia}, {Qualifica}, {Area}.";
        }
    }
}
