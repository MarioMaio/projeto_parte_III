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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preencherCarrinho();
            }
        }

        private void preencherCarrinho()
        {
            gvShoppingCart.DataSource = ShoppingCart.Instance.Items;
            gvShoppingCart.DataBind();
        }

        protected void removeItem_onClick(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;

            ShoppingCart.Instance.RemoveItem(Convert.ToInt16(linkButton.CommandArgument));
            preencherCarrinho();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                lbl.Text = String.Format("{0:c}", ShoppingCart.Instance.GetSubTotal());
            }
        }

        protected void updateItem_onClick(object sender, EventArgs e)
        {
            for (int i = 0; i < gvShoppingCart.Rows.Count; i++)
            {
                string productID;
                productID = ((HiddenField)gvShoppingCart.Rows[i].FindControl("hiddenFieldProductID")).Value;

                TextBox quantityTextBox = new TextBox();
                quantityTextBox = (TextBox)gvShoppingCart.Rows[i].FindControl("txtQuantity");
                ShoppingCart.Instance.SetItemQuantity(Convert.ToInt16(productID), Convert.ToInt16(quantityTextBox.Text.ToString()));
            }
            preencherCarrinho();
        }

        protected void confirmarCompra_onClick(object sender, EventArgs e)
        {
            if (Session["userCompare"] != null)
            {
                Response.Write("Login efetuado");
            }
            else
            {
                Response.Redirect("~/logon.aspx");
            }
        }
    }
}