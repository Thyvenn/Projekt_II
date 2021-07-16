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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Test1.Model;

namespace Projekt_II
{

    public partial class MainWindow : Window
    {


        private W1_ViewModel w1_viewModel = new W1_ViewModel();
        private Wypozyczalnia_PlytContext cnt1 = new Wypozyczalnia_PlytContext();

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = w1_viewModel;
            w1_viewModel.VM_Plyty = cnt1.Tplyties.ToList();
            w1_viewModel.VM_Wypozyczenium = cnt1.Twypozyczenia.ToList();
           
            // Przypisywanie ID do nazw
            var nosniki = new Wypozyczalnia_PlytContext().SlKatNosnikas;
            var muzyki = new Wypozyczalnia_PlytContext().SlkatMuzykis;
            w1_viewModel.VM_Plyty.ForEach(it => it.Nosnik = nosniki.Find(it.NosnikId));
            w1_viewModel.VM_Plyty.ForEach(it => it.Kategoria = muzyki.Find(it.KategoriaId));

        }

        private void Btn_dodaj_w2_Click(object sender, RoutedEventArgs e)
        {
            new W2().Show();
        }

        private void Btn_usun_w3_Click(object sender, RoutedEventArgs e)
        {
            new W3().Show();
        }

        private void Plyty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Btn_usun_w3.IsEnabled = true;

        }
        private void L_Wypozyczenia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Btn_oddaj_w5.IsEnabled = true;
        }
        private void Btn_wypo_w4_Click(object sender, RoutedEventArgs e)
        {
            new W4().Show();
        }
        private void Btn_oddaj_w5_Click(object sender, RoutedEventArgs e)
        {

            // Odawanie płyty

            MessageBoxResult res = MessageBox.Show("Czy potwiedasz oddanie płyty przez klienta?", "Oddawanie", MessageBoxButton.YesNo);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Oddano płyte", "Usuwanie");

                    Twypozyczenium t1 = (Twypozyczenium)L_Wypozyczenia.SelectedItem;
                    t1.DataZwrotu = DateTime.Now;

                    var find1 = cnt1.Twypozyczenia.Find(t1.WypozyczenieId);
                    cnt1.Entry(find1).CurrentValues.SetValues(t1);

                    cnt1.SaveChanges();


                    Btn_oddaj_w5.IsEnabled = false;
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Anulowano", "Anulowano");
                    Btn_oddaj_w5.IsEnabled = false;
                    break;

               
            }

        }

        
    }
}
