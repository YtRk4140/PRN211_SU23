using Buoi5.Models;
using Buoi5.Repository;
using Buoi5.Services;

namespace Buoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private static IEmployee e1 = new EmployeeServices();

        private static IDepartment d1 = new DepartmentServices();

        public void LoadData()
        {
            dgv.Rows.Clear();
            List<Employee> liste = e1.GetAll();
            foreach (Employee item in liste)
            {
                item.DepartmentNavigation = d1.GetDepartment(item.Department);
                bool gioitinh = false;
                if (item.Sex == "Male")
                {
                    gioitinh = true;
                }
                else
                    gioitinh = false;

                dgv.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), gioitinh, item.Position, item.DepartmentNavigation.Name);
            }

        }
        public void LoadForm()
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            LoadData();
            var groupbyPos = e1.GetAll().GroupBy(x => x.Position);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Key";
            comboBox1.DataSource = groupbyPos.ToList();

            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = d1.GetAll();

            MessageBox.Show("Loadd");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                textBox3.Text = dgv.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Column3"].Value.ToString());
                bool sex =bool.Parse( dgv.Rows[e.RowIndex].Cells["Column4"].Value.ToString());
                if (sex == true)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dgv.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
                comboBox2.SelectedIndex = comboBox2.FindStringExact(dgv.Rows[e.RowIndex].Cells["Column6"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Employee e2 = new Employee();
                e2.Name = textBox3.Text;
                e2.Dob = dateTimePicker1.Value;
                e2.Sex = radioButton1.Checked == true ? "Male" : "Female";
                e2.Position = comboBox1.SelectedValue.ToString();
                e2.Department = int.Parse(comboBox2.SelectedValue.ToString());

                e1.AddEmp(e2);
                MessageBox.Show("Ban da add thanh cong Emp");
                LoadData();
                LoadForm();
                


            }
            catch
            {
                MessageBox.Show("Add emp that bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Employee e2 = new Employee();
                e2.Id = int.Parse(textBox2.Text);
                e2.Name = textBox3.Text;
                e2.Dob = dateTimePicker1.Value;
                e2.Sex = radioButton1.Checked == true ? "Male" : "Female";
                e2.Position = comboBox1.SelectedValue.ToString();
                e2.Department = int.Parse(comboBox2.SelectedValue.ToString());

                e1.UpEmp(e2);
                MessageBox.Show("Ban da update thanh cong Emp");
                LoadData();
                LoadForm();



            }
            catch
            {
                MessageBox.Show("Update emp that bai");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                int id = int.Parse(textBox2.Text);
                e1.DeleteEmp(id);
                MessageBox.Show("Ban da remove thanh cong Emp");
                LoadData();
                LoadForm();

            }
            catch {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(textBox1.Text);
            form.Show();
            form.FormClosed += Form1_Load;


        }
    }
}