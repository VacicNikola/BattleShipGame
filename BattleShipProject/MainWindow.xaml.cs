using System.Windows;
using Battleship.Library;

namespace BattleShipProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            Difficulty d;
            string name = textBoxIme.Text;

            if (name == "")
                MessageBox.Show("Morate uneti ime!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if ((bool)easy.IsChecked)
                    d = Difficulty.Easy;
                else if ((bool)medium.IsChecked)
                    d = Difficulty.Medium;
                else
                    d = Difficulty.Hard;

                game = new Game(name, d);

                PostavkaBrodova win = new PostavkaBrodova(game);
                win.Show();
                this.Close();
            }
        }
    }
}
