using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjetoParteIII
{
    public class InserirEncomenda
    {
        #region Atributos

        private SqlConnection sqlConnection;
        private DataSet dsOrder;
        private DataSet dsOrderDetails;
        private SqlDataAdapter daOrder;
        private SqlDataAdapter daOrderDetails;
        private const string tableName = "Orders";
        private const string tableNameOrderDetails = "OrderDetails";
        private DataTable dataTable;
        private DataRow dataRow;
        private SqlCommandBuilder cmdBuilder;


        #endregion

        #region Inserir Order
        public  void insertOrder(string userID, int employeeID=1)
        {
            try
            {
                //using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
                { 
                    daOrder = ProjetoConnection.DataRead(sqlConnection, tableName);
                    
                    cmdBuilder = new SqlCommandBuilder(daOrder);

                    SqlCommand command = new SqlCommand("INSERT INTO Orders (CustomerID, EmployeeID) VALUES (@CustomerID, @EmployeeID)", sqlConnection);
                    daOrder.InsertCommand = command;
                    daOrder.InsertCommand.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");

                    SqlParameter employeeIDParameter = daOrder.InsertCommand.Parameters.Add("@EmployeeID", SqlDbType.Int);
                    employeeIDParameter.SourceColumn = "EmployeeID";


                    dsOrder = new DataSet();
                    daOrder.Fill(dsOrder, tableName);
                    dataTable = dsOrder.Tables[tableName];

                    dataRow = dataTable.Rows.Add();
                    dataRow["CustomerID"] = userID;
                    dataRow["EmployeeID"] = employeeID;

                    daOrder.Update(dsOrder, tableName);
                }

                    int maxOrderID;
                    SqlConnection conn;
                    SqlCommand cmd;

                    conn = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true");
                    //conn = new SqlConnection(@"server=DESKTOP-R5I2GJD\SQLEXPRESS;Integrated Security=SSPI;database=Northwind");
                    conn.Open();

                    cmd = new SqlCommand("select max(OrderID) from Orders", conn);
                    maxOrderID = (int)cmd.ExecuteScalar();

                    cmd.Dispose();
                    conn.Dispose();

                     foreach (var item in ShoppingCart.Instance.Items)
                    {
                        //using (sqlConnection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                        //using (sqlConnection = new SqlConnection(@"Data Source=DESKTOP-R5I2GJD\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true"))
                        using (sqlConnection = new SqlConnection(@"Data Source=VM_WINDOWS8; Initial Catalog=Northwind; Integrated Security=true"))
                        { 
                            daOrderDetails = ProjetoConnection.DataRead(sqlConnection, tableNameOrderDetails);
                    
                            cmdBuilder = new SqlCommandBuilder(daOrderDetails);

                            SqlCommand command = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)", sqlConnection);
                            daOrderDetails.InsertCommand = command;

                            SqlParameter orderIDParameter = daOrderDetails.InsertCommand.Parameters.Add("@OrderID", SqlDbType.Int);
                            orderIDParameter.SourceColumn = "OrderID";

                            SqlParameter productIDParameter = daOrderDetails.InsertCommand.Parameters.Add("@ProductID", SqlDbType.Int);
                            productIDParameter.SourceColumn = "ProductID";

                            SqlParameter unitPriceParameter = daOrderDetails.InsertCommand.Parameters.Add("@UnitPrice", SqlDbType.Money);
                            unitPriceParameter.SourceColumn = "UnitPrice";

                            SqlParameter quantityParameter = daOrderDetails.InsertCommand.Parameters.Add("@Quantity", SqlDbType.SmallInt);
                            quantityParameter.SourceColumn = "Quantity";

                            SqlParameter discountParameter = daOrderDetails.InsertCommand.Parameters.Add("@Discount", SqlDbType.Real);
                            discountParameter.SourceColumn = "Discount";


                            dsOrderDetails = new DataSet();
                            daOrderDetails.Fill(dsOrderDetails, tableNameOrderDetails);
                            dataTable = dsOrderDetails.Tables[tableNameOrderDetails];

                            dataRow = dataTable.Rows.Add();
                            dataRow["OrderID"] = maxOrderID;
                            dataRow["ProductID"] = item.ProductID;
                            dataRow["UnitPrice"] = item.ProductPrice;
                            dataRow["Quantity"] = item.ProductQuantity;
                            dataRow["Discount"] = item.Discount;

                            daOrderDetails.Update(dsOrderDetails, tableNameOrderDetails);
                        }
                    }



                
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            ShoppingCart.Instance.Items.Clear();

    }

        #endregion
        
    }
}