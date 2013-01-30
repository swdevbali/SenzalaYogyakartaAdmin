using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
                    txtNoFormulir.Text = detailSiswa.no_formulir;
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
                    txtBeladiriYangPernahDiikuti.Text = detailSiswa.beladiri_sebelumnya;
                    txtMotivasi.Text = detailSiswa.motivasi;
                    txtTahuCapoeiraDari.Text = detailSiswa.tahu_capoeira_dari;
                    txtEmergencyCall.Text = detailSiswa.emergency_call_number;
                    cboKelas.Text = detailSiswa.kelas;
                    txtEmail.Text = detailSiswa.email;
                    txtFacebook.Text = detailSiswa.facebook;
                    txtTwitter.Text = detailSiswa.twitter;
                    cboLevel.Text = detailSiswa.level;
                    txtApilido.Text = detailSiswa.apilido;
                }
                txtNoFormulir.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (detailSiswa != null)
            {
                var update = MongoDB.Driver.Builders.Update.Set("motivasi", txtMotivasi.Text)
                    .Set("apilido", txtApilido.Text)
                    .Set("level", cboLevel.Text)
                    .Set("twitter", txtTwitter.Text)
                    .Set("email", txtEmail.Text)
                    .Set("facebook", txtFacebook.Text)
                    .Set("kelas", cboKelas.Text)
                    .Set("tgl_lahir", txtTanggalLahir.Value)
                    .Set("tempat_lahir", txtTempat.Text)
                    .Set("tahu_capoeira_dari", txtTahuCapoeiraDari.Text)
                    .Set("status_keterangan", cboStatusDi.Text)
                    .Set("status_golongan", cboStatusTipe.Text)
                    .Set("sex", cboSex.Text)
                    .Set("no_formulir", txtNoFormulir.Text)
                    .Set("keluhan_kesehatan", txtKeluhanKesehatan.Text)
                    .Set("hp", txtHp.Text)
                    .Set("gol_darah", cboGolDarah.Text)
                    .Set("emergency_call_number", txtEmergencyCall.Text)
                    .Set("beladiri_sebelumnya",txtBeladiriYangPernahDiikuti.Text)
                    .Set("alamat_jogja",txtAlamatJogja.Text)
                    .Set("alamat_asal",txtAlamatAsal.Text)
                    .Set("nama",txtNama.Text)
                    ;
                MainLibrary.getInstance().siswaCol.Update(Query.EQ("_id", detailSiswa.Id), update);
            }
            else
            {
                detailSiswa = new Siswa();
                detailSiswa.no_formulir = txtNoFormulir.Text;
                detailSiswa.nama = txtNama.Text;
                detailSiswa.tempat_lahir = txtTempat.Text;
                detailSiswa.tgl_lahir = txtTanggalLahir.Value;
                detailSiswa.hp = txtHp.Text;
                detailSiswa.sex = cboSex.Text;
                detailSiswa.gol_darah = cboGolDarah.Text;
                detailSiswa.alamat_jogja = txtAlamatJogja.Text;
                detailSiswa.alamat_asal = txtAlamatAsal.Text;
                detailSiswa.status_golongan = cboStatusTipe.Text;
                detailSiswa.status_keterangan = cboStatusDi.Text;
                detailSiswa.keluhan_kesehatan = txtKeluhanKesehatan.Text;
                detailSiswa.beladiri_sebelumnya = txtBeladiriYangPernahDiikuti.Text;
                detailSiswa.motivasi = txtMotivasi.Text;
                detailSiswa.tahu_capoeira_dari = txtTahuCapoeiraDari.Text;
                detailSiswa.emergency_call_number = txtEmergencyCall.Text;
                detailSiswa.kelas = cboKelas.Text;
                detailSiswa.email = txtEmail.Text;
                detailSiswa.facebook = txtFacebook.Text;
                detailSiswa.twitter = txtTwitter.Text;
                detailSiswa.level = cboLevel.Text;
                detailSiswa.apilido = txtApilido.Text;
                MainLibrary.getInstance().siswaCol.Insert<Siswa>(detailSiswa);
            }
            managementSiswa.updateListSiswa(txtNama.Text);
            Cursor = Cursors.Default;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            managementSiswa.batal();
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (System.IO.File.Exists(openFileDialog1.FileName))
            {
                picFoto.Load(openFileDialog1.FileName);
                MessageBox.Show("Under construction mas bro. Masih belum saya save");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            picFoto_Click(sender, e);
        }
    }
}
