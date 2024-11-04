using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallery
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

        int imageNumber = 1;

        private void changeImage(int step)
        {
            imageNumber += step;
            string workingDirectory = Environment.CurrentDirectory;
            string baseDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            int fileCount = Directory.GetFiles(baseDir, "*.jpg", SearchOption.AllDirectories).Length;
            if (imageNumber > fileCount)
            {
                imageNumber = 1;
            }
            else if (imageNumber < 1)
            {
                imageNumber = fileCount;
            }
            String adres = "/kot" + imageNumber + ".jpg";
            Uri adres_obrazka = new Uri(adres, UriKind.Relative);
            myImage.Source = new BitmapImage(adres_obrazka);
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            changeImage(-1);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            changeImage(1);
        }

        private void txtBoxSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            int x;
            if (int.TryParse(txtBoxSet.Text, out x))
            if (x >= 1 && x <= 4)
            {
                imageNumber = x;
                changeImage(0);
            }
        }

        private void bgCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            grid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF006189");
        }

        private void bgCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            grid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00796B");
        }
    }
}