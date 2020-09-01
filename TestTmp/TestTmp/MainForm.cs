using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTmp
{
    public partial class MainForm : Form
    {
        private SqlConnection sqlConnection;
        public MainForm()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            BindingSource binding = new BindingSource();

            DataTable dtProducts = new DataTable();
            var connectionStr = ConfigurationManager.ConnectionStrings["MainDBConnectionStr"].ConnectionString;
            sqlConnection = new SqlConnection(connectionStr);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("[ProductsList]", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dtProducts);
            binding.DataSource = dtProducts;
            gridView.DataSource = binding;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlConnection.Close();
        }
    }
}
