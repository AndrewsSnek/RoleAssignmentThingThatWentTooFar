using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thisIsGoingToFar
{
    public partial class Form2 : Form
    {
        List<string> roles;
        string[] players;
        Random rng;

        public Form2(string _players, List<string> _roles)
        {
            InitializeComponent();
            roles = _roles;
            players = _players.Split('\n');
            //players = players.OrderBy(x => rng.Next()).ToArray();
            for (int i = 0; i < roles.Count(); i++)
            {
                richTextBox1.Text += players[i] + "     " + roles[i] + "\n";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
