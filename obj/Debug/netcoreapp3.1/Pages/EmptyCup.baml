   M S B A M L   `   `   `  ����E  ABecomeSifu, Version=0.0.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BecomeSifu.PagesBecomeSifu.Pages  5          BecomeSifu.Pages.EmptyCup   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BecomeSifu.Pages     5      ���	#40000000  � 	Resources  5	       �� 
TargetType   	MyButton2 �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset �� 
TargetType	 ��Name
 �� Triggers P� Property P� Value��%�  &	        �� 5
   
   " ��6   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � �� 5      �� 5      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5      � $ LightSteelBlue��6+   � 5      $ LightSteelBlue��6+   $ 1Q�6B   � 5      $ 	#60000000��6+   $ 0.391Q�6=   � 5      $ 	#60000000��6+   $ 0.691Q�6=   5      5      �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   .+�5      �� $	 MyContentPresenter��6/   #��z��5   +   $��Center=�5   +   $��Center=�5    +   5!      
 5"      P� 5#       � {�$ False��6;   . �5$   "   ��  � �� 5%   &   �� 5&   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5'   .   � $ 	#60000000��6;   � 5(   .   $ 	#60000000��6;   $ 1Q�6M   � 5)   .   $ LightSteelBlue��6;   $ 0.391Q�6R   � 5*   .   $ LightSteelBlue��6;   $ 0.691Q�6R   5+   +   5-   #   �� 5.   "    � ��
 �   �6?   �� 5/   "    �@J�Opacity$ .5Q�6<   �� 50   "    � ��
 �   �6@   �� 51   "    � ��$ 1q�6D   52      54      56      57      58      .��59      �� 
����iA�$��1q�6%   ._�5:   
   �� -   5         ��Name$ CupIC��5:      ��5;      �� 5<      .R�5=      �  � RowDefinitions 5>      �� 5?      $	��100 �6,   �� 5@      $	��110 �6,   �� 5A      $��75 �6,   .+�5C      �� 
����iA�$��0,1,0,0q�69   $��2��6S   �� 5F       ��Name$ CupImage��6    $��Bottom=�6T   $��	0,0,0,-70q�6o    J� Opacity$ 1Q�6�   ��62   �� *ImageIgnorable+ J� Effect 5G      -  'System.Windows.Media.Effects.BlurEffect  5H   "      Radius$ 10Q�6-   5J      �� 5K      $��Bottom=�6B   $��	0,0,0,-70q�6]   $ 1Q�6p   ��6    �� *ImageIgnorable+ 5L        5M   "   $ 3Q�6-   5O      �� 5P       ��Name$ EmptyCupButton��6!   $��1��6X   $��25,50,25,10q�6e   $��20(�6z   $
��Bold"�6�   #��[  6�   ��69   �� *
ButtonName+��6�   �� *EmptyYourCup+{�6�   �� *ButtonActive+ 5Q      3  -System.Windows.Media.Effects.DropShadowEffect  5R   "      
BlurRadius$ 10Q�63      ShadowDepth$ 5Q�6C   5T      �� 5U      $��2��6B   $��Center=�6O   $��Center=�6j    �� TextAlignment$
 Left=�6�   
����·���6$   �� *CurrentBonus+ 5V        5W   "   $ 2Q�6-   5Y      �� 5Z      $��2��6B   $��Center=�6O   $��Center=�6j   $
 Left=�6�   
����·���6$   �� *CurrentBonus+6�   5[      5\      5^      5_      5`      