using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoParteIII
{
    public partial class carrinhoCompras : System.Web.UI.Page
    {
        private int pId;
        private string pName;
        private int pQuantity;
        private decimal pUnitPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            pId = Convert.ToInt16(Request.QueryString["pID"]);
            pName = Request.QueryString["pName"];
            pQuantity = Convert.ToInt16(Request.QueryString["pQuantity"]);
            pUnitPrice = Convert.ToDecimal(Request.QueryString["pUnitPrice"]);

            ShoppingCart.Instance.AddItem(pId, pName, pQuantity, pUnitPrice);
            preencherCarrinho();
        }

        private void preencherCarrinho()
        {
            gvShoppingCart.DataSource = ShoppingCart.Instance.Items;
            gvShoppingCart.DataBind();
        }
    }
}