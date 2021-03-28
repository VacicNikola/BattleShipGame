using Battleship.Library;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BattleShipProject
{
    public partial class PostavkaBrodova : Window
    {
        private ClassForBinding binding;

        private Game game;
        private int shipCounter;
        private List<Ship> listOfShips;
        private List<string> listOfFields;
        bool shipsPlaced;


        public PostavkaBrodova(Game g)
        {
            InitializeComponent();

            shipCounter = 0;
            shipsPlaced = false;
            listOfShips = new List<Ship> { new Ship(5, true, null, "/Images/Ship5Horizontal.png"), new Ship(4, true, null, "/Images/Ship4Horizontal.png"), new Ship(3, true, null, "/Images/Ship3Horizontal.png"), new Ship(3, true, null, "/Images/Ship3Horizontal.png"), new Ship(2, true, null, "/Images/Ship2Horizontal.png") };
            listOfFields = new List<string>();

            game = g;

            binding = new ClassForBinding();

            binding.Source = listOfShips[shipCounter].Image;
            binding.Naslov = $"Unesite lokaciju {shipCounter + 1}. broda duzine {listOfShips[shipCounter].Length}";

            this.DataContext = binding;
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            if (shipCounter != 5)
            {
                string output = binding.Source.Substring(0, 13);
                string substring = binding.Source.Substring(13, 1);
                if (substring == "H")
                    output += "Vertical.png";
                else
                    output += "Horizontal.png";

                binding.Source = output;

                listOfShips[shipCounter].HorizontalOrientation ^= true;
            }
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            if (shipsPlaced)
                return;
            else
            {
                if (game.player.positionOfMyShips.availableLocation(listOfFields))
                {
                    listOfShips[shipCounter].OcupiedFields = new List<string>(listOfFields);
                    game.player.positionOfMyShips.addShip(listOfShips[shipCounter++]);
                    foreach (var s in listOfFields)
                    {
                        var button = (Button)this.FindName(s);
                        button.IsEnabled = false;
                        button.Content = "X";
                        button.Foreground = Brushes.Red;
                        button.FontSize = 20;
                    }
                    if (shipCounter != 5)
                    {
                        binding.Source = listOfShips[shipCounter].Image;
                        binding.Naslov = $"Unesite lokaciju {shipCounter + 1}. broda duzine {listOfShips[shipCounter].Length}";
                    }
                    else
                    {
                        binding.Naslov = "Brodovi uspesno postavljeni";
                        shipsPlaced = true;
                        binding.Source = "";

                    }
                }
                else
                    MessageBox.Show("Pokusajte drugu lokaciju, ne sme doci do preklapanje brodova", "Losa lokacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MouseEnters(object sender, MouseEventArgs e)
        {
            if (shipsPlaced)
                return;
            else
            {
                string value = (((Button)sender).Tag).ToString();

                listOfFields.Add(value);

                char[] seperateValues = value.ToCharArray();


                if (listOfShips[shipCounter].HorizontalOrientation == true)
                {
                    for (int i = 1, k = 1; i < listOfShips[shipCounter].Length; ++i)
                    {
                        if ((seperateValues[0] + i) >= (int)'A' && (seperateValues[0] + i) <= (int)'H')
                            listOfFields.Add($"{(char)(seperateValues[0] + i)}{seperateValues[1]}");
                        else
                        {
                            listOfFields.Add($"{(char)(seperateValues[0] - k)}{seperateValues[1]}");
                            k++;
                        }
                    }

                }
                else
                {
                    for (int i = 1, k = 1; i < listOfShips[shipCounter].Length; ++i)
                    {
                        if ((seperateValues[1] + i) >= (int)'1' && (seperateValues[1] + i) <= (int)'8')
                            listOfFields.Add($"{seperateValues[0]}{(char)(seperateValues[1] + i)}");
                        else
                        {
                            listOfFields.Add($"{seperateValues[0]}{(char)(seperateValues[1] - k)}");
                            k++;
                        }

                    }

                }

                foreach (var s in listOfFields)
                {
                    var button = (Button)this.FindName(s);
                    if (button != null)
                    {
                        button.Background = Brushes.LightBlue;
                    }
                }
            }
        }

        private void MouseLeaves(object sender, MouseEventArgs e)
        {
            foreach (var s in listOfFields)
            {
                var button = (Button)this.FindName(s);
                if (button != null)
                    button.Background = Brushes.AliceBlue;
            }
            listOfFields.Clear();

        }

        private void StartOver_Click(object sender, RoutedEventArgs e)
        {
            PostavkaBrodova newWindow = new PostavkaBrodova(new Game(game.player.Name, game.computer.D));
            //Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (shipsPlaced == false)
                MessageBox.Show("Nemoguce je pokrenuti partiju dok svi brodovi nisu postavljeni", "Greska", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MyGrid.Randomize(game.computer.positionOfComputerShips, new List<Ship> { new Ship(5, true, null, null), new Ship(4, true, null, null), new Ship(3, true, null, null), new Ship(3, true, null, null), new Ship(2, true, null, null) });
            
                Borba win = new Borba(game);
                win.Show();
                this.Close();
            }
        
        }
    }
}
