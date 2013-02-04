using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (MainLibrary.getInstance().connect())
            {
                listSiswa.Items.Clear();
                foreach (Siswa siswa in MainLibrary.getInstance().siswaCol.FindAllAs<Siswa>())
                {
                    listSiswa.Items.Add(siswa.nama);
                }
                siswaToolStripMenuItem.Enabled = true;
                lblInfoEmpty.Text = "Pilih nama siswa untuk menampilkan detailnya"; 
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Sorry, ada kesalahan koneksi. Belum bayar pulsa internet kali mas?", Application.ProductName);
            }
        }

        private void listSiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSiswa.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                IMongoQuery query = Query.EQ("nama", listSiswa.Text);
                Siswa detailSiswa = MainLibrary.getInstance().siswaCol.FindOneAs<Siswa>(query);
                pnlDetail.Controls.Clear();
                pnlDetail.BackgroundImage = null;
                pnlDetail.Controls.Add(new SiswaProperty(detailSiswa, this));
                this.Cursor = Cursors.Default;
            }
            else
            {
                pnlDetail.Controls.Clear();
                pnlDetail.BackgroundImage = new Bitmap(SenzalaYogyakartaManajemenSiswa.Properties.Resources.senzalajogja);
                lblInfoEmpty.Text = "Pilih nama siswa untuk menampilkan detailnya";
                pnlDetail.Controls.Add(lblInfoEmpty);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tambahToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            listSiswa.Items.Add("*new*");
            listSiswa.SelectedIndex = listSiswa.Items.Count - 1;
        }


        internal void updateListSiswa(string p)
        {
            listSiswa.Items[listSiswa.SelectedIndex] = p;
        }

        internal void batal()
        {
            if(listSiswa.Text=="*new*")
            {
                listSiswa.Items.RemoveAt(listSiswa.SelectedIndex);
            }
            listSiswa.SelectedIndex = -1;
        }

        private void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bener mau dihapus?", Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MainLibrary.getInstance().siswaCol.Remove(Query.EQ("nama", listSiswa.Text));
                listSiswa.Items.RemoveAt(listSiswa.SelectedIndex);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();

        }

       
    }
}
