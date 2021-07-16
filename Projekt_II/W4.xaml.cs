using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Test1.Model;

namespace Projekt_II
{
    // Wypożyczanie
    public partial class W4 : Window
    {

        private W1_ViewModel w1_viewModel = new W1_ViewModel();
        private Wypozyczalnia_PlytContext cnt4 = new Wypozyczalnia_PlytContext();
       
        // można wypożyczyć jak się zaznaczy który klient <-> która płyta 
        public bool[] chechSelect = new bool[2];
        public bool ReTry;

        public W4()
        {
            InitializeComponent();

            
            w1_viewModel.VM_Plyty = cnt4.Tplyties.ToList();
            w1_viewModel.VM_Klienci = cnt4.Tkliencis.ToList();
            w1_viewModel.VM_Wypozyczenium = cnt4.Twypozyczenia.ToList();
            DataContext = w1_viewModel;

           
        }

        // Walidacja
        private void Validate()
        {
            if (chechSelect.Contains(false) == false)
            {
                Btn_wyporzycz.IsEnabled = true;
            }

        }
        private void List_Klienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chechSelect[0] = true;
            Validate();
        }

        private void List_Plyty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chechSelect[1] = true;
            Validate();
        }
        private void Btn_wyporzycz_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult res = MessageBox.Show("Czy potwiedasz Wypożyczenie?", "Wypożyczanie", MessageBoxButton.YesNoCancel);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Wypożyczno płytę", "Wypożyczno");
                  
                   var z1 = (Tklienci)List_Klienci.SelectedItem;
                   var z2 = (Tplyty)List_Plyty.SelectedItem;
                   var z3 = w1_viewModel.VM_Wypozyczenium.Last();


                    var wypo1 = new Twypozyczenium()
                    {
                        KlientId = z1.KlientId,
                        PlytyId = z2.PlytaId,
                        DataWypozyczenia = DateTime.Now

                    };
                    cnt4.Twypozyczenia.Add(wypo1);
                    cnt4.SaveChanges();
                    w1_viewModel.VM_Wypozyczenium = new Wypozyczalnia_PlytContext().Twypozyczenia.ToList();
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Anulowanie wypożyczenia", "Anulowano");
                    ReTry = false;
                    break;

                case MessageBoxResult.Cancel:
                    ReTry = true;
                    break;
            }

            if (ReTry == false)
            {
                this.Close();

            }


        }


    }
}
