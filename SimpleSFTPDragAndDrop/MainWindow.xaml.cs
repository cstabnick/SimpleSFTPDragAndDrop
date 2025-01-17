﻿using System.Windows;
using System.Windows.Controls;

namespace SimpleSFTPDragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VM myVm;
        public MainWindow()
        {
            myVm = new VM();
            DataContext = myVm;
            InitializeComponent();
        }

        private void ImagePanel_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                myVm.Files.Clear();
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                    myVm.Files.Add(file);
                myVm.OnPropertyChanged("Files");
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            myVm.OnDrop();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox)
            {
                var pwBox = (PasswordBox)sender;
                myVm.Password = pwBox.Password;
            }
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            myVm.Files.Clear();
            myVm.OnPropertyChanged("Files");

        }
    }
}