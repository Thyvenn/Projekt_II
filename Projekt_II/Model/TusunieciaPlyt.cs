using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class TusunieciaPlyt
    {
        public int UsunieciaId { get; set; }
        public int PlytaId { get; set; }
        public DateTime DataUsuniecia { get; set; }
        public int IloscPlyt { get; set; }
        public int PowodId { get; set; }

        public virtual Tplyty Plyta { get; set; }
        public virtual Slpowod Powod { get; set; }
    }
}
