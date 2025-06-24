using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_06_2 {
    public partial class Form1 : Form {
        private List<string> names = new List<string>();
        private List<string> surnames = new List<string>();

        public Form1() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname)) {
                MessageBox.Show("Введите и имя, и фамилию.");
                return;
            }

            bool isNew = false;

            if (!names.Contains(name)) {
                names.Add(name);
                isNew = true;
            } else {
                MessageBox.Show($"Имя '{name}' уже существует.");
            }

            if (!surnames.Contains(surname)) {
                surnames.Add(surname);
                isNew = true;
            } else {
                MessageBox.Show($"Фамилия '{surname}' уже существует.");
            }

            if (isNew) {
                txtName.Clear();
                txtSurname.Clear();
            }
        }

        private void btnShowNames_Click(object sender, EventArgs e) {
            NamesForm namesForm = new NamesForm(names);
            namesForm.Show();
        }

        private void btnShowSurnames_Click(object sender, EventArgs e) {
            SurnamesForm surnamesForm = new SurnamesForm(surnames);
            surnamesForm.Show();
        }
    }
}
