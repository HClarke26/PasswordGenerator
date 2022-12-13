using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        int currentPassworsLength = 0;
        Random character = new Random();

        private void passwordGenerator(int passwordLength)
        {
            String allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!!£$%^&*(),./";
            String randomPassword = "";

            for (int i = 0; i < passwordLength; i++)
            { 
                int randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum];
            }
            PasswordLabel.Text = randomPassword;
        }

        public Form1()
        {
            InitializeComponent();
            PasswordLengthSlider.Minimum = 5;
            PasswordLengthSlider.Maximum = 20;
            passwordGenerator(5);
        }

        private void CopyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(PasswordLabel.Text);
        }

        private void PasswordLengthSlider_Scroll(object sender, EventArgs e)
        {
            PasswordLengthLabel.Text = "Password Length: " + PasswordLengthSlider.Value.ToString();
            currentPassworsLength = PasswordLengthSlider.Value;
            passwordGenerator(currentPassworsLength);
        }
    }
}
