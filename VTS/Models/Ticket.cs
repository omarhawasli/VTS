namespace VTS.Models
{
    public class Ticket
    {
        private int id;
        private string vorname;
        private string nachname;
        private double preis;
        private int platz;
        private string reihe;
        private string land;


        public Ticket(int id, string vorname, string nachname, double preis, int platz, string reihe)
        {
            this.id = id;
            this.vorname = vorname;
            this.nachname = nachname;
            this.preis = preis;
            this.platz = platz;
            this.reihe = reihe;
        }

        public Ticket(string vorname, string nachname, double preis, int platz, string reihe,string land)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.preis = preis;
            this.platz = platz;
            this.reihe = reihe;
            this.land = land;

        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Vorname
        {
            get => vorname;
            set => vorname = value;
        }

        public string Nachname
        {
            get => nachname;
            set => nachname = value;
        }

        public double Preis
        {
            get => preis;
            set => preis = value;
        }

        public int Platz
        {
            get => platz;
            set => platz = value;
        }

        public string Reihe
        {
            get => reihe;
            set => reihe = value;
        }

        public string Land
        {
            get => land;
            set => land = value;
        }
    }
}