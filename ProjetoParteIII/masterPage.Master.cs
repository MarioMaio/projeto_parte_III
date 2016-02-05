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
    public partial class masterPage : System.Web.UI.MasterPage
    {
        private SqlConnection sqlConnection;
        private DataSet dsCategories;
        private SqlDataAdapter daCategories;
        private const string tableNameCategories = "Categories";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["userCompare"] != null)
            {
                hyperLinkLogon.Visible = false;
                hyperLinkLogon.Enabled = false;
                hyperLinkRegistar.Visible = false;
                hyperLinkRegistar.Enabled = false;
                buscarDadosUtilizador();
                hyperLinkAdminPage.Visible = true;
                hyperLinkAdminPage.Enabled = true;
                hyperLinkAdminPage.Text = Session["visitorName"].ToString();

                if (Session["userRole"].ToString().Contains("admin"))
                {
                    hyperLinkAdminPage.NavigateUrl = "~/administratorPage.aspx";
                }
                if (Session["userRole"].ToString().Contains("client"))
                {
                    hyperLinkAdminPage.NavigateUrl = "~/paginaCliente.aspx";
                }

                hyperLinkLogout.Visible = true;
                hyperLinkLogout.Enabled = true;
                
            }

            if (!IsPostBack)
            {
                if (ShoppingCart.Instance.Items.Count > 0)
                {
                    hyperLinkCarrinhoCompras.Visible = true;
                    hyperLinkCarrinhoCompras.Enabled = true;
                    hyperLinkCarrinhoCompras.Text = "Carrinho compras(" + ShoppingCart.Instance.Items.Count + ")";
                }
            }

            ligacaoBaseDados();
        }

        private void ligacaoBaseDados()
        {
            if (!IsPostBack)
            {
                //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
                {
                    daCategories = ProjetoConnection.DataRead(sqlConnection, tableNameCategories);
                    dsCategories = new DataSet();
                    daCategories.Fill(dsCategories, tableNameCategories);

                    DropDownListCategories.DataTextField = dsCategories.Tables[0].Columns["CategoryName"].ToString();
                    DropDownListCategories.DataValueField = dsCategories.Tables[0].Columns["CategoryID"].ToString();
                    

                    DropDownListCategories.DataSource = dsCategories.Tables[0];
                    DropDownListCategories.DataBind();

                    DropDownListCategories.Items.Insert(0, new ListItem("--Selecione Categoria--", "-1"));
                }
            }

        }

        protected void pesquisarCategorias(object sender, EventArgs e)
        {
            //Session["categoryValue"] = DropDownListCategories.SelectedValue;
            Response.Redirect("products.aspx?catID=" + DropDownListCategories.SelectedValue);
            //Response.Write("Category Value: " + DropDownListCategories.SelectedValue);
        }

        private void buscarDadosUtilizador()
        {
            SqlConnection conn;
            SqlCommand cmd;

            if (Session["userRole"].ToString().Contains("admin"))
            {
                try
                {
                    conn = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true");
                    //conn = new SqlConnection(@"server=DESKTOP-R5I2GJD\SQLEXPRESS;Integrated Security=SSPI;database=Northwind");
                    conn.Open();
                    cmd = new SqlCommand("SELECT CONCAT(FirstName, ' ', LastName) as EmployeeName FROM Employees WHERE EmployeeID=@employeeID", conn);
                    cmd.Parameters.Add("@employeeID", SqlDbType.Int);
                    cmd.Parameters["@employeeID"].Value = Convert.ToInt16(Session["userCompare"]);
                    Session["visitorName"] = (string)cmd.ExecuteScalar();
                    cmd.Dispose();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    // Add error handling here for debugging.
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                }
            }
            //string userTemp = Session["userRole"].ToString();
            if (Session["userRole"].ToString().Contains("client"))
            {
                try
                {
                    conn = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true");
                    //conn = new SqlConnection(@"server=DESKTOP-R5I2GJD\SQLEXPRESS;Integrated Security=SSPI;database=Northwind");
                    conn.Open();
                    cmd = new SqlCommand("SELECT CompanyName FROM Customers WHERE CustomerID=@customerID", conn);
                    cmd.Parameters.Add("@customerID", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@customerID"].Value = Session["userCompare"];
                    Session["visitorName"] = (string)cmd.ExecuteScalar();
                    cmd.Dispose();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    // Add error handling here for debugging.
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                }
            }
        }
    }
}