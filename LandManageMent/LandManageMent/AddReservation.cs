using LandManageMent.Models1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandManageMent
{
    public partial class AddReservation : Form
    {
        SenLandContext db = new SenLandContext();
        public AddReservation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ResID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Reservation res = db.Reservations.Find(ResID);
            Reservation r = new();
            r.OnerId = res.OnerId;
            r.AgencyId = res.AgencyId;
            r.LandId = res.LandId;
            db.Reservations.Add(r);
            db.SaveChanges();
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Oners.ToList();
            //textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "OnerName"));
        }

        private void dataGridView2_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Oners.ToList();
           // textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "LandName"));
        }

        private void dataGridView3_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = db.Oners.ToList();
            //textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "AgencyName"));
        }

        private void AddReservation_Load(object sender, EventArgs e)
        {

        }
    }
}
