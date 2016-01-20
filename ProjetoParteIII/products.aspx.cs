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
    public partial class products : System.Web.UI.Page
    {

        private SqlConnection sqlConnection;
        private DataSet dsProducts;
        private SqlDataAdapter daProducts;
        private const string tableNameOrderDetails = "[Order Details]";
        //private const string tableNameOrderDetails = "[OrderDetails]"; //PC de casa
        private const string tableNameProducts = "Products";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Request.QueryString["catID"]) < 1)
            {
                ligacaoBaseDados();
            }
            else
            {
            //selecionarPorCategorias(Convert.ToInt16(Session["categoryValue"]));
            selecionarPorCategorias(Convert.ToInt16(Request.QueryString["catID"]));
            }
            
        }

        private void ligacaoBaseDados()
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, tableNameProducts, true);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameOrderDetails);

                repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                repeaterControlListagemProdutos.DataBind();
            }
        }

        protected void selecionarPorCategorias(int categoryID)
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, "p.CategoryID", categoryID);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameProducts);

                repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                repeaterControlListagemProdutos.DataBind();


            }
        }
    }
}