   M S B A M L   `   `   `  ����G  CControlpanel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ControlpanelControlpanel  5   	   !    Controlpanel.MoreInfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Controlpanel     5   	   -   5          � Title$  MoreInfoWindow��5   	   $	��475��6    $	��511��6-    � Topmost$
 True��6q    � 
ResizeMode$ NoResize=�6�   .��5	      �� .+�5
   
   �  � ColumnDefinitions 5      �� 5      $��10 �6#   �� 5      $��80 �6#   �� 5      $��* �6#   �� 5      $��10 �6#    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $	��250 �6    .+�5      �� -   5        $��computer��5   �   $��
Loading...��6   $��0��6)   $��1��66   $��2��6F   $��Center=�6Z   $��Center=�6u   $��18(�6�   $
��Bold"�6�   �� 5      $��1��6   $��1��6!   $��Uptime: ��61   $
��Left=�6D   $��Center=�6_   $��14(�6z   $
��Bold"�6�   �� 5      -   5        $��Uptime��5   �   $��2��6   $��1��6(   $��
Loading...��65   $��0 0 5 0q�6G   $��Right=�6X   $��Center=�6t   $��14(�6�   �� 5!      $��2��6   $��1��6!   $��Disk: ��61   $
��Left=�6B   $��Center=�6]   $��14(�6x   $
��Bold"�6�   �� 5"      -   5        $
��Disk��5"   �   $��2��6   $��2��6(   $��
Loading...��65   $��0 0 5 0q�6G   $��Right=�6X   $��Center=�6t   $��14(�6�   �� 5$      $��3��6   $��1��6!   $��RAM: ��61   $
��Left=�6A   $��Center=�6\   $��14(�6w   $
��Bold"�6�   �� 5%      -   5        $	��RAM��5%   �   $��2��6   $��3��6(   $��
Loading...��65   $��0 0 5 0q�6G   $��Right=�6X   $��Center=�6t   $��14(�6�   �� 5'      $��4��6   $��1��6!   $��CPU: ��61   $
��Left=�6A   $��Center=�6\   $��14(�6w   $
��Bold"�6�   �� 5(      -   5        $	��CPU��5(   �   $��2��6   $��4��6(   $��
Loading...��65   $��0 0 5 0q�6G   $��Right=�6X   $��Center=�6t   $��14(�6�   �� 5*      $��5��6   $��1��6!   $��Processes: ��61   $
��Left=�6G   $��Center=�6b   $��14(�6}   $
��Bold"�6�   �� 5+      -   5         ��Name$ 	Processes��5+   a    �� 
IsReadOnly$
 True��6   " �� VerticalScrollBarVisibility$
 Auto=�6(   $��Consolas)�6K   $��1��6t   $��Center=�6�   $��6��6�   $�� ��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $��2��6�   $	��212��6�   $	��473��6  5,      5-      5.      