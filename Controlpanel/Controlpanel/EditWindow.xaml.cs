using System;
using System.Windows;

namespace Controlpanel
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        CustomServerChecker CSC;


        public EditWindow(CustomServerChecker csc)
        {
            CSC = csc;
            InitializeComponent();
            customiptxt.Text = "";
            porttxt.Text = "";
            usernametxt.Text = "";
            passwordtxt.Text = "";
        }


        private void CreateServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string customIP = customiptxt.Text;
                int port = Convert.ToInt32(porttxt.Text);
                string username = usernametxt.Text;
                string password = passwordtxt.Text;
                CSC.CreateClient(customIP, port, username, password);
                MessageBox.Show("You've succesfully created your client.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You've entered something incorrectly!\n" + ex.Message);
            }
        }
    }
}
