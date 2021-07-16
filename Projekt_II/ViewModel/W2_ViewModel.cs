using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Test1.Model;

namespace Projekt_II
{
    class W2_ViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Tplyty> VM_Plyty { get; set; }
        public List<SlKatNosnika> VM_Nosnik { get; set; }
        public List<SlkatMuzyki> VM_Muzyka { get; set; }
        public List<Slpowod> VM_Powod { get; set; }
        public List<int> VM_Ilosc { get; set; }


        // Combox
        public SlKatNosnika Wybrany_Nosnik { get; set; }
        public SlkatMuzyki Wybrana_Muzyka { get; set; }
        public Slpowod Wybrany_Powod { get; set; }
        public int Wybrana_Ilosc { get; set; }


        // Texbox
        public string txt_autor { get; set; }
        public string txt_tytul { get; set; }
        public DateTime data_wydania { get; set; }
        public int int_ilosc { get; set; }


    }
}
