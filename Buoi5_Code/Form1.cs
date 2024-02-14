using Buoi5.Repository;
using Buoi5_Code.Models;
using Buoi5_Code.Repository;
using Buoi5_Code.Services;

namespace Buoi5_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static PE_Fall21B5Context context = new PE_Fall21B5Context();

        private static IEmployee e1 = new EmployeeServices(context);

        private static IDepartment d1 = new DepartmentServices(new PE_Fall21B5Context());
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Employee> liste = e1.GetAll();
            foreach (Employee item in liste)
            {
                item.DepartmentNavigation = d1.GetDepartment(item.Department);
                dgv.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), item.Sex, item.Position, item.DepartmentNavigation.Name);
            }

            var groupbyPos = e1.GetAll().GroupBy(x => x.Position);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Key";
            comboBox1.DataSource = groupbyPos.ToList();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                textBox4.Text = dgv.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Column3"].Value.ToString());
                string sex = dgv.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
                if (sex == "Male") { radioButton1.Checked = true; }
                else { radioButton2.Checked = true; }
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dgv.Rows[e.RowIndex].Cells["Column5"].Value.ToString());
                comboBox2.SelectedIndex = comboBox2.FindStringExact(dgv.Rows[e.RowIndex].Cells["Column6"].Value.ToString());
            }
        }
    }
}