using Battleship.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BattleShipProject
{
    /// <summary>
    /// Interaction logic for Borba.xaml
    /// </summary>
    public partial class Borba : Window
    {
        private Game game;

        private ClassForBinding binding;

        public Borba(Game g)
        {
            game = g;


            InitializeComponent();

            populateTable(g.player.positionOfMyShips.listOfShips);

        }

        private void populateTable(List<Ship> listOfShips)
        {
            List<string> names = new List<string> { "xA1", "xA2", "xA3", "xA4", "xA5", "xB1", "xB2", "xB3", "xB4", "xC1", "xC2", "xC3", "xD1", "xD2", "xD3", "xE1", "xE2" };
            int counter = 0;

            foreach (var ship in listOfShips)
            {
                foreach (var s in ship.OcupiedFields)
                {
                    var button = (Button)this.FindName(names[counter++]);
                    button.Content = s;
                }
            }
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            string value = (((Button)sender).Tag).ToString();

            List<string> names = new List<string> { "xA1", "xA2", "xA3", "xA4", "xA5", "xB1", "xB2", "xB3", "xB4", "xC1", "xC2", "xC3", "xD1", "xD2", "xD3", "xE1", "xE2" };

            Ship ship;
            bool hit;
            
            
            (hit,ship) = game.computer.positionOfComputerShips.checkIfHit(value);

            if (hit)
            {
                
                MessageBox.Show($"Pogodjen je broj duzine {ship.Length}. Protivniku je ostalo {--game.ComputerShipsLeft} brodova.", "Pogodak", MessageBoxButton.OK, MessageBoxImage.None);
                foreach (var str in ship.OcupiedFields) {

                    var button = (Button)this.FindName(str);
                    button.IsEnabled = false;
                    button.Content = "O";
                    button.Foreground = Brushes.Blue;
                    button.FontSize = 20;
                }

            }
            else
            {
                MessageBox.Show($"Promasaj, u polje {value} je nemoguce pucati opet. Protivniku je ostalo {game.ComputerShipsLeft} brodova.", "Promasaj", MessageBoxButton.OK, MessageBoxImage.None);
                var button = (Button)this.FindName(value);
                button.IsEnabled = false;
                button.Content = "X";
                button.Foreground = Brushes.Red;
                button.FontSize = 20;
            }

            if (game.ComputerShipsLeft == 0)
            {
                MessageBox.Show($"Cestitam {game.player.Name}, pobedili ste kompjuter. Probajte sa tezim nivoom", "Pobeda!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
                return;
            }
            
            MessageBox.Show("Kompjuter bira koje polje zeli napasti...", "Kompjuter igra", MessageBoxButton.OK, MessageBoxImage.None);

            string computerAttacks = game.ComputerAttack(game.player.positionOfMyShips);

            (hit, ship) = game.player.positionOfMyShips.checkIfHit(computerAttacks);

            if (hit)
            {
                MessageBox.Show($"Kompjuter napada polje {computerAttacks}. To je pogodak. Potopljen je brod duzine {ship.Length}. Ostalo Vam je jos {--game.PlayerShipsLeft} broda", "Kompjuter igra", MessageBoxButton.OK, MessageBoxImage.None);
                foreach(string name in names){
                    var button = (Button)this.FindName(name);
                    if (ship.OcupiedFields.Contains(button.Content.ToString())) {
                        button.Content = "X";
                        button.Foreground = Brushes.Red;
                    }

                }
            
            }
            else
                MessageBox.Show($"Kompjuter napada polje {computerAttacks}. To je promasaj. Ostalo Vam je jos {game.PlayerShipsLeft} broda", "Kompjuter igra", MessageBoxButton.OK, MessageBoxImage.None);



            if (game.PlayerShipsLeft == 0)
            {
                MessageBox.Show($"Nazalost, {game.player.Name}. Izgubili ste. Probajte ponovo sa laksim nivoom", "Poraz!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
                return;
            }


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
