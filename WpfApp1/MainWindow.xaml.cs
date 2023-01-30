using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameBoard MyGameBoard = new GameBoard();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MyGameBoard;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            if(MyGameBoard.currentPlayer = MyGameBoard.CurrentPlayer.X)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#811717"));
            }
            else if (MyGameBoard.currentPlayer = MyGameBoard.CurrentPlayer.O)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#126712"));
            }
            clickedButton.Background = Brushes.WhiteSmoke;
            clickedButton.Content = MyGameBoard.currentPlater;
            clickedButton.IsHitTestVisible = false;
            MyGameBoard.UpdateBoard(clickedButton.Name);
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(MyGrid) - 1; i++)
            {
                var child = VisualTreeHelper.GetChild(MyGrid, i) as Button;
                child.Content = null;
                child.IsHitTestVisible = true;
                child.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            }
            MyGameBoard = new GameBoard();
            this.DataContext = MyGameBoard;
        }
        public class GameBoard : INotifyPropertyChanged
        {
            public enum CurrentPlayer
            {
                X = 1,
                O
            }
            private int turn = 1;
            public CurrentPlayer currentPlayer = CurrentPlayer.X;
        }
    }
}
