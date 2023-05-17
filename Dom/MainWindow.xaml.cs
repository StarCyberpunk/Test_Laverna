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

namespace Dom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private async void button_search_Click(object sender, RoutedEventArgs e)
        {
            string city = InputCity.Text;
            RootViewModel dt = await new DataFromApi().GetDataAboutCity(city);
            if (dt.Temp != null)
            {
                Result.Text = String.Format("Температура: {0} с \n" +
                    "Описание: {1}\n" + "Скорость ветра: {2} м/с", dt.Temp, dt.Description, dt.Wind_speed);
            }
            else
            {
                Result.Text = "Проверьте корректность введенных данных";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            InputCity.Text = "";
            Result.Text = "";
        }
    }
}
