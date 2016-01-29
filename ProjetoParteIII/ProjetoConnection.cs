using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoParteIII
{
    public class ProjetoConnection
    {
        public static SqlDataAdapter DataRead(SqlConnection sqlConnection)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT TOP 12 o.ProductID, SUM(Quantity) as totalVendas, ProductName, c.CategoryName, p.UnitPrice ");
                stringCommand.Append("FROM [Order Details] as o ");
                //stringCommand.Append("FROM [OrderDetails] as o "); //PC de casa
                stringCommand.Append("inner join Products as p on p.ProductID = o.ProductID ");
                stringCommand.Append("inner join Categories as c on c.CategoryID = p.CategoryID ");
                stringCommand.Append("group by o.ProductID, ProductName, c.CategoryName, p.UnitPrice ");
                stringCommand.Append("order by totalVendas desc");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string tableName)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT * FROM ");
                stringCommand.Append(tableName);
                #endregion

                #region Database connection
                //sqlConnection = new SqlConnection(@"Data Source=MÁRIO-PC\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string tableName, string fieldName, string valueWhere, bool withWhereCondition)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT * FROM ");
                stringCommand.Append(tableName);
                stringCommand.Append(" WHERE ");
                stringCommand.Append(fieldName);
                stringCommand.Append(" = '");
                stringCommand.Append(valueWhere);
                stringCommand.Append("'");
                #endregion

                #region Database connection
                //sqlConnection = new SqlConnection(@"Data Source=MÁRIO-PC\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string fieldWhere, string whereCondition)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT p.ProductID, ProductName, c.CategoryName, p.UnitPrice ");
                stringCommand.Append("FROM Products as p ");
                stringCommand.Append("inner join Categories as c on c.CategoryID = p.CategoryID ");
                stringCommand.Append(" WHERE ");
                stringCommand.Append(fieldWhere);
                stringCommand.Append(" LIKE '%");
                stringCommand.Append(whereCondition);
                stringCommand.Append("%' ");
                stringCommand.Append("group by p.ProductID, ProductName, c.CategoryName, p.UnitPrice");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string fieldName, bool withFielName)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT p.ProductID, ProductName, c.CategoryName, p.UnitPrice ");
                stringCommand.Append("FROM ");
                stringCommand.Append(fieldName);
                stringCommand.Append(" as p ");
                stringCommand.Append("left join Categories as c on c.CategoryID = p.CategoryID ");
                stringCommand.Append("group by p.ProductID, ProductName, c.CategoryName, p.UnitPrice");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string fieldName, bool withFielName, bool withDiscontinuedField)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT p.ProductID, ProductName, c.CategoryName, p.UnitPrice, Discontinued ");
                stringCommand.Append("FROM ");
                stringCommand.Append(fieldName);
                stringCommand.Append(" as p ");
                stringCommand.Append("left join Categories as c on c.CategoryID = p.CategoryID ");
                stringCommand.Append("group by p.ProductID, ProductName, c.CategoryName, p.UnitPrice, Discontinued");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataAdapter DataRead(SqlConnection sqlConnection, string fieldWhere, int whereCondition)
        {
            try
            {
                #region Data command
                StringBuilder stringCommand = new StringBuilder();
                stringCommand.Append("SELECT p.ProductID, ProductName, c.CategoryName, p.UnitPrice ");
                stringCommand.Append("FROM Products as p ");
                stringCommand.Append("inner join Categories as c on c.CategoryID = p.CategoryID ");
                stringCommand.Append(" WHERE ");
                stringCommand.Append(fieldWhere);
                stringCommand.Append(" LIKE '%");
                stringCommand.Append(whereCondition);
                stringCommand.Append("%' ");
                stringCommand.Append("group by p.ProductID, ProductName, c.CategoryName, p.UnitPrice");
                #endregion

                #region Data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringCommand.ToString(), sqlConnection);
                #endregion

                return dataAdapter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}