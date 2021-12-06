using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT2
{
    public partial class MainForm : Form
    {
        List<account> accountList = new List<account>();
        public MainForm()
        {
            InitializeComponent();
            accountList.Add(new account("admin", "123456"));
        }
        private void signinButton_Click(object sender, EventArgs e)
        {
            if (isValidAccount(username.Text, password.Text))
            {
                this.Hide();
                signInComplete_Form helloForm = new signInComplete_Form(username.Text);
                helloForm.ShowDialog();
                username.Text = null;
                password.Text = null;
                this.Show();
            }
            else
            {
                username.Text = null;
                password.Text = null;
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không hợp lệ, vui lòng thử lại");
            }
        }
        private void signUp_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupForm signUp = new signupForm();
            this.Hide();
            signUp.ShowDialog();
            if (isAvailable(signUp.user) && signUp.user != "")
            {
                MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng đăng ký lại");
                signUp.user = signUp.pass = "";
                signUp.ShowDialog();
                this.Show();
            }
            else
            {
                accountList.Add(new account(signUp.user, signUp.pass));
                this.Show();
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool isAvailable(string username)
        {
            for (int i = 0; i < accountList.Count; i++)
                if (username == accountList[i].Username)
                    return true;
            return false;
        }
        bool isValidAccount(string u, string p)
        {
            for (int i = 0; i < accountList.Count; i++)
                if (u == accountList[i].Username && p == accountList[i].Password)
                    return true;
            return false;
        }
    }
}
