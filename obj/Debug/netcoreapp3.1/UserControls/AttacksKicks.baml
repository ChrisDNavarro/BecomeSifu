   M S B A M L   `   `   `  ����E  ABecomeSifu, Version=0.0.3.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:BecomeSifu.UserControlsBecomeSifu.UserControls  5      *    $BecomeSifu.UserControls.AttacksKicks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:BecomeSifu.UserControls     5        � 	Resources  5	       �� 
TargetType   	MyButton2 �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value  ScrollBarThumb	 ��Name
 J� SnapsToDevicePixels J� Opacity �� CornerRadius �� 
TargetName  ScrollStyle �� RelativeSource �Name �� Padding ]�Name J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb  ScrollViewerControlTemplate � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4  .System.Windows.Automation.AutomationProperties    AutomationId! � Cursor" �� ScrollableHeight# � Maximum$ � Minimum*% �� #ComputedVerticalScrollBarVisibility& �� ViewportHeight' �� ViewportSize( � Value) �� Mode* �� ScrollableWidth+ �� Orientation,, �� %ComputedHorizontalScrollBarVisibility- �� ViewportWidth��%\  &	        &	 "    &	 e    7  &	 C    7  7  �� 5
   
   " ��6   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � �� �	#600000006+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   .+�5      �� $ MyContentPresenter��6/   #��z��5   +   $��Center=�5   +   $��Center=�5   +   5       5      P� 5       � {�$ False��6;   . �5   "   ��  � �� �	#400000006?   �� 5   "    � ��
 �iii�6?   5      5      5      5       �� 5"   
   " n�6'   .�5#      ��  �@�OverridesDefaultStyle$
 true��66   �� 5$       � ��$ false��6*   �� 5%       � �� 5&      �� 5'      " n�6&   .R�5(      �� $	 	rectangle��6!   $

 True��5)      
������ $ 1Q�5+      $ 4��5,      
�������$��1q�5.      #��z��5/      #��z��50       51      P� 52       �@J�IsMouseOver$
 true��6=   . �53   "   �� $ 	rectangle��6)    �@J�Opacity$ 1Q�6S   �� 54   "   $ 	rectangle��6)    � �� �	#604682b46V   55      57      59      5:      �� 5<   
   " ��6$   .�5=      ��  �@��IsPressAndHoldEnabled$ false��6=   �� 5>       �@��IsFlicksEnabled$ false��67   �� 5@       � ��$ 14��6&   �� 5A       � ��$ 	-14 0 0 0q�6'   �� 5B       � �� 6)   �� *Height+ �� *Self+�� 5C       � �� 5D      �� 5E      " ��6&   .R�5F      � $ Bg��6   $

 true��6+   .+�5H      �� $	 0 4q�6%   ._�5I   "   ]� $ 
PART_Track��6(   $
��true��5J      #{�z 5K      $��8��5L      $��Center=�5M       5O   &   �� 5P   *   $ 0Q�67   #��Z 6C    5R   &   �� 5S   *   $ 0Q�67   #��Z 6C    5U   &   n� 5V   *   8��  60   5X   #   5Y      5Z      5[      5]      5^      �� 5_   
   " ��6>   .R�5`      � $
 Grid��6   #��z��6!    5a      �� 5b      $��* �6'   �� 5c      $
��Auto �6'    5e      �� 5f      $��* �6$   �� 5g      $
��Auto �6$   .+�5i      �� $ Corner��6   $��1��6,   #��� ��6<   $��1��6}   �� 5j      $! PART_ScrollContentPresenter��6)   # z��6N   $ False��6�   $ False��6�   #��z��6�   #��z��6�   $��0��6  #��z��6&  $��0��6I  �� 5k      $ PART_VerticalScrollBar��6A   8��  $  VerticalScrollBar��6a   $! Arrow��6�   $��1��6�   ## z" 6�   $$ 0Q�6�   $��0��6�   #y�z% 6�   #' z& 6�  ( 6?  �� *VerticalOffset+$) OneWay=� �� *TemplatedParent+6�  �� 5l      $ PART_HorizontalScrollBar��6A   8�� $  HorizontalScrollBar��6c   $! Arrow��6�   $��0��6�   ## z* 6�   $$ 0Q�6�   $+ 
Horizontal=�6�   $��1��6  #y�z, 6  #' z- 6�  ( 6]  �� *HorizontalOffset+$) OneWay=� �� *TemplatedParent+6�  5m      5n      5o      .��5p      �� $
��Auto=�6   #��[ 66   .��5q   
   �� -   5        . ��Name$. KicksIC��5q      ��5r      �� 5s      .R�5t      �� $��0,0,0,1q�6I   ���	#40000000��6   �� *BackgroundIgnorable+._�5u      �  5v      �� 5w   "   $	��200 �63   �� 5x   "   $
��auto �63   �� 5y   "   $
��auto �63   �� 5z   "   $��* �63   .+�5|      �� $
��Left=�6=   $��Center=�6X   $	��150��6s   $��25,0,0,0q�6   $
��Bold"�6�   
����·���6$   �� *Name+/ J� Effect/ 5}   "   3  -System.Windows.Media.Effects.DropShadowEffect  5~   &   0   
BlurRadius$0 5Q�67   1   ShadowDepth$1 0Q�6F   5�      �� 5�      $
��Left=�6=   $��Center=�6X   $	��150��6s   $��25,0,0,0q�6   $
��Bold"�6�   
����·���6$   �� *Name+6�   �� 5�      $��1��6(   $
��Left=�6O   $��Center=�6j   $��	25,0,0,0 q�6�   
���������68   �� *Level+6�   �� 5�      $��2��6%   $��75��6Q   $
��Left=�6\   $��Center=�6w   $��	50,5,25,5q�6�   $��Center=�6�   #��[  6  ��65   �� *	LevelUp+{�6�   �� *	Enabled+��6�   �� *KicksLevelUpCommand+6  5�      5�      5�      5�      5�      5�      