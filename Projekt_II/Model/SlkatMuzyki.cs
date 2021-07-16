using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class SlkatMuzyki
    {
        public SlkatMuzyki()
        {
            Tplyties = new HashSet<Tplyty>();
        }

        public int KategoriaId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Tplyty> Tplyties { get; set; }
    }
}
