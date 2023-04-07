using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LandManageMent.Models1;
namespace LandManageMent
{
    public partial class ReservationManement : Form
    {
        SenLandContext db = new();
        public ReservationManement()
        {
            InitializeComponent();
        }
        void loadData()
        {
            var list = from c in db.Reservations select new { ResID = c.ResId, OnerName = c.Oner.OnerName, Agency = c.Agency.AgencyName, House = c.Land.LandName ,Date = c.Date};
            dataGridView1.DataSource = list.ToList();
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            loadData();
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "OnerName"));
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Agency"));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "House"));
            textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Date"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int ResID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //Reservation resn = new();
            //Reservation res_Complte = new();
            //var res = (from r in db.Reservations where r.ResId == ResID select r);

            //foreach(var r in res)
            //{
            //    resn = r;
            //}
            //resn.OnerId = res_Complte.OnerId;
            //resn.AgencyId = res_Complte.AgencyId;
            //resn.LandId= res_Complte.LandId;
            //db.Reservations.Add(res_Complte);
            //db.SaveChanges();
            AddReservation ar = new();
            ar.Show();

            //int ResID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //Reservation res = db.Reservations.Find(ResID);
            //Reservation r = new();
            //r.OnerId = res.OnerId;
            //r.AgencyId = res.AgencyId;
            //r.LandId = res.LandId;
            //db.Reservations.Add(r);
            //db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ResID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Reservation res = db.Reservations.Find(ResID);
            res.OnerId = res.OnerId;
            Oner o = db.Oners.Find(res.OnerId);
            o.OnerName = textBox1.Text;
            res.AgencyId = res.AgencyId;
            Agency a = db.Agencies.Find(res.AgencyId);
            a.AgencyName = textBox2.Text;
            res.LandId = res.LandId;
            LandTable lt = db.LandTables.Find(res.LandId);
            lt.LandName = textBox3.Text;
            res.Date = DateTime.Parse(textBox4.Text);
            db.SaveChanges(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ResID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Reservation res = db.Reservations.Find(ResID);
            db.Reservations.Remove(res);
            db.SaveChanges();
        }

        private void ReservationManement_Load(object sender, EventArgs e)
        {

        }
    }
}
