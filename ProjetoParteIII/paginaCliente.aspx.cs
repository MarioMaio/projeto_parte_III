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
        private DataSet dsCustomer;
        private SqlDataAdapter daCustomer;
        private DataSet dsOrder;
        private SqlDataAdapter daOrder;
        private const string tableNameCustomers = "[Customers]";
        private const string fieldNameCustomers = "[CustomerID]";
        private const string tableNameOrder = "[Orders]";

        protected void Page_Load(object sender, EventArgs e)
        {
            ligacaoBaseDados();
        }
        private void ligacaoBaseDados()
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daCustomer = ProjetoConnection.DataRead(sqlConnection, tableNameCustomers, fieldNameCustomers, Session["userCompare"].ToString(), true);
                dsCustomer = new DataSet();
                daCustomer.Fill(dsCustomer, tableNameCustomers);

                textBoxCompanyName.Text = dsCustomer.Tables[0].Rows[0]["CompanyName"].ToString();
                textBoxContactName.Text = dsCustomer.Tables[0].Rows[0]["ContactName"].ToString();

                if (!IsPostBack)
                {
                    daOrder = ProjetoConnection.DataRead(sqlConnection, tableNameOrder, fieldNameCustomers, Session["userCompare"].ToString(), true);

                    dsOrder = new DataSet();
                    daOrder.Fill(dsOrder, tableNameOrder);

                    dropDownListFaturas.DataTextField = dsOrder.Tables[0].Columns["OrderID"].ToString();
                    dropDownListFaturas.DataValueField = dsOrder.Tables[0].Columns["OrderID"].ToString();

                    dropDownListFaturas.DataSource = dsOrder.Tables[0];
                    dropDownListFaturas.DataBind();

                    dropDownListFaturas.Items.Insert(0, new ListItem("--Selecione Fatura--", "-1"));
                }
            }
        }

        protected void GravarDados_Click(object sender, EventArgs e)
        {
            

        }

        public void verHistorico(object sender, EventArgs e)
        {
            Session["fatura"] = dropDownListFaturas.SelectedValue;
            Response.Redirect("~/historicoCliente.aspx");
        }
        
    }

}