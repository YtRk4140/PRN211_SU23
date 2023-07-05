using Buoi8Q1.Models;
using Microsoft.EntityFrameworkCore;

namespace Buoi8Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new PE_PRN_Fall22B1Context())
            {
                List<Producer> listd = context.Producers.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource=listd;

                List<Genre> listg = context.Genres.ToList();
                listBox1.DisplayMember = "Title";
                listBox1.ValueMember = "Id";
                listBox1.DataSource=listg;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PE_PRN_Fall22B1Context())
            {
                Movie m = new Movie();
                m.Title = textBox1.Text;
                m.ReleaseDate = dateTimePicker1.Value;
                m.Description = textBox2.Text;
                m.Language = textBox3.Text;
                m.ProducerId = int.Parse(comboBox1.SelectedValue.ToString());
                context.Movies.Add(m);
                context.SaveChanges();
                // sau khi add xong thi se bt dc m.Id
                // tim thg movie vua add vao
                // tuong duong voi viec la cac ban se join 
                Movie m1 = context.Movies.FirstOrDefault(x => x.Id == m.Id);
                // no la 1 list 
                foreach(Genre item in listBox1.SelectedItems)
                {
                    Genre g = context.Genres.FirstOrDefault(x => x.Id == item.Id);
                    m1.Genres.Add(g);
                }
                context.SaveChanges();
                MessageBox.Show("Add thanh cong");
            }
        }
    }
}