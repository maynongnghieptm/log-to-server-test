   M S B A M L   `   `   `  ����M  ILOG_TO_SERVER_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:LOG_TO_SERVER_TESTLOG_TO_SERVER_TEST  5   	   #    LOG_TO_SERVER_TEST.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:LOG_TO_SERVER_TEST     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      .+�5   
   �� -   5        $��0,31,0,0q�5       �� TextWrapping$
 Wrap=�6$   $
��MENU��68   $	��Top=�6D   $	��373��6\   $��1��6�   $��Center=�6�    �� TextAlignment$ Center=�6�   $
��Bold"�6�   $��22(�6�   �� 5   
   -   5        $��Create new route��5      $��2��6,   $
��Left=�6@   $��42��6[   $��
72,354,0,0q�6g   $	��Top=�6{   $	��124��6�   6�   �� 5   
   $��Username��6   $��2��6#   $
��Left=�67   $��32��6R   $��214,102,0,0q�6^   $	��Top=�6s   $��92��6�   �� 5   
   -   5        $��Login��5      $��Center=�6!   $��52��6>   $��	0,237,0,0q�6J   $	��Top=�6]   $	��114��6u   $��1��6�   6�   �� 5   
   $��Password��6   $��2��6#   $
��Left=�67   $��31��6R   $��214,150,0,0q�6^   $	��Top=�6s   $��73��6�   �� 5   
   -   5         ��Name$ usernameInput��5      $��2��6)   $
��Left=�6=   $��32��6X   $��343,102,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   $	��195��6�   6�   �� 5   
   -   5        $ passwordInput��5      $��2��6)   $
��Left=�6=   $��31��6X   $��343,150,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   $	��195��6�   6�   �� 5   
   -   5         ��Name$ connectToWssBtn��5      $��Connect to WSS��6*   $��2��6C   $
��Left=�6W   $��42��6r   $��214,354,0,0q�6~   $	��Top=�6�   $	��132��6�   6�   �� 5   
   -   5        $��Select Tractor and Field��5      $��2��64   $
��Left=�6H   $��42��6c   $��372,354,0,0q�6o   $	��Top=�6�   $	��136��6�   6�   5      5      