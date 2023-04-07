
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
    public partial class AgencyManagement : Form
    {
        SenLandContext db = new SenLandContext();
        public AgencyManagement()
        {
            InitializeComponent();
        }
        void loadData()
        {
            SenLandContext db = new();
            var list = from c in db.Agencies select new { AgencyId = c.AgencyId, Agencyname = c.AgencyName, Phone = c.AgencyPhone, Gender = c.Gender, Password = c.Password};
            dataGridView1.DataSource = list.ToList();
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            loadData();
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Agencyname"));
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Phone"));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Gender"));
            textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Password"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agency lt = new();
            lt.AgencyName = textBox1.Text;
            lt.AgencyPhone = textBox2.Text;
            lt.Gender = bool.Parse(textBox3.Text);
            lt.Password = textBox4.Text;
            db.Agencies.Add(lt);
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int agencyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Agency lt = db.Agencies.Find(agencyID);
            lt.AgencyName = textBox1.Text;
            lt.AgencyPhone = textBox2.Text;
            lt.Gender = bool.Parse(textBox3.Text);
            lt.Password = textBox4.Text;
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int agencyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Agency lt = db.Agencies.Find(agencyID);
            var list = from re in db.Reservations where re.AgencyId == agencyID select re;
            foreach (var item in list)
            {
                db.Reservations.Remove(item);
                db.SaveChanges();
            }
            db.Agencies.Remove(lt);
            db.SaveChanges();
        }

        private void AgencyManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
