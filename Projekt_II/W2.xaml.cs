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


    // Dodawanie Rekordu
    public partial class W2 : Window
    {
        private W2_ViewModel w2_viewModel = new W2_ViewModel();
        private W1_ViewModel w1_viewModel = new W1_ViewModel();
        private Wypozyczalnia_PlytContext cnt1 = new Wypozyczalnia_PlytContext();


        public W2()
        {

            InitializeComponent();

            w2_viewModel.VM_Plyty = cnt1.Tplyties.ToList();
            w2_viewModel.VM_Nosnik = cnt1.SlKatNosnikas.ToList();
            w2_viewModel.VM_Muzyka = cnt1.SlkatMuzykis.ToList();
            w1_viewModel.VM_Plyty = cnt1.Tplyties.ToList();
            DataContext = w2_viewModel;


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var plyta1 = new Tplyty
            {
                Autor = w2_viewModel.txt_autor,
                Tytul = w2_viewModel.txt_tytul,
                DataWydania = w2_viewModel.data_wydania,
                NosnikId = w2_viewModel.Wybrany_Nosnik.NosnikId,
                KategoriaId = w2_viewModel.Wybrana_Muzyka.KategoriaId,
                Ilosc = w2_viewModel.int_ilosc
            };

            /*
                        var zmn1 = cnt1.Tplyties.Where(x => x.Autor == plyta1.Autor)
                            .Where(x => x.Tytul == plyta1.Tytul).First();

                        if (zmn1 == null)
                        {


                        }
                        else
                        {
                            zmn1.Ilosc += plyta1.Ilosc;
                        }

            */
            cnt1.Tplyties.Add(plyta1);
            cnt1.SaveChanges();
            w1_viewModel.VM_Plyty = new Wypozyczalnia_PlytContext().Tplyties.ToList();


        }


        //--------------------------------
        //   WALIDACJA FORMULARZA
        // -------------------------------

        public static bool IsValidLenght(string str)
        {
            //Sprawdzam tylko czy cos jest napisane
            return str.Length >= 1;
            
            
        }
        public static bool IsValidNumber(string str)
        {
            //pozwalam na cyfry, zakres od 1-9999 płyt
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 9999;
        }

        public void Validation()
        {
            // Walidacja
            bool[] walidacja = new bool[6];

            walidacja[0] = txt_autor.Text.Length == 0 ? true : false;
            walidacja[1] = txt_tytul.Text.Length == 0 ? true : false;
            walidacja[2] = w2_viewModel.int_ilosc == 0 ? true : false;
            walidacja[3] = w2_viewModel.data_wydania.Year == 1 ? true : false;
            walidacja[4] = w2_viewModel.Wybrany_Nosnik == null ? true : false;
            walidacja[5] = w2_viewModel.Wybrana_Muzyka == null ? true : false;


            if (walidacja.Contains(true))
            {
                Btn_Dodaj.IsEnabled = false;
            }
            else
            {
                Btn_Dodaj.IsEnabled = true;
            }
        }
       

        // Texbox ilosc: lenght i zakres 1-9999
        private void txt_ilosc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidLenght(((TextBox)sender).Text + e.Text);
            e.Handled = !IsValidNumber(((TextBox)sender).Text + e.Text);
        }

        private void txt_ilosc_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation();
        }

        private void txt_autor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation();
        }

        private void txt_tytul_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Validation();
        }

        private void Cmbb_Nosnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Validation();

        }

        private void Cmbb_Muzyka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Validation();

        }


    //--------------------------------
    //   Dodawanie kategori / powodów itp.
    // -------------------------------


        //Walidacja Słowników (SL-i)
        private void txt_nos_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_nos.Text.Length > 0) btn_nos.IsEnabled = true;
            

        }

        private void txt_muz_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_muz.Text.Length > 0) btn_muz.IsEnabled = true;

        }

        private void txt_pow_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_pow.Text.Length > 0) btn_pow.IsEnabled = true;

        }

        // Dodawanie powodów do SL-i
        private void btn_nos_Click(object sender, RoutedEventArgs e)
        {

            SlKatNosnika n1 = new SlKatNosnika();
            n1.Nazwa = txt_nos.Text;
            cnt1.Add(n1);
            cnt1.SaveChanges();
            w2_viewModel.VM_Nosnik = new Wypozyczalnia_PlytContext().SlKatNosnikas.ToList();
        }

        private void btn_muz_Click(object sender, RoutedEventArgs e)
        {
            SlkatMuzyki n2 = new SlkatMuzyki();
            n2.Nazwa = txt_muz.Text;
            cnt1.Add(n2);
            cnt1.SaveChanges();
            w2_viewModel.VM_Muzyka = new Wypozyczalnia_PlytContext().SlkatMuzykis.ToList();
        }

        private void btn_pow_Click(object sender, RoutedEventArgs e)
        {

            Slpowod n3 = new Slpowod();
            n3.Nazwa = txt_pow.Text;
            cnt1.Add(n3);
            cnt1.SaveChanges();
            w2_viewModel.VM_Powod = new Wypozyczalnia_PlytContext().Slpowods.ToList();
        }






    }

}


