namespace Buoi4_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dgv.Rows.Clear();
            List<Employee> listemp = Function.GetAll();

            foreach (Employee item in listemp)
            {
                dgv.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), item.Sex, item.Position, item.DerName);
            }
        }

        public void LoadForm()
        {
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

                List<string> listpos = new List<String> { "Developer", "Tester", "Leader", "ABC" };
                comboBox1.DisplayMember = "string";
                comboBox1.ValueMember = "string";
                comboBox1.DataSource = listpos;

                List<Department> listde = Function.GetDepartment();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = listde;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            List<Employee> listemp = Function.GetSearch(text);
            dgv.Rows.Clear();
            foreach (Employee item in listemp)
            {
                dgv.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), item.Sex, item.Position, item.DerName);
            }
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

        /// <summary>
        /// add emp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Employee e1 = new Employee();
                e1.Name = textBox4.Text;
                e1.Dob = dateTimePicker1.Value;
                // C1. set value cho sex (female or male dua tren button)
                string sex = "";
                if (radioButton1.Checked = true) {   sex = "Male";   }
                else sex = "Female";
                e1.Sex = sex;

                e1.Position = comboBox1.SelectedValue.ToString();
                e1.DerID = int.Parse(comboBox2.SelectedValue.ToString());

                int row = Function.AddEmp(e1);
                if (row > 0)
                {
                    MessageBox.Show("Ban da them nhan vien thanh cong");
                }
                LoadData();
                LoadForm();
            }

            catch
            {

            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox2.Text);
                DialogResult r = MessageBox.Show("Ban co chac muon xoa khong", "Thong bao", MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                {
                    int row = Function.Delete(id);
                    if (row > 0)
                    {
                        MessageBox.Show("Da xoa nhan vien thanh cong");
                        LoadData();
                        LoadForm();
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// update emp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Employee e1 = new Employee();
                // can lay duoc Id cua e1;
                e1.Id = int.Parse(textBox2.Text);
                e1.Name = textBox4.Text;
                e1.Dob = dateTimePicker1.Value;

                // C2. set true false theo radio button
                e1.Sex = radioButton1.Checked == true ? "Male" : "Female";

                e1.Position = comboBox1.SelectedValue.ToString();
                e1.DerID = int.Parse(comboBox2.SelectedValue.ToString());

                int row = Function.UpdateEmp(e1);
                if (row > 0)
                {
                    MessageBox.Show("Ban da cap nhat nhan vien thanh cong");
                    LoadData();
                    LoadForm();
                }
            }

            catch
            {

            }
        }
    }
}