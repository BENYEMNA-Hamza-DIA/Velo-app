   M S B A M L   `   `   `  ����F  BWPF_TD9_BDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_TD9_BDDWPF_TD9_BDD  5   	       WPF_TD9_BDD.GestionStock   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_TD9_BDD     5   	     � Title$  GestionStock��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5        $��Afficher Stock Piece��5
      $
��Left=�60   $	��Top=�6K   $	��161��6c    J� RenderTransformOrigin$ 4.976,4.427&�6o   $��10,4,0,0q�6�   $��52��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtGrid��5   I   $��10,57,10.333,90.667q�6   ��60   �� 6I   �� 5   
   -   5        $��Nom fournisseur��5      $
��Left=�6+   $��262,363,0,0q�6F   $	��Top=�6[   $��84��6s   $��27��6�   �� 5   
   -   5        $��Marque��5      $
��Left=�6"   $��
10,363,0,0q�6=   $	��Top=�6Q   $��83��6i   $ 3.082,1.331&�6�   $��27��6�   �� 5   
   -   5        $��Afficher Stock Velo��5      $
��Left=�6/   $	��Top=�6J   $	��161��6b   $ 4.976,4.427&�6n   $��	176,4,0,0q�6�   $��52��6�   �� 5   
   -   5        $��Retour��5      $
��Left=�6"   $��708,382,0,0q�6=   $	��Top=�6R   $��75��6j   $ 0.036,-0.129&�6u   6�   �� 5   
   $
��Left=�6   $��20��6-   $��
10,335,0,0q�69    �� TextWrapping$
 Wrap=�6M   $��Trier les Vélos par :��6a   $	��Top=�6~   $	��161��6�   �� 5   
   $
��Left=�6   $��20��6-   $��262,335,0,0q�69   $
 Wrap=�6N   $��Trier les Pièces par :��6b   $	��Top=�6�   $	��161��6�   �� 5   
   -   5        $��Valider��5      $
��Left=�6#   $��27��6>   $��
98,363,0,0q�6J   $	��Top=�6^   $��43��6v   
��� � �$ -2.711,1.102&�6�   �� 5   
   -   5        $��Valider��5      $
��Left=�6#   $��27��6>   $��351,364,0,0q�6J   $	��Top=�6_   $��43��6w   
��� � �$ -2.711,1.102&�6�   �� 5   
   -	   5        $��Requete auto jointure��5      $
��Left=�61   $��469,363,0,0q�6L   $	��Top=�6a   $	��161��6y   $��27��6�   �� 5   
   $
��Left=�6   $��20��6-   $��469,335,0,0q�69   $
 Wrap=�6N   $%��Pieces arrivés deffectueuses :��6b   $	��Top=�6�   $	��161��6�   5      5      