using MongoDB.Driver;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "mongodb://swdev:muhammad@linus.mongohq.com:10030/senzalayogyakarta";
            MongoClient client = new MongoClient(connectionString);
            MongoServer  server = client.GetServer();
            MongoDatabase db = server.GetDatabase("senzalayogyakarta");
            MongoCollection siswa = db.GetCollection("siswa");
            MessageBox.Show(siswa.Count() + "");
        }
    }
}
