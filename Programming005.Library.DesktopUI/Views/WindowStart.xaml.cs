using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Programming005.Library.Core;
using Programming005.Library.Core.Factories;
using Programming005.Library.DesktopUI.Utils;
using Programming005.Library.DesktopUI.ViewModel;

namespace Programming005.Library.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        public WindowStart()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Configuration currentConfig = Configuration.Get();

            if(currentConfig == null || currentConfig.Database == null)
            {
                DbConfigurationWindow window = new DbConfigurationWindow();
                window.DataContext = new DbConfigurationViewModel(window);
                window.Show();
                this.Close();
            }
            else
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.InitialCatalog = currentConfig.Database;
                builder.DataSource = currentConfig.Server;
                builder.IntegratedSecurity = currentConfig.IntegratedSecurity;

                if (currentConfig.IntegratedSecurity == false)
                {
                    builder.UserID = currentConfig.Username;
                    builder.Password = currentConfig.Password;
                }

                if (CheckSqlConnection(builder.ConnectionString))
                {
                    Kernel.DB = DbFactory.GetDb(new DbSettings
                    {
                        ConnectionString = builder.ConnectionString,
                        DbType = currentConfig.DbType
                    });

                    LoginWindow window = new LoginWindow();
                    window.DataContext = new LoginViewModel();
                    window.Show();
                    this.Close();
                }
                else
                {
                    DbConfigurationWindow window = new DbConfigurationWindow();
                    window.DataContext = new DbConfigurationViewModel(window);
                    window.Show();
                    this.Close();
                }
            }
        }

        private bool CheckSqlConnection(string connectionString)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
