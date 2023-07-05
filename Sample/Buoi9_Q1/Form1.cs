namespace Buoi9_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string filename;
        public List<Employee> listemp= new List<Employee>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            if (openFile.ShowDialog()== DialogResult.OK)
            {
                filename = openFile.FileName;
                if(filename!= null)
                {
                    textBox1.Text= filename;
                    listemp = Function.ReadFile(filename);

                    foreach(Employee item in listemp)
                    {
                        dataGridView1.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), item.Salary);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in dataGridView1.SelectedRows)
            {
                string id = item.Cells["Column1"].Value.ToString();
                listemp = Function.Remove(listemp, id);

            }
            MessageBox.Show("Remove successful");
            dataGridView1.Rows.Clear();
            foreach(Employee item in listemp)
            {
                dataGridView1.Rows.Add(item.Id, item.Name, item.Dob.ToString("dd-MM-yyyy"), item.Salary);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Function.WriteToFile(listemp, filename);
            MessageBox.Show("Write to file ok");
        }
    }
}