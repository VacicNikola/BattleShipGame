   M S B A M L   `   `   `  ����L  HBattleShipProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BattleShipProjectBattleShipProject  5   	   "    BattleShipProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:BattleShipProject     5   	     � Title$!  Battle Ship by Nikola Vacic��5   	   $	��800��6-   $	��800��6:    � WindowState$ 	Maximized=�6F   .��5	      � ��5
   
   �� 5       �� ImageSource$ /Images/background.jpeg��6   6A    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��1��6!   $��40(�61   
�������$��0 10 0 0q�6R   $��Center=�6d   " Dobro dosli u Battle Ship igricu6�   �� 5    
   $��1��6   $��1��6!   $��30(�61   
�������$��	0 20 0 20q�6R   $��Center=�6f   Instrukcije6�   �� 5!   
   $��2��6   $��1��6!   $��25(�61   
�������$��0 20 0 5q�6R   $
��Wrap=�6e   861. Svaki igrac dobija 5 brodova, duzine 5, 4, 3, 3, 2.6�   �� 5"   
   $��3��6   $��1��6!   $��25(�61   
�������$��0 20 0 5q�6R   $
��Wrap=�6e   :82. Brodove je potrebno postaviti na tablu dimenzije 8x8.6�   �� 5#   
   $��4��6   $��1��6!   $��25(�61   
�������$��0 20 0 5q�6R   1/3. Igrac i kompjuter neizmenicno gadjaju polja.6�   �� 5$   
   $��5��6   $��1��6!   $��25(�61   
�������$��0 20 0 5q�6R   @>4. Ukoliko pogode polje na kom se nalazi brod taj brod ispada.6�   �� 5%   
   $��6��6   $��1��6!   $��25(�61   
�������$��0 20 0 5q�6R   ;95. Partija je gotova kada jedan igrac ostane bez brodova.6�   �� 5&   
   $��7��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��0 70 0 0q�6K   .+�5'      �� 
�������$��40(�6'   $��	0 0 20 0 q�65   .��6H   Ime:6N   �� 5(      -   5        $��
textBoxIme��5(      $	��400��6(   $	��500��67   $��40(�6F   
���   �6i   5)      �� 5*   
   $��8��6   $��1��6"   $ 
Horizontal=�62   $��0 20 0 0q�6K   .+�5+      �� 
�������$��25(�6'   $��	0 0 20 0 q�65   .��6H   	Tezina:6R   	� 5,      -   5        $
��easy��5,       	� 	GroupName$ 
Difficulty��6&   $��Center=�6>   $��Center=�6a   $��	30 0 10 0q�6|   $��25(�6�    d� 	IsChecked$
 TrueY�6�   .��6�   Lako6�   	� 5-      -   5        $��medium��5-      $ 
Difficulty��6(   $��Center=�6@   $��Center=�6c   $��	30 0 10 0q�6~   $��25(�6�   .��6�   	Srednje6�   	� 5.      -   5        $
��hard��5.      $ 
Difficulty��6&   $��Center=�6>   $��Center=�6a   $��	30 0 10 0q�6|   $��25(�6�   .��6�   Tesko6�   5/      �� 50   
   -   5        $��enterButton��50      $��1��6$   $��9��64   $��40(�6A   $��0 20 0 0q�6O   .��6{   	Pokreni6�   51      52      