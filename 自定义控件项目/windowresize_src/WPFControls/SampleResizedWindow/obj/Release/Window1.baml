   M S B A M L   `   `   `  ����   SampleResizedWindow!    SampleResizedWindow.Window1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Title$  Resize Window Exmaple��$	��300��$	��550�� � WindowStyle$
 None=� � AllowsTransparency . 
������ $	��550��$	��300��.���  � RowDefinitions �� $��20 ��� $��* ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��20 �.+��� -   $��leftSizeGrip��$��0��$��1��
���  ���� -   $��rightSizeGrip��$��2��$��1��
���  ���� -   $��topSizeGrip��$��1��$��0��
���  ���� -   $��bottomSizeGrip��$��1��$��2��
���  ���� -   $��topLeftSizeGrip��$��0��$��0��
����  ��� -   $��bottomRightSizeGrip��$��2��$��2��
����  ��� -   $��topRightSizeGrip��$��2��$��0��
����  ��� -	   $��bottomLeftSizeGrip��$��0��$��2��
����  ��� -
    ��Name$ RectContent��$��1��$��1��
�������� $��1��$��1��$��Center=�$��Center=�.��CONTENT HERE TYPICALLY�� $��1�� �� Orientation$ 
Horizontal=�$��1��$��Right=�$	��Top=�.+��� -    ��Name$ windowHeader��$	��300��
��� ����� -    ��Name$ 	windowMin��$��5q�$
�� min���� -   $ 	windowMax��$��5q�$
�� max���� -   $ windowClose��$��5q�$�� close���� 
��� ���$��1��$��1��$
��Left=�$��Bottom=�.��?=Application by Derek Bartram (http://www.derek-bartram.co.uk)