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
    public partial class HouseManagement : Form
    {
        SenLandContext db = new SenLandContext();
        public HouseManagement()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void loadData()
        {
            SenLandContext db = new();
            var list = from c in db.LandTables select new { LandId = c.LandId, House = c.LandName, Location = c.Location, status = c.Status };
            dataGridView1.DataSource = list.ToList();
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            loadData();
            ////textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "House"));
            ////textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Location"));
            ////textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Status"));
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "House"));
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Location"));
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Status"));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LandTable lt = new();
            lt.LandName = textBox1.Text;
            lt.Location = textBox2.Text;
            lt.Status = bool.Parse(textBox3.Text);
            db.LandTables.Add(lt);
            db.SaveChanges();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int landId = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["LandID"].Value.ToString());
            LandTable lt = db.LandTables.Find(landId);
            db.LandTables.Remove(lt);
            db.SaveChanges();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int landId = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["LandID"].Value.ToString());
            LandTable lt = db.LandTables.Find(landId);
            lt.LandName = textBox1.Text;
            lt.Location = textBox2.Text;
            lt.Status = bool.Parse(textBox3.Text);
            db.SaveChanges();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
            
        }

        private void HouseManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
