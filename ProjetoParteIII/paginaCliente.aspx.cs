using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoParteIII
{
    public partial class paginaCliente : System.Web.UI.Page
    {

        private SqlConnection sqlConnection;
        private DataSet dsProducts;
        private SqlDataAdapter daProducts;
        private const string tableNameCustomers = "[Customers]";
        private const string fieldNameCustomers = "[CustomerID]";

        protected void Page_Load(object sender, EventArgs e)
        {
            ligacaoBaseDados();
        }
        private void ligacaoBaseDados()
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, tableNameCustomers, fieldNameCustomers, Session["userCompare"].ToString(), true);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameCustomers);

                textBoxCompanyName.Text = dsProducts.Tables[0].Rows[0]["CompanyName"].ToString();
                textBoxContactName.Text = dsProducts.Tables[0].Rows[0]["ContactName"].ToString();
            }
        }

        protected void GravarDados_Click(object sender, EventArgs e)
        {
            

        }
        
    }

}