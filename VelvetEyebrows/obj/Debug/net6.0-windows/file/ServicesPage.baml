   M S B A M L   `   `   `  ????I  EVelvetEyebrows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:VelvetEyebrows.viewVelvetEyebrows.view  5      &     VelvetEyebrows.view.ServicesPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:VelvetEyebrows.view     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N?Name$  servicesPage??5       N? Title$ ServicesPage??5       ? DataContext 5   	   ??  ?? Mode$ OneWay=? ?? RelativeSource ?? *Self+.??5      ]? .+?5   
   ?? $	??Top=?6   $??35(?6%   $
??Bold"?63   $??Услуги??6E   $??0 0 0 25q?6V   ?? 5   
    ?? Orientation$ 
Horizontal=?6      SecondaryHueMidBrush#???   5      $	??Top=?5      .+?5      ?? $??Поиск: ??6   $??18(?6&   $??Center=?64   ?? 5      -   5         ??Name$ searchTextBox??5   "   $	??200??6    ! MaterialDesignOutlinedTextBox#???  69   6q   ?? 5      $,??&Сортировать по цене: ??6   $??10 0 0 0q?64   $??Center=?5      ?? 5      -   5         ??Name$ sortingComboBox??5   \   $	??150??6    " MaterialDesignOutlinedComboBox#???  6#   ??5      ?? 5      .R?5      ?? ??6    ?? *Key+5      .@?5      ?? $!??Не сортировать??6   ?? 5      $#??По возрастранию??6   ?? 5       $??По убыванию??6   5!      ?? 5"      $.??(Фильтрация по скидке: ??6   $??10 0 0 0q?65   $??Center=?5#      ?? 5$      -   5        $ filterComboBox??5$   ?   $	??150??6W   #???  6c   ??6   ?? *DiscountFilters+??5%      ?? 5&      .R?5'      ?? ??6    ?? *Key+5(      5*      ?? 5+      -   5        $??20 0 0 0q?5+       % !MaterialDesignOutlinedLightButton#???  6'   y?6~   ??  ?? ElementName$ servicesPage??	 ?? Path$	 IsAdmin?   BooleanToVisibilityConverter
 ?? 	Converter#
 [ .??5,      ?? $ 
Horizontal=?6   .+?5-      '  !MaterialDesignThemes.Wpf.PackIcon  $??25??6.   $??25??6:      Kind$ DatabaseAdd=?6E   $	??5 0q?6X   ?? 5.        MaterialDesignTextBlock#???  6    Добавить6\   5/      50      51      ?? 52   
   $??Bottom=?6   #???   6,   .@?53      ?? Показано ?? 54      ?6   ?? *CurrentCount+ из ?? 6<   ?6@   ?? *
TotalCount+ записей55      56      ?? 57   
   -   5         ??Name$ searchResultLabel??57      $	??Top=?6+   $4??.Введите поисковый запрос??6@   ?? 59   
   $??Disabled=?6`   ??6   ?? *
Services+??5:      ?? 5;      .R?5<      ? $	??800??6   ??6'   ?? *
Discount+  discountToColorConverter#
 [  ? ColumnDefinitions 5=      ?? 5>      $	??150 ?6/   ?? 5?      ?? 5@      $	??100 ?6/   .+?5B      ?? $	??150??6    $	??150??6,   $??UniformToFill=?69   ??6Q   ?? *MainImagePath+  imageConverter#
 [ ?? 5C      $??7q?6%   $??1??60   .+?5D      ?? $??22(?6(   $
??Wrap=?66   ?? 5E   "   $??SemiBold"?6&   ?6<   ?? *Title+?? 5F   "   ?? 5G   #   ?6'   ?? *Cost+ ?? StringFormat$ {0:0.00}?? ?? TextDecorations 6V   ?? *
Discount+  discountToStrokeConverter#
 [  ?? 5H   "    	 discountText#??? 	 6,   ??6U   ?? *CostWithDiscount+$ OneWay=?$ {0:0.00}?? рублей за ?? 5J   "   ?6&   ?? *DurationInMunites+$ OneWay=? минут?? 5K   ,   ?? 5L   "   $??14(?6,   #??? 	 6:   * скидка ?? 5N   "   ?6&   ?? *
Discount+ 
 converterDiscount#
 [
  %5O   #   5P      ?? 5Q      -   5        $??20q?5Q   &   $??Записать??62   y?6E   ?? $ servicesPage??$	 IsAdmin?#
 [ 6?    ? 	Resources 5R       ?? 
TargetType ?? Triggers ?? Binding ?? Value ?? Property ?? Value??%?   &		       ?? 5S   "   " ??6(    5T   &   ?? 5U   *    66   ?? *
Discount+ 06S   .a?5V   .   ??  ? y?$ 	Collapsed=?6K   5W   +   5Y   #   5Z      5[      ?? 5\      $??2??6%   $??3q?65   $	??Top=?6A   y?6Y   ?? $ servicesPage??$	 IsAdmin?#
 [ .+?5]      ?? -   5        $??0 0 0 2q?5]   %     MaterialDesignFlatButton#???  66   .??5^   "     $
 Edit=?6:   5_      ?? 5`      -	   5        #???  5`   ;   .??5a   "     $ Remove=?6:   5b      5c      5d      5e      ??5h      ?? 5i      .R?5j      ? 5k      5n      5o      5p      