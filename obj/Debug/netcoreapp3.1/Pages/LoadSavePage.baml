   M S B A M L   `   `   `  ����E  ABecomeSifu, Version=0.0.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BecomeSifu.PagesBecomeSifu.Pages  5      #    BecomeSifu.Pages.LoadSavePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BecomeSifu.Pages     5      ��5	      �� 5
   
     �� ImageSource$  /Resources/Background.png��6    j� Stretch$ UniformToFill=�6=    j� TileMode$
 Tile=�6U   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��200 �6   �� 5      $
��auto �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $��50 �6   .+�5   
   �� $��1��6   $��1��6!   $��Center=�61   $��Center=�6L   $��63(�6i   
���   �$
��Bold"�6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 50Q�6      
KernelType$	 Box=�6)   �� 5   !   $�Load last saved state?��6%   6F   �� 5   
   $��1��6   $��1��6!   $��Center=�61   $��Center=�6L   $��63(�6i   
�����F�$
��Bold"�6�    5        5      $ 20Q�6   $	 Box=�6)   �� 5   !   $�Load last saved state?��6%   6F   �� 5    
   $��1��6   $��1��6!   $��Center=�61   $��Center=�6L   $��63(�6i   
���   �$
��Bold"�6�    5!        5"      $ 5Q�6   �� 5#   !   $�Load last saved state?��6%   6F   �� 5$   
   $��1��6   $��1��6!   $��Center=�61   $��Center=�6L   $��63(�6i   
�������$
��Bold"�6�    5%        5&      $ 2Q�6   �� 5'   !   $�Load last saved state?��6%   6F   �� 5(   
   $��2��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5)      �� -   5        $	��Yes��5)      $��60(�6#   $��10,10q�61   ���	#3F4682B4$
��Bold"�6W   
����������	#FF090000$	��125��6�   6�   �� 5*      -   5        $��No��5*      $��60(�6"   $��10,10q�60   ���	#3F4682B4$
��Bold"�6V   
����������	#FF090000$	��125��6�   6�   5+      5,      5-      