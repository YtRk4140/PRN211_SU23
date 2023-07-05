using Buoi10_Q2.Models;
using Microsoft.EntityFrameworkCore;

namespace Buoi10_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            using (var context = new PE_PRN211_23SprB1Context())
            {
                List<Student> lists= context.Students.ToList();
                dataGridView1.Rows.Clear();
                foreach(Student item in lists)
                {
                    dataGridView1.Rows.Add(item.Id, item.Fullname, item.Sex, item.Dob.ToString("dd-MM-yyyy"), item.Email);
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                string sex = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                if (sex == "male")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                dateTimePicker1.Value = DateTime.Parse( dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                using (var context = new PE_PRN211_23SprB1Context())
                {
                    Student s = context.Students.FirstOrDefault(x => x.Id == id);
                    s.Fullname = textBox2.Text;
                    if (radioButton1.Checked == true)
                        s.Sex = "male";
                    else
                        s.Sex = "female";
                    s.Dob = dateTimePicker1.Value;
                    s.Email = textBox3.Text;
                    context.Students.Update(s);
                    context.SaveChanges();
                    LoadData();
                  
                }
            }catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int id = int.Parse(textBox1.Text);
                DialogResult r = MessageBox.Show("Are you really want to delete student", "Confirm", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    using (var context = new PE_PRN211_23SprB1Context())
                    {
                        
                        Student s = context.Students.Include(x=>x.Classes).FirstOrDefault(x => x.Id == id);
                        s.Classes.Clear();
                        context.Students.Remove(s);
                        context.SaveChanges();
                        LoadData();
                    }
                }
            }
            catch
            {

            }
        }
    }
}