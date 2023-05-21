using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учёт_состояния_комп.техники
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string connStr = "server=localhost;port=3306;database=учёт по и лицензий;username=root;password=root;";
        private BindingSource bindingSorce = new BindingSource();
       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void DeleteRow(string name)
        {
            string connStr = "server=localhost;port=3306;database=учёт по и лицензий;username=root;password=root;";
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                try
                {
                    string sql = "DELETE FROM по " +
                    "WHERE название = @name";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                DeleteRow(textBox3.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection coon = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "SELECT * FROM по";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            bindingSorce.DataSource = dataset.Tables[0];
            dataGridView2.DataSource = bindingSorce;
            coon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `по` (`id`, `название`, `версия`, `описание`, `категория`, `дата_установки`, `дата_окончания_лицензии`) VALUES (@id,@name,@ver,@op,@cat,@du,@dol)", dB.getConnection());

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ver", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@op", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = textBox7.Text;
            command.Parameters.Add("@du", MySqlDbType.VarChar).Value = textBox8.Text;
            command.Parameters.Add("@dol", MySqlDbType.VarChar).Value = textBox9.Text;


            dB.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Операция выполнена");

            else
                MessageBox.Show("Заполните корректно все поля");

            dB.closeConnection();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Close();
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private void установкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Close();
        }
    }
}
