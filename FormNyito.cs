using Kovacs_Istvan_01_console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kovacs_Istvan_01_GUI
{
    public partial class FormNyito : Form
    {
        Database db = new Database();
        public FormNyito()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            updateBefizetesek();
            updateUgyfelek();
        }

        private void updateUgyfelek()
        {
            lbUgyfelek.Items.Clear();
            lbUgyfelek.Items.AddRange(db.getUgyfel().ToArray());
        }

        private void updateBefizetesek()
        {
            lbBefiztesek.Items.Clear();
            lbBefiztesek.Items.AddRange(db.getBefizetes().ToArray());
        }

        private void btnBefizet_Click(object sender, EventArgs e)
        {
            if (lbUgyfelek.SelectedIndex < 0)
            {
                MessageBox.Show("Nem választott ki ügyfelet!");
                return;
            }
            int osszeg = Convert.ToInt32(nudBefizetes.Value);
            int befizetesAzon = ((Ugyfel)lbUgyfelek.SelectedItem).Azon;

            MessageBox.Show($"{befizetesAzon}:\t{osszeg}");
            db.insertBefizetes(befizetesAzon, osszeg);
        }
    }
}
