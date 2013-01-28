using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver.Builders;

namespace SenzalaYogyakartaAdmin
{
    public partial class SiswaProperty : UserControl
    {
        private Siswa detailSiswa;
        private ManagementSiswa managementSiswa;

        public SiswaProperty()
        {
            InitializeComponent();
        }

        public SiswaProperty(Siswa detailSiswa, ManagementSiswa managementSiswa)
        {
            try
            {
                // TODO: Complete member initialization
                this.detailSiswa = detailSiswa;
                this.managementSiswa = managementSiswa;
                InitializeComponent();
                if (detailSiswa != null)
                {
                    txtNama.Text = detailSiswa.nama;
                    txtTempat.Text = detailSiswa.tempat_lahir;
                    txtTanggalLahir.Value = detailSiswa.tgl_lahir;
                    txtHp.Text = detailSiswa.hp;
                    cboSex.Text = detailSiswa.sex;
                    cboGolDarah.Text = detailSiswa.gol_darah;
                    txtAlamatJogja.Text = detailSiswa.alamat_jogja;
                    txtAlamatAsal.Text = detailSiswa.alamat_asal;
                    cboStatusTipe.Text = detailSiswa.status_golongan;
                    cboStatusDi.Text = detailSiswa.status_keterangan;
                    txtKeluhanKesehatan.Text = detailSiswa.keluhan_kesehatan;
                    txtBeladiriYangPernahDiikuti.Text = detailSiswa.beladiri_sebelumnya.ToString();
                    txtMotivasi.Text = detailSiswa.motivasi;
                    txtTahuCapoeiraDari.Text = detailSiswa.tahu_capoeira_dari;
                    txtEmergencyCall.Text = detailSiswa.emergency_call_number;
                }
                txtNoFormulir.Focus();
            }
            catch (Exception ex)
            {   
            }
        }

        

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (detailSiswa != null)
            {
                var update = MongoDB.Driver.Builders.Update.Set("motivasi", txtMotivasi.Text);
                MainLibrary.getInstance().siswaCol.Update(Query.EQ("_id", detailSiswa.Id), update);
            }
            else
            {
                detailSiswa = new Siswa();
                detailSiswa.nama = txtNama.Text;
                MainLibrary.getInstance().siswaCol.Insert<Siswa>(detailSiswa);
                managementSiswa.updateListSiswa(detailSiswa.nama);
            }
            Cursor = Cursors.Default;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            
        }
    }
}
