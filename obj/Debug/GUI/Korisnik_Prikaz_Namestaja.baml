   M S B A M L   `   `   `  ����J  FPOP-sf46-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_sf46_16_GUI.GUIPOP_sf46_16_GUI.GUI  5   	   3    -POP_sf46_16_GUI.GUI.Korisnik_Prikaz_Namestaja   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_sf46_16_GUI.GUI     5   	     � 
ResizeMode$  NoResize=�5   	   
���iii� � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Salon Namestaja Senium��5   	   $	��500��6(   $	��500��65   .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� -   5        $��lblPretraga��5   0   $��0��6   $��30��6$   $��Pretrazi��6C   
������$��Right=�6n   $��
10 20 0 20q�5      6*   �� 5      -   5        $��
tbPretrazi��5   G   $��1��6   $��30��6&   $��10 20 20 20q�62   
�������$��Center=�6p   6�   5      � 5   
    5      �� 5      $��* �6#   6/   .+�5      �� $��1q�6   $��0��6)   
������� �� CornerRadius$ 10��6P   $	��260��6b   ._�5      &   System.Windows.Controls.DataGrid  -   5        $��dgPrikaz��5   �      
IsReadOnly .    CanUserAddRows .  $��10q�6�   
�������$	��230��6�    �� SelectedItem 6c   ��  �� Path$ Namestaj�5      5      5       � 5!   
    5"      �� 5#      $��* �6#   5$      .+�5&      �� -   5        $��btnNazad��5&      $��Nazad��6%   $��20��65   $��400 110 15 10q�6A   6q   5'      5(      5)      