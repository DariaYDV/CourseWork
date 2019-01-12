using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;
using ComputersDBCW.Models;
using ComputersDBCW.Context;

namespace ComputersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new DatabaseContext();
            db.Computers.Load(); // загружаем данные
            computersGrid.ItemsSource = db.Computers.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Дарья\source\repos\ComputersDBCW\ComputersCA\bin\Debug\ComputersCA.exe");
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (computersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < computersGrid.SelectedItems.Count; i++)
                {
                    Computers computer = computersGrid.SelectedItems[i] as Computers;
                    if (computer != null)
                    {
                        db.Computers.Remove(computer);
                    }
                }
            }
            db.SaveChanges();
        }

        private void ComputersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
