using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace savesql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AddHoverEffects(btSave);
            AddHoverEffects(btDelete);
            AddHoverEffects(btshowdata);
            AddHoverEffects(btUpdate);

        }

        // Method to add hover effects
        private void AddHoverEffects(Button button)
        {
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = Color.LightBlue; // Change to hover color
                button.ForeColor = Color.DarkBlue; // Optional: Change text color
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = SystemColors.Control; // Reset to default color
                button.ForeColor = SystemColors.ControlText; // Reset text color
            };
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=REDONBERISHA\\SQLEXPRESS;Initial Catalog=REDONI;Integrated Security=True";
          
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();


            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;

            string Query = "INSERT INTO NAMES (FirstName, SecondName) VALUES ('"+FirstName+"', '"+SecondName+"')";
            
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();


            con.Close();


            MessageBox.Show("Data has been saved!");

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=REDONBERISHA\\SQLEXPRESS;Initial Catalog=REDONI;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string NameId = tbID.Text;
            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;

            string Query = "DELETE FROM NAMES WHERE FirstName = '"+FirstName+"' AND SecondName = '"+SecondName+"' AND ID = "+ NameId;

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data has been deleted!");

        }

        private void btshowdata_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=REDONBERISHA\\SQLEXPRESS;Initial Catalog=REDONI;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string Query = "SELECT * FROM NAMES ORDER BY ID ASC";

            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            dataGridView1.DataSource = table;

            con.Close();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=REDONBERISHA\\SQLEXPRESS;Initial Catalog=REDONI;Integrated Security=True";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            string NameId = tbID.Text;
            string FirstName = tbFirstName.Text;
            string SecondName = tbSecondName.Text;

            string Query = "UPDATE Names SET FirstName = '"+FirstName+"', SecondName = '"+SecondName+"' WHERE ID = "+ NameId;

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();


            con.Close();


            MessageBox.Show("Data has been Updated!");

        }
    }
}
