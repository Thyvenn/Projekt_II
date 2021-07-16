using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class Slpowod
    {
        public Slpowod()
        {
            TusunieciaPlyts = new HashSet<TusunieciaPlyt>();
        }

        public int PowodId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<TusunieciaPlyt> TusunieciaPlyts { get; set; }
    }
}
