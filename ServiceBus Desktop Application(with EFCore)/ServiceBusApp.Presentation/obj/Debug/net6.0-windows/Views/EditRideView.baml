   M S B A M L   `   `   `  ����U  QServiceBusApp.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ServiceBusApp.Presentation.Views ServiceBusApp.Presentation.Views  5      ]3clr-namespace:ServiceBusApp.Presentation.ViewModels%ServiceBusApp.Presentation.ViewModels  5      3    -ServiceBusApp.Presentation.Views.EditRideView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:ServiceBusApp.Presentation.Views     5      I	viewModel3clr-namespace:ServiceBusApp.Presentation.ViewModels     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      �� 5      $��3* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ Student_list��5   $   $��0��6   ��6:   �� *
Students+ �� SelectedItem 6[   �� *SelectedStudent+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Center=�6G   �� 5       � ��$ 20(�65   �� 5       � ��$ DemiBold"�67   5       �� View 5      �� 5      .P�5      �� $��
Student Id��6M    �� DisplayMemberBinding 6)   �� *Id+6d   �� 5       $��
First Name��6T    6)   �� *	FirstName+6k   �� 5!      $��	Last Name��6S    6)   �� *
LastName+6i   �� 5"      $��CreationTime��6W    6)   �� *CreationTime+6p   �� 5#      $��LastModifiedTime��6[    6)   �� *LastModifiedTime+6x   �� 5$      $��Parent��6Q    6)   �� *Parent+6d   �� 5%      $��
Class Name��6U    6)   �� *
Class.Name+6l   �� 5&      $��Actions��6)   	 �� CellTemplate	 5'      �� 5(   "   .R�5)   &   �� 
 ��Name$
 AddStudents_Btn��5*   (   $��10q�5-   )   $��30��5/   )   $��30��50   )   
���W�.�{�5+   (   ��  �� Path$ 
IsSelected� �� RelativeSource �� *FindAncestor+ �� AncestorType" ����5.   )   �� *DataContext.AddStudentCommand+ �� ElementName$ Student_list��.��53   *   �� $[��Uhttps://icons.veryicon.com/png/o/miscellaneous/o2o-middle-school-project/plus-104.png��60   54   '   55   #   57      58      5:      �� 5;      -   5        $ RideStudent_list��5;      $��1��61   ��6>   �� *TempStudents+ 6c   �� *SelectedStudent+��5<      �� 5=      " ��6   .�5>      ��  � ��$ Center=�6G   �� 5?       � ��$ 20(�65   �� 5@       � ��$ DemiBold"�67   5A       5C      �� 5D      .P�5E      �� $��
Student Id��6M    6)   �� *Id+6d   �� 5F      $��
First Name��6T    6)   �� *	FirstName+6k   �� 5G      $��	Last Name��6S    6)   �� *
LastName+6i   �� 5H      $��CreationTime��6W    6)   �� *CreationTime+6p   �� 5I      $��LastModifiedTime��6[    6)   �� *LastModifiedTime+6x   �� 5J      $��Parent��6Q    6)   �� *Parent+6d   �� 5K      $��
Class Name��6U    6)   �� *
Class.Name+6l   �� 5L      $��Actions��6)   	 5M      �� 5N   "   .R�5O   &   �� $
 RemoveStudent_Btn��5P   (   $��10q�5S   )   $��30��5T   )   $��30��5U   )   
���W�.�{�5Q   (   �� $ 
IsSelected� �� *FindAncestor+" ����5W   )   �� *" DataContext.RemoveStudentCommand+$ RideStudent_list��.��5Y   *   �� $=��7https://cdn-icons-png.flaticon.com/512/3405/3405244.png��60   5Z   '   5[   #   5]      5^      5`      5a      �� 5b   
   $��Center=�6   $��Center=�62   .+�5c      �� $��	ExtraBold"�6   $��35(�6+   $��Center=�69   .��6V   Ride6\   �� 5d       �� Orientation$ 
Horizontal=�6   .+�5e      �� .��6   Driver Name :6'   �� 5f      ��6   �� *SelectedDriver.FirstName+6G   5g      �� 5h      $ 
Horizontal=�6   .+�5i      �� .��6   
Car Name :6$   �� 5j      ��6   �� *SelectedDriver.Car.Name+6F   5k      �� 5l      $ 
Horizontal=�6   .+�5m      �� .��6   Car Serial number :6-   �� 5n      ��6   �� *SelectedDriver.Car.CarNumber+6K   5o      �� 5p      $ 
Horizontal=�6   .+�5q      �� .��6   Students Attend :6+   �� 5r      ��6   �� *StudentCount+6;   5s      �� 5t      $ 
Horizontal=�6   .+�5u      �� .��6   Max Seats :6%   �� 5v      ��6   �� *SelectedDriver.Car.SeatCount+6K   5w      �� 5x      ��6   �� *	Drivers+ 67   �� *SelectedDriver+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5z      �� 5{      $��10q�6   ��6!   �� *SaveRideCommand+.��6E   Save6K   5|      5}      5~      