   M S B A M L   `   `   `  ����J  FPOP-sf46-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_sf46_16_GUI.GUIPOP_sf46_16_GUI.GUI  5   	   /    )POP_sf46_16_GUI.GUI.Dodaj_Namestaj_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_sf46_16_GUI.GUI     5   	     � 
ResizeMode$  NoResize=�5   	   
���iii� � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Salon Senium��5   	   $	��500��6   $	��450��6+   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��125* �6   �� 5      $
��219* �6    � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      .+�5   
   �� -   5        $��lblNaziv��5      
������$��0��68   $��0��6E   $��47,60,10,231q�6U   .��6k   Naziv:6s   �� 5   
   -   5        $��lblCena��5      
������$��0��67   $��0��6D   $��47,98,10,267q�6T   .��6j   Cena:6q   �� 5   
   -   5        $��lblKolicina��5      
������$��0��6;   $��0��6H   $��47,137,10,229q�6X   .��6o   	Kolicina:6z   �� 5   
   -   5        $��lblTip��5      
������$��0��66   $��0��6C   $��47,175,10,193q�6S   .��6j   Tip:6p   �� 5   
   -   5        $��	lblAkcija��5   4   $��Center=�6   
������$��0��6]   $��0��6j   $��10,216,59,146q�6z   .��6�   	Akcija:6�   �� 5   
   -   5        $��tbNaziv��5      
�������$��0��68   $��1��6E   $��10,60,19,311q�6U   ��6k   ��  �� Path$ Naziv��� 5   
   -   5        $��tbCena��5      
�������$��0��67   $��1��6D   $��10,98,19,272q�6T   ��6j   �� $
 Cena��� 5   
   -   5        $��
tbKolicina��5      
�������$��0��6;   $��1��6H   $��10,137,19,231q�6X   ��6o   �� $ Kolicina��� 5    
   -	   5        $��cbTip��5       $��0��6!   $��1��6.    J� RenderTransformOrigin$ -0.83,2.771&�6>   $��10,178,19,193q�6b   
������� �� SelectedItem 6�   �� $ TipNamestaja��� 5!   
   -
   5        $��cbPopust��5!      $��0��6$   $��1��61   $ -0.83,2.771&�6A   $��10,216,19,155q�6e   
������� �� SelectedValue 6�   �� $ 	NaPopustu� 6�   �� $ 	NaPopustu��� 5"   
   -   5        $��
btnSacuvaj��5"      $��30��6#   $��1��6/   $��0��6<   
������$��20,13,37,10q�6d   .��6�   	Sacuvaj6�   �� 5#   
   -   5        $��btnIzlaz��5#      $��30��6!   $��1��6-   $��1��6:   
�������$��138,13,19,10q�6a   .��6�   Izlaz6�   5$      5%      