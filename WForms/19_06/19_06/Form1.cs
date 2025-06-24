using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_06 {
    public partial class Form1 : Form {

        private List<string> passwordList = new List<string>();

        public Form1() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            int length = (int)numericLength.Value;
            int letters = (int)numericLetters.Value;
            int digits = (int)numericDigits.Value;
            int special = (int)numericSpecial.Value;

            if (letters + digits + special != length) {
                MessageBox.Show("Сумма символов должна равняться длине пароля.");
                return;
            }

            string password = GeneratePassword(letters, digits, special);
            passwordList.Add(password);
            txtResult.Text = password;
        }

        private string GeneratePassword(int letters, int digits, int special) {
            const string latin = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string nums = "0123456789";
            const string specials = "@#+-()?!";

            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            sb.Append(RandomChars(latin, letters, rand));
            sb.Append(RandomChars(nums, digits, rand));
            sb.Append(RandomChars(specials, special, rand));

            char[] array = sb.ToString().ToCharArray();
            for (int i = array.Length - 1; i > 0; i--) {
                int j = rand.Next(i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            return new string(array);
        }

        private string RandomChars(string pool, int count, Random rand) {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++) {
                result.Append(pool[rand.Next(pool.Length)]);
            }
            return result.ToString();
        }

        private void btnShowList_Click(object sender, EventArgs e) {
            PasswordListForm listForm = new PasswordListForm(passwordList);
            listForm.Show();
        }

        private void numeric_ValueChanged(object sender, EventArgs e) {
            int total = (int)numericLength.Value;

            if (numericLetters.Focused && numericDigits.Value + numericSpecial.Value <= total) {
                numericLetters.Value = total - numericDigits.Value - numericSpecial.Value;
            } else if (numericDigits.Focused && numericLetters.Value + numericSpecial.Value <= total) {
                numericDigits.Value = total - numericLetters.Value - numericSpecial.Value;
            } else if (numericSpecial.Focused && numericLetters.Value + numericDigits.Value <= total) {
                numericSpecial.Value = total - numericLetters.Value - numericDigits.Value;
            }
        }

    }
}
