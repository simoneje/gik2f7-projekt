   M S B A M L   `   `   `  ����H  DProjektGik2f7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjektGik2f7ProjektGik2f7  5   	       ProjektGik2f7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProjektGik2f7     5   	     � Title$  GIK2F7 Project��5   	   $	��520��6    $	��800��6-   ���	#FFFF8000.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��4* �6   �� 5      $
��381* �6   �� 5      $
��132* �6   �� 5      $
��283* �6   .+�5   
   �� -   5         ��Name$ gameList��5      $
��Left=�6$   $	��366��6?   $��	15,78,0,0q�6L   $	��Top=�6_   $	��212��6w   $��1��6�   $y�Hidden=�6�   ��5      �� 5      .R�5      �� ��6    �� *name+5      5      �� 5   
   -   5         ��Name$ gameInfo��5   &   $��	Game Info��6   $
��Left=�68   $	��422��6S   $��
260,22,0,0q�6`   $	��Top=�6t   $	��223��6�   $y�Hidden=�6�   $��2��6�   $��1��6�   .��5      ��  �� Orientation$ Vertical=�6   $	��398��60   .+�5      �� $
��Name��6   $
��Wrap=�6(   $��40��6<   $	��213��6H   $
��Bold"�6T   �� 5      -   5         ��Name$ nameInfo��5      $
��Wrap=�6E   $��40��6Y   $	��213��6e   ��6/   �� *name+6e   �� 5      $��Description��6   $
��Wrap=�6/   $��40��6C   $	��213��6O   $
��Bold"�6[   �� 5       -   5        $ descInfo��5       $
��Wrap=�6L   $��40��6`   $	��213��6l   ��6/   �� *description+6l   �� 5!      $��Grade��6   $
��Wrap=�6)   $��40��6=   $	��213��6I   $
��Bold"�6U   �� 5"      -   5        $ 	gradeInfo��5"      $
��Wrap=�6G   $��40��6[   $	��213��6g   ��60   �� *grade+6g   �� 5#      $��Id��6   $
��Wrap=�6&   $��40��6:   $	��213��6F   $
��Bold"�6R   �� 5$      -   5        $ idInfo��5$      $
��Wrap=�6A   $��40��6U   $��48��6a   $
��Left=�6l   ��6-   �� *id+6l   5%      5(      �� 5)   
   -   5         ��Name$ btnLoadList��5)      $��Load list of games��6&   $
��Left=�6C   $	��Top=�6^   $��	88,10,0,0q�6v   $��20��6�   $	��120��6�   $��3��6�   �� 5+   
   -   5        $ 	btnAddImg��5+      $��Add Img to Game��6$   $
��Left=�6>   $��364,409,0,0q�6Y   $	��Top=�6n   $y�Hidden=�6�   $	��100��6�   $��2��6�   $��1��6�   �� 5,   
   -	   5        $��Options��5,      $
��Left=�6#   $��
213,10,0,0q�6>   $	��Top=�6R   $��3��6�   �� 5-   
   -
   5         ��Name$ searchListBox��5-      $
��Left=�6)   $��	15,41,0,0q�6D   $�� ��6W    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��212��6�   $��20��6�   4  .System.Windows.Automation.AutomationProperties	   HelpText$	 Search keyword��6�   $��1��6�   $y�Hidden=�6
  �� 5.   
   -   5        
 ��Name$
 	imageView��5.      $��3��6#   $
��Left=�63   $	��391��6N   $��0,41,0,0q�6[   $	��Top=�6m   $	��277��6�   52      53      