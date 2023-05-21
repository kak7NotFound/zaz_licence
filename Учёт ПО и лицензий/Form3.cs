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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string connStr = "server=localhost;port=3306;database=учёт по и лицензий;username=root;password=root;";
        private BindingSource bindingSorce = new BindingSource();
        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection coon = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "SELECT * FROM компьютеры";
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
            MySqlCommand command = new MySqlCommand("INSERT INTO `компьютеры` (`Id`, `название`, `ip-адресс`, `Описание`) VALUES (@id,@name,@ip,@op)", dB.getConnection());

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ip", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@op", MySqlDbType.VarChar).Value = textBox5.Text;

            dB.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Операция выполнена");

            else
                MessageBox.Show("Заполните корректно все поля");

            dB.closeConnection();
        }
        private void DeleteRow(string id)
        {
            string connStr = "server=localhost;port=3306;database=учёт по и лицензий;username=root;password=root;";
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                try
                {
                    string sql = "DELETE FROM компьютеры " +
                    "WHERE id = @id";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
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

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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
