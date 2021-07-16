using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class Tplyty
    {
        public Tplyty()
        {
            TusunieciaPlyts = new HashSet<TusunieciaPlyt>();
            Twypozyczenia = new HashSet<Twypozyczenium>();
        }

        public int PlytaId { get; set; }
        public string Autor { get; set; }
        public string Tytul { get; set; }
        public DateTime DataWydania { get; set; }
        public int KategoriaId { get; set; }
        public int NosnikId { get; set; }
        public int Ilosc { get; set; }

        public virtual SlkatMuzyki Kategoria { get; set; }
        public virtual SlKatNosnika Nosnik { get; set; }
        public virtual ICollection<TusunieciaPlyt> TusunieciaPlyts { get; set; }
        public virtual ICollection<Twypozyczenium> Twypozyczenia { get; set; }
    }
}
