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
using System.Xml.Linq;

namespace LandManageMent
{
    public partial class Oners : Form
    {
        SenLandContext db = new();
        public Oners()
        {
            InitializeComponent();
        }
        void loadData()
        {
            SenLandContext db = new();
            var list = from c in db.Oners select new { OnerId = c.OnerId, OnerName = c.OnerName, Dob = c.Dob, Phone = c.Phone, House = c.Land.LandName, Location = c.Land.Location };
            dataGridView1.DataSource = list.ToList();
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
             loadData();
             textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "onername"));
             textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "dob"));
             textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "phone"));
             textBox5.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "house"));
             textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource,  "location"));
        }

        private void Oners_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LandTable land = new();
            land.LandName = textBox5.Text;
            land.Location = textBox4.Text;
            db.Add(land);
            db.SaveChanges();
            int id = 0;
            var list = from c in db.LandTables where c.LandName == textBox5.Text select c;
            foreach (var item in list)
            {
                id = item.LandId;
            }
                     
            
            Oner o = new();
            o.OnerName= textBox1.Text;
            o.Dob = DateTime.Parse(textBox2.Text);
            o.Phone = textBox3.Text;
            o.LandId = id;

            db.Add(o); db.SaveChanges();
            loadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["OnerID"].Value.ToString());
            Oner o = db.Oners.Find(id);
            o.OnerName = textBox1.Text;
            o.Dob = DateTime.Parse(textBox2.Text);
            o.Phone = textBox3.Text;
            int landId1 = 0;
            var landList = from p in db.Oners
                           where p.OnerId == id
                           select p.LandId;
            foreach (var item in landList)
            {
                landId1 = item;
            }
            LandTable land = db.LandTables.Find(landId1);
            land.LandName = textBox5.Text;
            land.Location = textBox4.Text;

            db.SaveChanges(true);
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["OnerID"].Value.ToString());
            Oner o = db.Oners.Find(id);
            // delete record in reservations table has foreign key onerid
            var list = from p in db.Reservations where p.OnerId == id select p;
            foreach (var item in list)
            {
                db.Reservations.Remove(item);
                db.SaveChanges(true);
            }
            db.Oners.Remove(o);
            db.SaveChanges();
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String name = textBox6.Text;
            var listOwner = new List<Oner>();
            if(name == null)
            {
                loadData();
            }
            else
            {
                var list = db.Oners.ToList();
                foreach (var item in list)
                {
                    if (item.OnerName.Equals(name))
                    {
                        listOwner.Add(item);
                    }
                }
            }

            dataGridView1.DataSource = listOwner;
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String name = textBox7.Text;
            var listOwner = new List<Oner>();
            if (name == null)
            {
                loadData();
            }
            else
            {
                var list = db.Oners.ToList();
                foreach (var item in list)
                {
                    if (item.OnerName.Contains(name))
                    {
                        listOwner.Add(item);
                    }
                }
            }

            dataGridView1.DataSource = listOwner;
        }
    }
}
