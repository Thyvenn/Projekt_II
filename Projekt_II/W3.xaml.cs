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
    // Usuwanie Rekordu
    public partial class W3 : Window
    {
        
        private W2_ViewModel w2_viewModel = new W2_ViewModel();
        private W1_ViewModel w1_viewModel = new W1_ViewModel();
        private Wypozyczalnia_PlytContext cnt2 = new Wypozyczalnia_PlytContext();

        // Retriwuję zaznaczony wiesz z Okna głównego i przypiszę go do formularza usuwania
        private Tplyty selecteditem;
        public bool ReTry;

        

        public W3(Tplyty selectPlyta)
        {
            selecteditem = selectPlyta;


            InitializeComponent();
            w2_viewModel.VM_Nosnik = cnt2.SlKatNosnikas.ToList();
            w2_viewModel.VM_Muzyka = cnt2.SlkatMuzykis.ToList();
            w2_viewModel.VM_Powod = cnt2.Slpowods.ToList();
            DataContext = w2_viewModel;



            rec_aut.Content = selecteditem.Autor;
            rec_tyt.Content = selecteditem.Tytul;
            rec_kat.Content = selecteditem.KategoriaId;
            rec_nos.Content = selecteditem.NosnikId;
            rec_ilo.Content = selecteditem.Ilosc;
            rec_dat.Content = selecteditem.DataWydania.Year;

            // zamiana ilosci płyt na format do combobox-a
            int x = selecteditem.Ilosc;
            int y = 0;
            List<int> VM_Ilosc = new List<int>();
            while (x > 0)
            {

                x--;
                y++;
                VM_Ilosc.Add(y);
            }
            w2_viewModel.VM_Ilosc = VM_Ilosc;


        }

        private void Btn_usun_Click(object sender, RoutedEventArgs e)
        {
            Tplyty usuwanaPlyta = cnt2.Tplyties.Find(selecteditem.PlytaId);

                
            if (usuwanaPlyta.Ilosc == w2_viewModel.Wybrana_Ilosc)
            {

             cnt2.Tplyties.Remove(usuwanaPlyta);
            }
            else
            {
             
                usuwanaPlyta.Ilosc = usuwanaPlyta.Ilosc - w2_viewModel.Wybrana_Ilosc;
              
            }

            w1_viewModel.VM_Plyty = new Wypozyczalnia_PlytContext().Tplyties.ToList();


            // Potwierdzenie usuwania
            MessageBoxResult res = MessageBox.Show("Czy potwiedasz usunięcie?", "Usuwanie", MessageBoxButton.YesNoCancel);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Usunięto rekod", "Usuwanie");
                    cnt2.SaveChanges();
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Usuwanie anulowane", "Anulowano");
                    ReTry = false;
                    break;

                case MessageBoxResult.Cancel:
                    ReTry = true;
                    break;
            }

            if (ReTry == false)
            {
            new MainWindow().Show();
            this.Close();

            }
        }
        public void Validation()
        {
            // Walidacja
            bool[] walidacja = new bool[2];


            walidacja[0] = w2_viewModel.Wybrana_Ilosc > 0 ? false : true;
            walidacja[1] = w2_viewModel.Wybrany_Powod == null ? true : false;


            if (walidacja.Contains(true))
            {
                Btn_usun.IsEnabled = false;
            }
            else
            {
                Btn_usun.IsEnabled = true;
            }

        }
        private void Cmbb_Ilosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Validation();
        }

        private void Cmbb_Powod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Validation();
        }
    }
}
