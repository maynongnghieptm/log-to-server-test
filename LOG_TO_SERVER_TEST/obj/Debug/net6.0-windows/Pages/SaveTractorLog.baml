   M S B A M L   `   `   `  ����M  ILOG_TO_SERVER_TEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:LOG_TO_SERVER_TEST.PagesLOG_TO_SERVER_TEST.Pages  5   	   -    'LOG_TO_SERVER_TEST.Pages.SaveTractorLog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:LOG_TO_SERVER_TEST.Pages     5   	     � Title$  SaveTractorLog��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $��Websocket Server��6   $
��Left=�6+   $��30��6F   $��
116,71,0,0q�6R   $	��Top=�6f   $	��126��6~   �� 5   
   $"��KẾT NỐI WEBSOCKET SERVER��6   $��Center=�63   $��41��6P   $��0,10,0,0q�6\   $	��Top=�6n   $	��348��6�   $��24(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ serverHostInput��5      $
��Left=�6+   $��30��6F   $��
303,71,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��225��6�   $��http://localhost:8000��6�   �� 5   
   -   5        $��Connect��5      $
��Left=�6#   $��30��6>   $��
554,71,0,0q�6J   $	��Top=�6^   $��94��6v   6�   �� 5   
   -   5        $ statusConnectionTbx��5      $
��Left=�6/   $��58��6J   $��303,159,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��225��6�   6�   �� 5   
   -   5         ��Name$ disconnectWsBtn��5      $��
Disconnect��6*   $
��Left=�6?   $��30��6Z   $��
672,71,0,0q�6f   $	��Top=�6z   $	��102��6�   6�   �� 5   
   -   5        $ sendLogsBtn��5      $��	Send logs��6&   $
��Left=�6:   $��31��6U   $��554,117,0,0q�6a   $	��Top=�6v   $��94��6�   6�   �� 5   
   -   5        $��Stop send logs��5      $
��Left=�6*   $��31��6E   $��672,117,0,0q�6Q   $	��Top=�6f   $	��102��6~   6�   5      5      