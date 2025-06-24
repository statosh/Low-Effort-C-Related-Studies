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
    public partial class SurnamesForm : Form {
        public SurnamesForm(List<string> surnames) {
            InitializeComponent();
            foreach (var surname in surnames) {
                listBoxSurnames.Items.Add(surname);
            }
        }
    }
}
