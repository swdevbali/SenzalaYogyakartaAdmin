using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SenzalaYogyakartaAdmin
{
    public class Siswa
    {
        public ObjectId Id { get; set; }
        public string nama { get; set; }
        public string alamat_asal { get; set; }
        public string alamat_jogja { get; set; }
        public List<string> beladiri_sebelumnya { get; set; }
        public string emergency_call_number { get; set; }
        public string emergency_call_status { get; set; }
        public string gol_darah { get; set; }
        public string hp { get; set; }
        public string keluhan_kesehatan { get; set; }
        public string motivasi { get; set; }
        public string no_formulir { get; set; }
        public string sex { get; set; }
        public string status_golongan { get; set; }
        public string status_keterangan { get; set; }
        public string tahu_capoeira_dari { get; set; }
        public string tempat_lahir { get; set; }
        public DateTime tgl_lahir { get; set; }


    }
}
