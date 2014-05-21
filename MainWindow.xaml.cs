using DeskClock.UI;
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
using MvvmFoundation.Wpf;
using DeskClock.Core;
namespace DeskClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;

            this.Background = new SolidColorBrush(Color.FromArgb(1,0,0,0));
            this.DataContext = this;

            Clock = new ClockViewModel();

            this.Left = Settings.XPosition;
            this.Top = Settings.YPosition;
        }

        public ClockViewModel Clock { get; set; }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            App.Messenger.NotifyColleagues(App.Events.WindowMoved, new Point(this.Left, this.Top));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenSettings(object sender, MouseButtonEventArgs e)
        {
            Clock.Toggle();
        }
    }
}
