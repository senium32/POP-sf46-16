   M S B A M L   `   `   `  ����J  FPOP-sf46-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_sf46_16_GUIPOP_sf46_16_GUI  5   	        POP_sf46_16_GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_sf46_16_GUI     5   	     � 
ResizeMode$  NoResize=�5   	   
���iii� � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Salon Namestaja��5   	   $	��500��6!   $	��600��6.   .��5      ]� .+�5   
   �� -   5        $��lblSalon��5      $	��Top=�6    $��20(�65   
������$��Center=�6[   $��Center=�6}   6�   �� 5   
   .+�5      �� -   5        $��btnDodajAkciju��5   4   $	��150��6J   $��	5 15 5 10q�6V   $��40��6i   $
��Left=�6u   
������$��Dodaj na Akciju��6�   $y�Hidden=�6�   6�   �� 5      -   5        $��btnKorisnici��5      $	��150��6)   $��	5 10 5 10q�65   $��40��6H   $
��Left=�6T   
������$��	Korisnici��6�   6�   �� 5      -   5        $��	btnAkcije��5      
������$
��Left=�6>   $	��150��6T   $��40��6`   $��	5 10 5 10q�6l   $��Akcije��6�   6�   �� 5      -   5        $��btnNamestaji��5      
������$
��Left=�6A   $	��150��6W   $��40��6c   $��	5 10 5 10q�6o   $��	Namestaji��6�   6�   �� 5      -   5        $��btnTipNamestaja��5      
������$
��Left=�6D   $	��150��6[   $��40��6g   $��	5 10 5 10q�6s   $��Tip Namestaja��6�   6�   �� 5      -   5        $��btnDodatnaUsluga��5   G   $��	5 10 5 10q�64   $��Dodatne Usluge��6_   
������$	��150��6�   $��40��6�   6�   �� 5      -   5        $��
btnProdaja��5   A   $��	5 10 5 10q�6.   $��Prodaje��6S   
������$	��150��6}   $��40��6�   6�   5      �� 5   
   $��Right=�6   .+�5      �� $��right=�6   $��10q�6,    �� CornerRadius$ 10��68   
������._�5      &   System.Windows.Controls.DataGrid  -	   5        $��dgPrikaz��5   �   $��Right=�6      
IsReadOnly .    CanUserAddRows .  $	��300��6\   $��10q�6i   
������� �� SelectedItem 6�   ��  �� Path$ Objekat�5      5      � 5      .+�5       �� -
   5        $��btnDodaj��5       $��70��6)   $��40��64   $��Dodaj��6@   $��70,35,294,10q�6P   6f   �� 5!      -   5        $��	btnIzmeni��5!      $��70��6*   $��40��65   $��Izmeni��6A   $��161,35,203,10q�6R   6i   �� 5"      -   5        $��	btnObrisi��5"      $��70��6*   $��40��65   $��Obrisi��6A   $��254,35,110,10q�6R   6i   �� 5#      -   5         ��Name$ btnIzlaz��5#      $��30��6,   
�������$��70��6g   $��Izlaz��6r   	 J� RenderTransformOrigin$	 
1.052,0.28&�6�   $��354,45,10,10q�6�   5$      5%      5&      5(      