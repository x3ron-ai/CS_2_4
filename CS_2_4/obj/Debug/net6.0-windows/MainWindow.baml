   M S B A M L   `   `   `  ����A  =CS_2_4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CS_2_4CS_2_4  5   	       CS_2_4.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:CS_2_4     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��39* �6   �� 5      $
��309* �6   �� 5      $	��86* �6    � ColumnDefinitions 5   
   �� 5      $
��123* �6   �� 5      $	��77* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ ogo_calendar��5      $��2��6+   6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ notesContainer��5      $��10,23,10,10q�6+   $��1��6@   6M   �� 5   
   -   5         ��Name$ todaySum��5      $/��)Сегодняшняя сумма preview��6&   $��5,4,5,43q�6H   $��2��6Z   �� 5   
   -   5        $ allSum��5      $#��Общая сумма preview��6$   $��5,41,5,6q�6?   $��2��6Q   �� 5   
   $��
Enter name��6   $��
10,10,10,0q�6&   $��1��6:   $
��14px(�6J    �� TextAlignment$ Center=�6Z   $��20��6q   $	��Top=�6}   $��1��6�   �� 5    
   -   5         ��Name$ 	nameInput��5       $��1��6%   $��
10,35,10,0q�65   $��1��6I   $��21��6V   $	��Top=�6b   �� 5!   
   $��Enter count��6   $��
10,56,10,0q�6'   $��1��6;   $
��14px(�6K   $ Center=�6[   $��16��6r   $	��Top=�6~   $��1��6�   �� 5"   
   -   5        $ 
countInput��5"      $��1��6&   $��
10,80,10,0q�66   $��1��6J   $��22��6W   $	��Top=�6c   �� 5%   
   $��Select type��6   $��10,107,10,0q�6'   $��1��6<   $
��14px(�6L   $ Center=�6\   $��1��6s   $��17��6�   $	��Top=�6�   �� 5&   
   -   5         ��Name$ 	typesList��5&      $��10,131,10,0q�6&   $��1��6;   $��1��6K   $��22��6X   $	��Top=�6d   �� 5'   
   -   5        $��1��5'      $��10,158,10,0q�6!   $��New datatype��66   $��1��6j   $��20��6w   $	��Top=�6�   �� 5*   
   -	   5        	 ��Name$	 AddNote��5*      $��Add new note��6"   $��
10,10,10,0q�69   $��2��6M   $��1��6Z   $��22��6j   $	��Top=�6v   6�   �� 5+   
   -
   5        $	 EditNote��5+      $��	Edit note��6#   $��
10,32,10,0q�67   $��2��6K   $��1��6X   $��22��6h   $	��Top=�6t   6�   �� 5,   
   -   5        $	 
RemoveNote��5,      $��Delete note��6%   $��
10,54,10,0q�6;   $��2��6O   $��1��6\   $��22��6l   $	��Top=�6x   6�   5-      5.      