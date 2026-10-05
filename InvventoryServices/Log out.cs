using System;
using System.Windows.Forms;

namespace InvventoryServices
{
    public class Logout
    {
        public static void Execute(Form currentForm)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var loginForm = new Form1
                {
                    StartPosition = FormStartPosition.CenterScreen
                };

                currentForm.Hide();
                loginForm.Show();
            }
        }
    }
}