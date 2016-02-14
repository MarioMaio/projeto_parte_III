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
    public partial class historicoCliente : System.Web.UI.Page
    {

        private SqlConnection sqlConnection;
        private DataSet dsProducts;
        private SqlDataAdapter daProducts;
        //private const string tableNameOrderDetails = "[Order Details]";
        private const string tableNameOrderDetails = "[OrderDetails]"; //PC de casa
        private const string fieldNameOrderDetails = "OrderID";

        private const string tableNameProducts = "Products";

        protected void Page_Load(object sender, EventArgs e)
        {
            preencherHistorico();
        }

        public void preencherHistorico()
        {
            using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, tableNameOrderDetails, fieldNameOrderDetails, Convert.ToInt16(Session["fatura"]));
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameOrderDetails);


                gvHistoricoCliente.DataSource = dsProducts.Tables[0];
                gvHistoricoCliente.DataBind();

                
                labelNumeroFatura.Text = Session["fatura"].ToString();
                
                
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                //lbl.Text = String.Format("{0:c}", ShoppingCart.Instance.GetSubTotal());
                lbl.Text = "Ainda por fazer as contas...";
            }
        }
    }
}