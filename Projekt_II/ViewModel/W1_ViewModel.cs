using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Test1.Model;

namespace Projekt_II
{
    class W1_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Tplyty> VM_Plyty { get; set; }
        public List<Twypozyczenium> VM_Wypozyczenium { get; set; }

        public List<Tklienci> VM_Klienci { get; set; }

        public List<SlKatNosnika> KatNosnika { get ;  set; }

        


    }
}
