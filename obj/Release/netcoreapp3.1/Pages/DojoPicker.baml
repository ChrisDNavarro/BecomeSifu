   M S B A M L   `   `   `  ���� E  ABecomeSifu, Version=0.0.4.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BecomeSifu.PagesBecomeSifu.Pages  !    BecomeSifu.Pages.DojoPicker   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:BecomeSifu.Pages       J� RenderTransformOrigin$  0.5,0.5&� � DataContext ��  �� RelativeSource �� *Self+����  �� ImageSource$ /Resources/Background.png�� j� Stretch$ UniformToFill=� j� TileMode$
 Tile=�.���  � RowDefinitions �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��50 ��� $��* ��� $��50 �.+��� -    ��Name$ TKDTrigrams��$��3��$��3��$ ��/Resources/TKDTrigrams.png��$
��Fill=�	 J� Opacity$
	 0.25Q�$y�	Collapsed=��� -   $ 
KarateLogo��$��3��$��3��$��/Resources/KarateGate.png��$
��Fill=�$
	 0.25Q�
 �� StretchDirection$

 Both=�$��-218,-186,-208,-217q�$y�	Collapsed=��� -   $ 
BoxingRing��$��3��$��3��$��/Resources/BoxingRing.png��$
��Fill=�$
	 0.25Q�$

 Both=�$y�	Collapsed=�� $��1��$��1�� �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* �.+��� -    ��Name$ 	TaeKwonDo��$��	TaeKwonDo��$��2��$��Center=�$	��100�����	#3F4682B4$
��Bold"�
����������	#FF090000�� -   $ Boxing��$��Boxing��$��2��$��2��$��Center=�$	��100�����	#3F4682B4$
��Bold"�
����������	#FF090000�� -   $ Karate��$��Karate��$��2��$��4��$��Center=�$	��100�����	#3F4682B4$
��Bold"�
����������	#FF090000�� $��0��$��1��$��Bottom=�$��Center=�$��73(�
���   �$
��Bold"� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 50Q�   
KernelType$	 Box=��� ��� *SelectMessage+�� $��0��$��1��$��Bottom=�$��Center=�$��73(�
�����F�$
��Bold"�   $ 20Q�$	 Box=��� ��� *SelectMessage+�� $��0��$��1��$��Bottom=�$��Center=�$��73(�
���   �$
��Bold"�   $ 5Q��� ��� *SelectMessage+�� $��0��$��1��$��Bottom=�$��Center=�$��73(�
�������$
��Bold"�   $ 2Q��� ��� *SelectMessage+�� -    ��Name$ DojoDescriptionRect��$��2��$��3���� -    ��Name$ DojoDescriptionLabel��$��2��$��1��$��Stretch=�$��Stretch=�$
��Wrap=�
�������$��14(�