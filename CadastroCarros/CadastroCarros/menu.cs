using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroCarros
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void adicionarCarroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addcarro add = new addcarro();
            add.ShowDialog();
        }
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

 

    }
}
