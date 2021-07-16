using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class Tklienci
    {
        public Tklienci()
        {
            Twypozyczenia = new HashSet<Twypozyczenium>();
        }

        public int KlientId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string AdrUlica { get; set; }
        public string AdrNr { get; set; }
        public string AdrKod { get; set; }
        public string AdrMsc { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime? DataUsuniecia { get; set; }

        public virtual ICollection<Twypozyczenium> Twypozyczenia { get; set; }

    }
}
