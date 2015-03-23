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

namespace DomaciRad1
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.RightButton.Click += RightButton_Click;
            this.LeftButton.Click += LeftButton_Click;
        }

        void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            this.LeftRectangles.Children.Add(new Rectangle()
            {
                Width = 60,
                Height = 60,
                Margin = new Thickness(10),
                Fill = Brushes.Purple
            });
        }

        void RightButton_Click(object sender, RoutedEventArgs e)
        {
            this.RightRectangles.Children.Add(new Rectangle()
            {
                Width = 350,
                Height = 20,
                Margin = new Thickness(5),
                Fill = Brushes.Pink,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            });
        }
    }
}
