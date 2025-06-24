using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_06 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void UpdateSelectedElementInfo(object sender, EventArgs e) {
            if (listBox_MainBox.SelectedIndex == -1) {
                textBox_InfoBox.Text = "Элемент не выбран";
                return;
            }
            string selectedElement = (string)listBox_MainBox.SelectedItem;
            textBox_InfoBox.Text = "Элемент: " + selectedElement;
            button_RemoveElement_Enabled();
        }
        private void AddLog(string logMesage) {
            textBox_LogBox.Text += logMesage + "\r\n";
        }
        private void Form1_Load(object sender, EventArgs e) {
            //listBox_MainBox.Items.Add("Первый");
            //listBox_MainBox.Items.Add("Второй");
            //listBox_MainBox.Items.Add("Третий");
            //listBox_MainBox.Items.Add("Четвёртый");
            //listBox_MainBox.Items.Add("Пятый");
            button_AddElement_Enabled();
            button_ClearListBox_Enabled();
            button_RemoveElement_Enabled();
        }


        private void ClearAddBox() {
            textBox_AddElement.ForeColor = Color.Gray;
            textBox_AddElement.Text = "Введите элемент для добавления";
        }
        private void button_AddElement_Click(object sender, EventArgs e) {
            listBox_MainBox.Items.Add(textBox_AddElement.Text);
            AddLog("Добавлен элемент: " + textBox_AddElement.Text);
            ClearAddBox();
            button_AddElement_Enabled();
            button_ClearListBox_Enabled();
            button_RemoveElement_Enabled();
        }
        private void button_AddElement_Enabled() {
            button_AddElement.Enabled = textBox_AddElement.Text != "" && textBox_AddElement.ForeColor != Color.Gray;
        }
        private void textBox_AddElement_MouseEnter(object sender, EventArgs e) {
            if (textBox_AddElement.ForeColor == Color.Gray) {
                textBox_AddElement.Text = "";
                textBox_AddElement.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox_AddElement_MouseLeave(object sender, EventArgs e) {
            if (textBox_AddElement.Text == "") {
                ClearAddBox();
            }
        }
        private void textBox_AddElement_TextChanged(object sender, EventArgs e) {
            button_AddElement_Enabled();
            button_RemoveElement_Enabled();
        }


        private void button_RemoveElement_Click(object sender, EventArgs e) {
            if (listBox_MainBox.SelectedItems != null) {
                AddLog("Удалён элемент: " + listBox_MainBox.SelectedItem);
                listBox_MainBox.Items.Remove(listBox_MainBox.SelectedItem);
            }
            button_ClearListBox_Enabled();
            button_RemoveElement_Enabled();
        }
        private void button_RemoveElement_Enabled() {
            button_RemoveElement.Enabled = listBox_MainBox.Items.Count > 0 && listBox_MainBox.SelectedItems != null;
        }

        private void button_ClearListBox_Click(object sender, EventArgs e) {
            listBox_MainBox.Items.Clear();
            button_ClearListBox_Enabled();
            button_RemoveElement_Enabled();
            AddLog("Список элементов очищен");
        }
        private void button_ClearListBox_Enabled() {
            button_ClearListBox.Enabled = listBox_MainBox.Items.Count > 0;
        }

        private void button_ClearLogs_Click(object sender, EventArgs e) {
            textBox_LogBox.Text = "";
        }
    }
}
