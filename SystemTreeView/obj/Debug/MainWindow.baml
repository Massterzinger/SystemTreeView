   M S B A M L   `   `   `  ����I  ESystemTreeView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SystemTreeViewSystemTreeView  5   	       SystemTreeView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SystemTreeView     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5	      )   #SystemTreeView.IconToImageConverter   	converter��%   &	          5
   
   6%   5      .��5      R� -   5         R�Name$ foldersTree��5       5   
    �� 
TargetType��%E   'Q�       �� 5      " Q�6   .�5      -   5        5      5      ��5   
   �� 5       �� ItemsSource 6'   ��  �� Path$ Nodes�.R�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��img��6   $��20��6(   $��20��63   $
��Fill=�6?   ��5   (   �� $
 Icon� �� IsAsync .  �� 	Converter# [  �� 5      ��6    �� *Header+5      5      5      5      