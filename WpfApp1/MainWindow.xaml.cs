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
using System.Text.RegularExpressions;

namespace wpfapp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int kb = Convert.ToInt32(Text1.Text);
                int kg = Convert.ToInt32(Text2.Text);
                Cub Cub = new Cub(kb, kg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        class Cub
        {
            public int nc_ { get; set; }
            public int nf_ { get; set; }
            public Cub(int nc, int nf)
            {
                if (nc != 0 && nf != 0)
                {
                    nc_ = nc;
                    nf_ = nf;
                    Print();
                }
                else
                {
                    throw new Exception("Некорректный ввод");
                }
            }
            public void Print()
            {
                int sum = 0;
                Random rnd4 = new Random();
                for (int i = 1; i < nc_ + 1; i++)
                {
                    int face_value = rnd4.Next(1, nf_);
                    MessageBox.Show($"{i} куб: {face_value}");
                    sum += face_value;
                }
                MessageBox.Show($"Сумма чисел: {sum}");
            }
        }



        private void Text2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Text1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(Text1.Text, @"^[1-9]\d{2}-[1-9]\d{2}-\d{4}$").Success)
            {
                e.Handled = !(Char.IsDigit(e.Text, 0));
            }
        }

        private void Text2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(Text2.Text, @"^[1-9]\d{2}-[1-9]\d{2}-\d{4}$").Success)
            {
                e.Handled = !(Char.IsDigit(e.Text, 0));
            }
        }
    }

}