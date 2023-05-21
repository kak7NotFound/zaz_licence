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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            button3_Click(null, null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }
        string connStr = "server=lasttray.com;port=33306;username=user;password=0;database=main;";
        private BindingSource bindingSorce = new BindingSource();
        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection coon = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "SELECT * FROM лицензии";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            bindingSorce.DataSource = dataset.Tables[0];
            dataGridView2.DataSource = bindingSorce;
            coon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `лицензии` (`id`, `название`, `тип`, `дата_начала_действия`, `дата_окончания_действия`, `количество_устройств`) VALUES (@id,@nazv,@t,@dnd,@dod)", dB.getConnection());

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox7.Text;
            command.Parameters.Add("@nazv", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@t", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@dnd", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@dod", MySqlDbType.VarChar).Value = textBox6.Text;

            dB.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Операция выполнена");

            else
                MessageBox.Show("Заполните корректно все поля");

            dB.closeConnection();
        }
        private void DeleteRow(string название)
        {
            string connStr = "server=lasttray.com;port=33306;username=user;password=0;database=main;";
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                try
                {
                    string sql = "DELETE FROM лицензии " +
                    "WHERE название = @nazv";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nazv", название);
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
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
