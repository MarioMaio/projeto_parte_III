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
    public partial class home : System.Web.UI.Page
    {
        private SqlConnection sqlConnection;
        private DataSet dsProducts;
        private SqlDataAdapter daProducts;
        //private const string tableNameOrderDetails = "[Order Details]";
        private const string tableNameOrderDetails = "[OrderDetails]"; //PC de casa
        private const string tableNameProducts = "Products";

        protected void Page_Load(object sender, EventArgs e)
        {
            ligacaoBaseDados();
        }

        private void ligacaoBaseDados()
        {
            using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameOrderDetails);


                productList.DataSource = dsProducts.Tables[0];
                productList.DataBind();

                //repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                //repeaterControlListagemProdutos.DataBind();
            }
        }

        protected void procurarProdutos(object sender, EventArgs e)
        {
            using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, "ProductName", textBoxSearchProduct.Text);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameProducts);

                productList.DataSource = dsProducts.Tables[0];
                productList.DataBind();

                //repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                //repeaterControlListagemProdutos.DataBind();

                
            }
        }

        protected void adicionarProdutoCarrinho_Click(object sender, EventArgs e)
        {
                //Label fvLabel = (Label)FindControl("labelProductID");
            if (!IsPostBack)
            { 
                Response.Write("Teste"); 
            }
                
                //ShoppingCart.Instance.AddItem(labelProductID);
                
        }

        
    }
}