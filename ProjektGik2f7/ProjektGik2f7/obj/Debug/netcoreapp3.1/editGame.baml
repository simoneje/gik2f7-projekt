   M S B A M L   `   `   `  ����H  DProjektGik2f7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjektGik2f7ProjektGik2f7  5   	       ProjektGik2f7.editGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProjektGik2f7     5   	     � Title$  editGame��5   	   $	��450��6   $	��400��6'   .��5	      � ���	#FFFF8000.+�5
   
   �� -   5         ��Name$ editGameBox��5
      $��Edit Game info��6(   $��Center=�6@   $	��345��6]   $��Center=�6j   $	��223��6�   .��5      �� $	��322��6   $��0,0,-2,0q�6&   .+�5      �� $��10q�6   $��ID��6(   $
��Wrap=�62   $	��166��6F   �� 5      -   5         ��Name$ idEditInput��5      $�� ��6/    �� TextWrapping$
 Wrap=�67   $	��167��6K   �� 5      $��10q�6   $
��Name��6(   $
��Wrap=�64   $	��166��6H   �� 5      -   5        $ gNameEditInput��5      $�� ��63   $
 Wrap=�6;   $	��167��6O   �� 5      $��10q�6   $��Description��6(   $
��Wrap=�6;   $	��166��6O   �� 5      -   5        $ gDescEditInput��5      $�� ��62   $
 Wrap=�6:   $	��Top=�6N   $	��167��6f   �� 5      $��10q�6   $��Rating 1-10��6(   $
��Wrap=�6;   $	��166��6O   �� 5      -   5         ��Name$ gradeSliderEdit��5       � Maximum$ 10Q�62   $	��120��6?    � Cursor$
 Hand��6K    � SmallChange$ 2Q�6Y    �� TickPlacement$
 Both=�6i   	 �� IsSnapToTickEnabled$
	 True��6~   
 � Minimum$
 1Q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5      $
��Wrap=�6q   $	��113��6�   $��51��6�   ��6   �� *Value+ �� ElementName$ gradeSlider�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5         ��Name$ 	editGame1��5      $
��Save��6,   $��Center=�6;   $��0,0,0,0q�6X   $��66��6i   6t   5      5      5       5!      