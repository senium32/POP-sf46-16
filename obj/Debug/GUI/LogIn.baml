   M S B A M L   `   `   `  ����J  FPOP-sf46-16-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:POP_sf46_16_GUI.GUIPOP_sf46_16_GUI.GUI  5   	       POP_sf46_16_GUI.GUI.LogIn   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:POP_sf46_16_GUI.GUI     5   	     � 
ResizeMode$  NoResize=�5   	   
���iii� � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ LogIn��5   	   $	��400��6   $	��350��6$    � 	Resources 5       	  LogIn��%   &	        �� 5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6:    J� InputBindings 5      �� 5   
   
 �� Key$ Return��6    �� Command# [  6"   .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��305* �6   �� 5      $	��66* �6   
 � ColumnDefinitions
 5   
   �� 5      $	��19* �6   �� 5      $	��30* �6   .+�5   
   � $��1��6   .+�5       �� 
������$��-59,20,70,193q�6-    �� CornerRadius$ 10��6D   ._�5!      �� $��/Resources/Logo.jpg��6   $��70��65   $��1��6A   $��30,12,31,10q�6Q   5"      5#      �� 5$   
   -   5        $��lblUsername��5$      
������$��0��6;   $��30��6K   $��34,129,5,146q�6W   .��6m   	Username:6x   �� 5%   
   -   5        $��lblPassword��5%      
������$��0��6;   $��30��6K   $��39,164,0,111q�6W   .��6m   	Password:6x   �� 5&   
   -   5        $��
tbUsername��5&      
�������$��1��6;   $��30��6K   $��0,129,20,146q�6W   G� 5'   
   -   5        $��pswBox��5'      
�������$��1��6;   $��30��6K   $��0,164,20,111q�6W   �� 5(   
   -   5        $��btnLogin��5(      $��29,21,34,10q�6!   $��1��66   $��0��6C   .��6j   LogIn6q   �� 5)   
   -   5        $��btnIzlaz��5)      $��136,21,10,10q�6!   $��1��67   $��1��6D   .��6k   Izlaz6r   �� 5*   
   -   5        $��lblRegistracija��5*      $��14(�6   
������$��Nemate nalog?��6M   $��1��6e   $��0��6u   $��0,204,95,61q�6�   �� 5+   
   -	   5        $��lblOvde��5+      $��Napravi��67   $��1��6I   $��0��6Y   $��116,204,20,61q�6f   
�������6}   5,      5-      