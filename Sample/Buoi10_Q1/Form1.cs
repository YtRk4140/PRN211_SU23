using Buoi10_Q1.Models;

namespace Buoi10_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new PE_PRN211_23SprB1Context())
            {
                List<Textbox> t = context.Textboxes.ToList();
                foreach(Textbox item in t)
                {
                    dataGridView1.Rows.Add(item.Id, item.Text, item.Readonly);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int x = 470;
            // sau 1 thang tao moi thi no + 125
            int y = 98;
            // sau 1 thang tao moi thi no + 40
            int count = 0;

            using (var context = new PE_PRN211_23SprB1Context())
            {
                List<Textbox> t1 = context.Textboxes.ToList();
                foreach (Textbox item in t1)
                {
                    if(count != 0 && count % 3 == 0)
                    {
                        y += 40;
                        x = 470;
                    }
                    System.Windows.Forms.TextBox t = new TextBox();
                    this.Controls.Add(t);
                    t.Text = item.Text;

                    t.Enabled = item.Readonly==true?false:true;
                    t.Location = new Point(x, y);
                    t.Size = new Size(100, 23);
                    count++;
                    x += 125;
                    
                }
            }

        }
    }
}