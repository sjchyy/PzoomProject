   M S B A M L   `   `   `  ����  LoadingProject    LoadingProject.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5       �� Source�� 5   
   $ 
Style.xaml?�6   %    .��5      � $��Center=�6   $��Center=�6&    � ColumnDefinitions 5	   
   �� 5
      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ aBorder��5         Loading_Big_Tire#��[  6"   $��0��6Q    J� SnapsToDevicePixels . $��60��6}   $��60��6�   z�5      �� 5      -   5        aBorderTransform�� �� Angle$ 0Q�5   >    �� CenterX$ 30Q�6H   	 �� CenterY$	 30Q�6U   
 � Triggers
 5      :� 5       :� RoutedEvent$ Border.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ aBorderTransform��6.    �� TargetProperty$ Angle�6W    g� Duration$ 0:0:2D�6z    g� RepeatBehavior$ Forever��6�   	 W� To$	 360X�6�    W� From$ 0X�6�   6�   5      5      5      5      �� 5   
   -   5        $ bBorder��5      #��[  6"   $��-22,-22,0,0q�6Q   $��1��6f   $��1��6v    . $��60��6�   $��60��6�   z�5       �� 5!      -   5        bBorderTransform��$ 0Q�5!   >   $ 30Q�6H   $	 30Q�6U   
 5#      :� 5$      $ Border.Loaded��6   .[�5%      �� .��5&      �� .��5'      W� $ bBorderTransform��6.    g� 	BeginTime$ 0:0:0.2X�6W   $ Angle�6k   $ 0:0:2D�6�   $ Forever��6�   $ 0X�6�   $	 360X�6�   6�   5(      5)      5*      5,      5-      5.      