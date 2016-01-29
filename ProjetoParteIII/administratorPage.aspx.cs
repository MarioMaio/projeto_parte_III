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
    public partial class administratorPage : System.Web.UI.Page
    {

        private SqlConnection sqlConnection;
        private DataSet dsProducts;
        private SqlDataAdapter daProducts;
        private const string tableNameOrderDetails = "[Order Details]";
        //private const string tableNameOrderDetails = "[OrderDetails]"; //PC de casa
        private const string tableNameProducts = "Products";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userRole"].ToString().Contains("admin") || Session["userRole"] != null)
            //{
                if (!IsPostBack)
                {
                    ligacaoBaseDados();
                }
            //}
        }

        private void ligacaoBaseDados()
        {
            //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
            using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
            {
                daProducts = ProjetoConnection.DataRead(sqlConnection, tableNameProducts, true, true);
                dsProducts = new DataSet();
                daProducts.Fill(dsProducts, tableNameOrderDetails);

                gridViewProducts.DataSource = dsProducts.Tables[0];
                gridViewProducts.DataBind();
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            ligacaoBaseDados();
            gridViewProducts.PageIndex = e.NewPageIndex;
            gridViewProducts.DataBind();
        }

        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        {
            gridViewProducts.EditIndex = e.NewEditIndex;
            ligacaoBaseDados();
        }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewProducts.EditIndex = -1;
            ligacaoBaseDados();
        }
        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {
            string productID = ((Label)gridViewProducts.Rows[e.RowIndex].FindControl("lblProductID")).Text;
            string productName = ((TextBox)gridViewProducts.Rows[e.RowIndex].FindControl("txtProductName")).Text;
            string unitPrice = ((TextBox)gridViewProducts.Rows[e.RowIndex].FindControl("txtUnitPrice")).Text;
            bool discontinued = ((CheckBox)gridViewProducts.Rows[e.RowIndex].FindControl("checkBoxDiscontinued")).Checked;

            DataSet dsProduct;
            SqlDataAdapter daProduct;
            string tableName = "Products";
            DataTable dataTable;
            DataRow dataRow;
            SqlCommandBuilder cmdBuilder;

            try
            {
                //using (sqlConnection = new SqlConnection(@"Data Source=MÁRIO-PC\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
                //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                {
                    daProduct = ProjetoConnection.DataRead(sqlConnection, tableName, true, true);

                    cmdBuilder = new SqlCommandBuilder(daProduct);

                    daProduct.UpdateCommand = new SqlCommand("UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, Discontinued = @Discontinued WHERE ProductID = @ProductID", sqlConnection);
                    daProduct.UpdateCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40).Value = productName;
                    
                    SqlParameter unitPriceParameter = daProduct.UpdateCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
                    unitPriceParameter.Value = unitPrice;

                    SqlParameter discontinuedParameter = daProduct.UpdateCommand.Parameters.Add("@Discontinued", SqlDbType.Bit);
                    discontinuedParameter.Value = discontinued;
                    
                    SqlParameter ProductIDParameter = daProduct.UpdateCommand.Parameters.Add("@ProductID", SqlDbType.Int);
                    ProductIDParameter.Value = Convert.ToInt16(productID);
                    ProductIDParameter.SourceVersion = DataRowVersion.Original;

                    dsProduct = new DataSet();
                    daProduct.Fill(dsProduct, tableName);

                    dataTable = dsProduct.Tables[tableName];
                    dataRow = dataTable.Rows[Convert.ToInt16(productID)];

                    dataRow["ProductID"] = Convert.ToInt16(productID);
                    dataRow["ProductName"] = productName;
                    //dataRow["SupplierID"] = productSupplierID;
                    //dataRow["CategoryID"] = productCategoryID;
                    //dataRow["QuantityPerUnit"] = productQuantityPerUnit;
                    dataRow["UnitPrice"] = unitPrice;
                    //dataRow["UnitsInStock"] = productUnitsInStock;
                    //dataRow["UnitsOnOrder"] = productUnitsOnOrder;
                    //dataRow["ReorderLevel"] = productReorderLevel;
                    dataRow["Discontinued"] = Convert.ToInt16(discontinued);

                    daProduct.Update(dsProduct, tableName);
                    gridViewProducts.EditIndex = -1;
                    ligacaoBaseDados();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddNewCustomer(object sender, EventArgs e)
        {
            string productName = ((TextBox)gridViewProducts.FooterRow.FindControl("txtProductName")).Text;
            string unitPrice = ((TextBox)gridViewProducts.FooterRow.FindControl("txtUnitPrice")).Text;
            bool discontinued = ((CheckBox)gridViewProducts.FooterRow.FindControl("checkBoxDiscontinued")).Checked;

            DataSet dsProduct;
            SqlDataAdapter daProduct;
            string tableName = "Products";
            DataTable dataTable;
            DataRow dataRow;
            SqlCommandBuilder cmdBuilder;

            try
            {
                //using (sqlConnection = new SqlConnection(@"Data Source=MÁRIO-PC\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
                //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                {
                    daProduct = ProjetoConnection.DataRead(sqlConnection, tableName, true, true);

                    cmdBuilder = new SqlCommandBuilder(daProduct);

                    daProduct.InsertCommand = new SqlCommand("INSERT INTO Products (ProductName, UnitPrice, Discontinued) VALUES (@ProductName, @UnitPrice, @Discontinued)", sqlConnection);
                    daProduct.InsertCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar, 40).Value = productName;
                    
                    SqlParameter unitPriceParameter = daProduct.InsertCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
                    unitPriceParameter.Value = unitPrice;

                    SqlParameter discontinuedParameter = daProduct.InsertCommand.Parameters.Add("@Discontinued", SqlDbType.Bit);
                    discontinuedParameter.Value = discontinued;
                    

                    dsProduct = new DataSet();
                    daProduct.Fill(dsProduct, tableName);

                    dataTable = dsProduct.Tables[tableName];
                    dataRow = dataTable.Rows.Add();

                    dataRow["ProductName"] = productName;
                    //dataRow["SupplierID"] = productSupplierID;
                    //dataRow["CategoryID"] = productCategoryID;
                    //dataRow["QuantityPerUnit"] = productQuantityPerUnit;
                    dataRow["UnitPrice"] = unitPrice;
                    //dataRow["UnitsInStock"] = productUnitsInStock;
                    //dataRow["UnitsOnOrder"] = productUnitsOnOrder;
                    //dataRow["ReorderLevel"] = productReorderLevel;
                    dataRow["Discontinued"] = Convert.ToInt16(discontinued);

                    daProduct.Update(dsProduct, tableName);
                    gridViewProducts.EditIndex = -1;
                    ligacaoBaseDados();

                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}