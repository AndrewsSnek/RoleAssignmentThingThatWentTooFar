using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace thisIsGoingToFar
{
    public partial class Form1 : Form
    {
        public List<string> selectedRoleList = new List<string>();
        public string[] possibleRoleList;

        private int playerCount = 0;
        private int roleCount   = 0;

        public Form1(string[] roles)
        {
            possibleRoleList = roles;
            InitializeComponent();
            updateSelectedRoleGUI();
            updatePossibleRoleTable();
            roleCount = listBox1.Items.Count + decimal.ToInt32(numericUpDown1.Value);
            playerCount = richTextBox1.Text.Split('\n').Count();
            updateCounts();
        }

        public void submit()
        {
            List<string> _selectedRoleList = new List<string>();
            for (int i = 0; i < numericUpDown1.Value; i++) { _selectedRoleList.Add("Mechon"); }
            foreach (string item in selectedRoleList) { _selectedRoleList.Add(item); }
            Form2 resultForm = new Form2(richTextBox1.Text, _selectedRoleList);
            resultForm.Show();
        }

        /// <summary>
        /// Updates the displayed roleList
        /// </summary>
        private void updateSelectedRoleGUI()
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            for (int i = 0; i < selectedRoleList.Count(); i++)
            {
                listBox1.Items.Add(selectedRoleList[i]);
            }
            listBox1.EndUpdate();
        }

        private void updatePossibleRoleTable()
        {
            checkedListBox1.BeginUpdate();
            checkedListBox1.Items.Clear();
            for (int i = 0; i < possibleRoleList.Count(); i++)
            {
                checkedListBox1.Items.Add(possibleRoleList[i]);
            }
            checkedListBox1.EndUpdate();
        }

        private void deleteSelectedOnRoleGUI()
        {
            var selected = listBox1.SelectedItems;
            foreach (string item in selected)
            {
                selectedRoleList.Remove(item);
            }
            updateSelectedRoleGUI();
        }

        private void addSelectedRoles()
        {
            var selected = checkedListBox1.CheckedItems;
            foreach (string item in selected)
            {
                selectedRoleList.Add(item);
            }
            checkedListBox1.BeginUpdate();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            checkedListBox1.EndUpdate();
            updateSelectedRoleGUI();
        }

        private void updateCounts()
        {
            label2.Text = string.Format("Number Of Players: {0}\nNumber Of Roles: {1}",
                                        playerCount.ToString(), roleCount.ToString());

            if (playerCount != roleCount)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //load bareing blank function?
        }

        private void button1_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //load bareing blank function?
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //load bareing blank function?
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteSelectedOnRoleGUI();
            roleCount = listBox1.Items.Count + decimal.ToInt32(numericUpDown1.Value);
            updateCounts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addSelectedRoles();
            roleCount = listBox1.Items.Count + decimal.ToInt32(numericUpDown1.Value);
            updateCounts();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            playerCount = richTextBox1.Text.Split('\n').Count();
            updateCounts();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            addSelectedRoles();
            roleCount = listBox1.Items.Count + decimal.ToInt32(numericUpDown1.Value);
            updateCounts();
        }
    }
}
