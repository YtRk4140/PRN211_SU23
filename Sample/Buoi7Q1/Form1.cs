namespace Buoi7Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
     

            List<string> list = new List<string> { "All position", "Developer", "Tester", "Leader", "Manager" };
            comboBox1.DisplayMember = "string";
            comboBox1.ValueMember = "string";
            comboBox1.DataSource = list;


            dataGridView1.Rows.Clear();
            List<Employee> liste = Function.GetAll();
            foreach(Employee e1 in liste)
            {
                dataGridView1.Rows.Add(e1.Id, e1.Name, e1.Dob.ToString("dd-MM-yyyy"), e1.Sex, e1.Position, e1.Department, e1.DepartmentName);
            }
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            string name = textBox1.Text;
            string sex = "";
            if (radioButton2.Checked == true)
            {
                sex = "Male";

            }else if(radioButton3.Checked== true)
            {
                sex = "Female";
            }
            else
            {
                // all position
            }

            string position = comboBox1.SelectedValue.ToString() ;
            List<Employee> liste = Function.Search(name,sex,position);
            foreach (Employee e1 in liste)
            {
                dataGridView1.Rows.Add(e1.Id, e1.Name, e1.Dob.ToString("dd-MM-yyyy"), e1.Sex, e1.Position, e1.Department, e1.DepartmentName);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}