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
    /// <summary>
    /// Interaction logic for W5.xaml
    /// </summary>
    public partial class W5 : Window
    {
        private W2_ViewModel w2_viewModel = new W2_ViewModel();
        private Wypozyczalnia_PlytContext cnt5 = new Wypozyczalnia_PlytContext();
        private Tplyty selecteditem;

        public W5(Tplyty selectPlyta)
        {
            selecteditem = selectPlyta;
            InitializeComponent();

            rec_aut.Content = selecteditem.Autor;
            rec_tyt.Content = selecteditem.Tytul;
            rec_kat.Content = selecteditem.KategoriaId;
            rec_nos.Content = selecteditem.NosnikId;
            rec_ilo.Content = selecteditem.Ilosc;
            rec_dat.Content = selecteditem.DataWydania.Year;
        }


        public static bool IsValidNumber(string str)
        {
            //pozwalam na cyfry, zakres od 1-9999 płyt
            int i;
            return int.TryParse(str, out i) && i >= 1 && i <= 9999;
        }
        private void txt_ilosc_do_dodania_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidNumber(((TextBox)sender).Text + e.Text);
            Btn_update.IsEnabled = true;
        }


        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            Tplyty dodawanaPlyta = cnt5.Tplyties.Find(selecteditem.PlytaId);
            dodawanaPlyta.Ilosc += Convert.ToInt32(txt_ilosc_do_dodania.Text);

            cnt5.SaveChanges();

            new MainWindow().Show();
            this.Close();

        }
    }
}
