using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace thisIsGoingToFar
{
    public partial class Form2 : Form
    {
        List<string> roles;
        string[] players;
        Random rng = new Random();

        public Form2(string _players, List<string> _roles)
        {
            InitializeComponent();
            roles = _roles;
            players = _players.Split('\n');
            var shuffledPlayers = players.OrderBy(a => rng.Next()).ToList();
            int longest = findLongest(players);
            for (int i = 0; i < roles.Count(); i++)
            {
                if (roles[i] == "Tyrea")
                {
                    string randomPlayer = shuffledPlayers[i];
                    while ((randomPlayer == shuffledPlayers[i]) || ("Mechon" == roles[shuffledPlayers.IndexOf(randomPlayer)]))
                    {
                        randomPlayer = shuffledPlayers[rng.Next(0,shuffledPlayers.Count())];
                    }
                    richTextBox1.Text += fixlen(shuffledPlayers[i], longest - 5) + "   " + roles[i] + " ---> " + randomPlayer + "\n";
                }
                else
                {
                    richTextBox1.Text += fixlen(shuffledPlayers[i], longest) + "    " + roles[i] + "\n";
                }
            }
        }

        private int findLongest(string[] data)
        {
            int longest = 0;
            foreach (var item in data)
            {
                if (item.Length > longest) { longest = item.Length; }
            }
            return longest;
        }

        private string fixlen(string value, int targetLength)
        {
            while (value.Length > targetLength)
            {
                value = value.Substring(0, targetLength);
            }
            while (value.Length < targetLength)
            {
                value = value + " ";
            }
            return value;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
