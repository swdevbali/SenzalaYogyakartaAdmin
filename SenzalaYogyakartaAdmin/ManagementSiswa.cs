using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenzalaYogyakartaAdmin
{
    public partial class ManagementSiswa : Form
    {
        
    
        public ManagementSiswa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MainLibrary.getInstance().connect();
            listSiswa.Items.Clear();
            foreach (Siswa siswa in MainLibrary.getInstance().siswaCol.FindAllAs<Siswa>())
            {
                listSiswa.Items.Add(siswa.nama);
            }
            this.Cursor = Cursors.Default;
        }

        private void listSiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSiswa.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                IMongoQuery query = Query.EQ("nama", listSiswa.Text);
                Siswa detailSiswa = MainLibrary.getInstance().siswaCol.FindOneAs<Siswa>(query);
                pnlDetail.Controls.Clear();
                pnlDetail.Controls.Add(new SiswaProperty(detailSiswa, this));
                this.Cursor = Cursors.Default;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tambahToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            listSiswa.Items.Add(new Siswa());
            listSiswa.SelectedIndex = listSiswa.Items.Count - 1;
        }


        internal void updateListSiswa(string p)
        {
            listSiswa.Items[listSiswa.SelectedIndex] = p;
        }
    }
}
