   M S B A M L   `   `   `  ����F  BProjectDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectDemoProjectDemo  5   	   D @ProCommon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullL4clr-namespace:ProCommon.Converter;assembly=ProCommonProCommon.Converter 5      E AUserWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UserWindow;assembly=UserWindow
UserWindow 5   	       ProjectDemo.MainWindow   5      R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   )localclr-namespace:ProjectDemo    5   	   Fconvert4clr-namespace:ProCommon.Converter;assembly=ProCommon    5      :scr,clr-namespace:UserWindow;assembly=UserWindow    5   	   -   5          UserWindow.UWindow   Name$  UWindow��5         MyWindowStyle#���   5   D    � Title$ 品众精准大师��5   	   $	��350��6+   $	��525��68    � 	Resources 5      6  0ProCommon.Converter.CollectionToVisibleConverter   CollectionToVisibleConverter4  .ProCommon.Converter.WindowStateToBoolConverter  WindowStateToBoolConverter��%:   &	       &	        5	   
   6V     5
   
   6R   5      .��5      � .+�5   
   �� $
��Auto=�6   $
��Auto=�6;   .��5      ]� .+�5   
   �� -   5         ��Name$ HeaderPanel��5      $	��Top=�6*   .+�5      � .+�5      �� -   5         ��Name$ 
UserHeader��5      ���	#22EFDA9A6J   � 5       � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64    � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��0��6   $��0��6%   $��3��65   $
��Left=�6I   
�������$��10,0,0,0q�6w   $��品众精准大师��6�   6�   �� 5      $��1��6   $��0��6)   $��2��69   $��10,0,0,0q�6J   $
��Left=�6\   $8��2/ResourceLibrary;component/logo/pzoom_logo_png.png��6w   6�   �� 5       
�������$��Center=�6H   $��1��6j   $��1��6w   ��6   �� *
UserName+6�   �� 5!      $��	旗舰版��6   
�������$��3��69   $��1��6F   6X   5"      � 5#      $��	200,0,0,0q�6   .+�5$      �� -   5         ��Name$ 
UserModule��5$   ;   $��Bottom=�6    �� SelectedValuePath$ Children��6�   $��0q�6�   $��0q�6�   $��0q�6�   
������ ��6P   �� *MenuItemSource+	 �� SelectedItem	 6w   �� *CurrentFirstMenuItem+��5%      �� 5&      .R�5'   "   �� 
 �� Orientation$
 
Horizontal=�6.   6I   5(      ��5*      �� 5+       �� 
TargetType" ��6!   .�5,      ��  �� Property � �� �� Value 5-   &   �� 5.   '    �� 
TargetType" ��67   .R�5/   .   	�  	� 	GroupName$ Module��6:   $��60��6�   $��60��6�    d� 	IsChecked 6M   ��  �� RelativeSource �� *TemplatedParent+ �� Path$ 
IsSelected���6�   �� *Text+6�   50   '   52   #   53      55      56      57      � 58      y�6   ��  �� ElementName$ 
UserModule��$ SelectedValue� �� 	Converter# [ .+�59      �� 
���ؿ��60   �� 5:      -   5        $ HeaderModule��5:   4   
������ $��30��6y   	 6J   �� *CurrentSecondMenuItem+��6�   �� $ 
UserModule��$ SelectedValue���5;      �� 5<      .R�5=      �� 
������ $
 
Horizontal=�6C   6^   5>      ��5@      �� 5A      " ��6    .�5B      ��  � �� 5C   "   �� 5D   &   " ��66   .R�5E   *   	� $ Header��67   $��60��6�   $��30��6�    6J   ��  �� *TemplatedParent+$ 
IsSelected���6�   �� *Text+6�   5F   '   5H      5I      5K      5L      5M      � 5N   
   $��Bottom=�6   5P      � 5Q   
   -   5         �Name$ Grid_Container��5Q      ���	#BBFFFFFF5R      5S      5T      �� 5V   
   $��Right=�6   $
 
Horizontal=�62   $	��Top=�6K   .+�5W      �� -   5         ��Name$ 	WindowMin��5W   #   $	��Min��6     WindowMinButtonStyle#���  67   6i   d� 5X      -   5         d�Name$ 	WindowMax��5X   )   $	��Max��6     WindowMaxButtonStyle#���  6�    6=   �� $ UWindow��$ WindowState�# [ 6�   �� 5Y      -	   5        $ 	WindowCls��5Y   #   $	��Cls��6     WindowCloseButtonStyle#���  67   6m   5Z      5[      5]      