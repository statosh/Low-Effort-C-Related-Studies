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
    public partial class NamesForm : Form {
        public NamesForm(List<string> names) {
            InitializeComponent();
            foreach (var name in names) {
                listBoxNames.Items.Add(name);
            }
        }
    }
}
