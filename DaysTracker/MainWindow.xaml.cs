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

namespace DaysTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) => DragMove();
        }

        private void Close_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();    
        }

        private void Add_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Add_btn.Foreground = Brushes.Green;
        }

        private void Add_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Add_btn.Foreground = Brushes.White;
        }

        private void Minus_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Minus_btn.Foreground = Brushes.Red;
        }

        private void Minus_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Minus_btn.Foreground = Brushes.White;
        }
    }
}