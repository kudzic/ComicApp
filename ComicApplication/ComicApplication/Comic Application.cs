using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace ComicApplication
{

    public partial class Form1 : Form
    {
        public int comicnumber = 1;
        public void proc()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://xkcd.com/" + comicnumber + "/info.0.json");
                var result = client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
                post post = JsonConvert.DeserializeObject<post>(result);
                pb1.Load(post.Img);
                lb2.Text=post.Title;
                lb3.Text = post.Transcript;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comicnumber > 0)
            {
                comicnumber++;
                proc();
              
            }
            else
            {
                MessageBox.Show("You cannot see that comic book Stranger ");
            }
          
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if(comicnumber >= 1)
            {
                comicnumber--;
                proc();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
           int a= random.Next(614);
            if(a>=1 && a <= 614)
            {
                comicnumber = a;
                proc();
            }

        }
    }
}
