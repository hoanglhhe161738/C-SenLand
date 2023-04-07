using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LandManageMent.Models1;

namespace LandManageMent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread t2 = new Thread(() =>
            //{
            //    HomePage hp = new();
            //    hp.Show();
            //});

           
                SenLandContext db = new SenLandContext();
                var list = db.Agencies.ToList();
                foreach (var item in list)
                {
                    if (item.AgencyName == textBox1.Text && item.Password == textBox2.Text)
                    {
                        
                        HomePage hp = new();
                        hp.Show();
                        this.Hide();
                       break;
                    }
                    else
                    {
                        MessageBox.Show("Wrong username and password");
                        break;
                    }
                }
          

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}