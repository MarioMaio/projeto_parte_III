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
            if (!IsPostBack)
            {
                ligacaoBaseDados();
            }
        }

        private void ligacaoBaseDados()
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameOrderDetails);


                productListHome.DataSource = dsProducts.Tables[0];
                productListHome.DataBind();
                
                //repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                //repeaterControlListagemProdutos.DataBind();
            }
        }

        protected void procurarProdutos(object sender, EventArgs e)
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            //using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, "ProductName", textBoxSearchProduct.Text);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameProducts);

                productListHome.DataSource = dsProducts.Tables[0];
                productListHome.DataBind();

                //repeaterControlListagemProdutos.DataSource = dsProducts.Tables[0];
                //repeaterControlListagemProdutos.DataBind();

                
            }
        }

        

        protected void adicionarArtigo_OnClick(object sender, EventArgs e)
        {

            Control myControl1 = FindControl("textBoxQuantity");
            Response.Write(myControl1);
        }

        protected void adicionarItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //cast the postback causing control respectively, LinkButton/Button:
            System.Web.UI.WebControls.LinkButton btn = e.CommandSource as System.Web.UI.WebControls.LinkButton;

            //get the ListViewItem:
            ListViewItem item = btn.NamingContainer as ListViewItem;
            //System.Web.UI.WebControls.ListViewDataItem li = btn.NamingContainer as System.Web.UI.WebControls.ListViewDataItem;

            //find any control on that item: 
            TextBox textBoxProductID = item.FindControl("textBoxProductID") as TextBox;
            HiddenField hiddenFieldProductName = item.FindControl("hiddenFieldProductName") as HiddenField;
            TextBox textBoxQuantity = item.FindControl("textBoxQuantity") as TextBox;
            HiddenField hiddenFieldProductUnitPrice = item.FindControl("hiddenFieldProductUnitPrice") as HiddenField;

            //Response.Write(textBoxQuantity.Text);
            if (Convert.ToInt16(textBoxProductID.Text) > 0)
            {
                ShoppingCart.Instance.AddItem(Convert.ToInt16(textBoxProductID.Text), hiddenFieldProductName.Value, Convert.ToInt16(textBoxQuantity.Text), Convert.ToDecimal(hiddenFieldProductUnitPrice.Value));
            }
            Response.Redirect("~/carrinhoCompras.aspx");
        }
        
    }
}