using Dapper;
using Education.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Education.Areas.Admin.Services
{
    /// <summary>
    /// Class demo use Dapper
    /// </summary>
    public class ProductService
    {
        private IDbConnection connect = new SqlConnection(Config.ConnectString);

        public List<Product> GetAll(string orderby = "ModifiedDateTime", string sortOrder = "desc")
        {
            try
            {
                string query = string.Format("select * from Product order by {0} {1}", orderby, sortOrder);
                List<Product> lstProduct = connect.Query<Product>(query).ToList<Product>();
                return lstProduct;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }
        public Product GetByPrimaryKey(int productID)
        {
            try
            {
                string query = "select * from Product where ProductID = " + productID;
                Product product = connect.Query<Product>(query).FirstOrDefault<Product>();
                return product;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public List<Product> GetByWhere(string where, string orderby = "ModifiedDateTime")
        {
            try
            {
                string query = "";
                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Format("select * from Product where " + where + " order by {0} desc", orderby);
                }
                else
                {
                    query = string.Format("select * from Product order by {0} desc", orderby);
                }
                return connect.Query<Product>(query).ToList<Product>();
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return null;
            }
        }

        public int Insert(Product product)
        {
            try
            {
                string query = "insert into Product(ProductName,ProductContent,ProductShortDescription," +
                        " ProductTitleCard,ProductDescriptionCard,ProductAlias,ProductState,SupplierID ," +
                        " ProductStyleID,ProductUrl,CreatedDateTime,ModifiedDateTime,Tags)" +
                        " values (@ProductName, @ProductContent, @ProductShortDescription,@ProductTitleCard,@ProductDescriptionCard," +
                        " @ProductAlias,@ProductState,@SupplierID,@ProductStyleID,@ProductUrl,@CreatedDateTime,@ModifiedDateTime,@Tags)" +
                        " SELECT @@IDENTITY";
                int productID = connect.Query<int>(query, new
                {
                    product.ProductName,
                    product.ProductContent,
                    product.ProductShortDescription,
                    product.ProductTitleCard,
                    product.ProductDescriptionCard,
                    product.ProductAlias,
                    product.ProductState,
                    product.SupplierID,
                    product.ProductStyleID,
                    product.ProductUrl,
                    product.CreatedDateTime,
                    product.ModifiedDateTime,
                    product.Tags
                }).Single();
                return productID;
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return 0;
            }
        }
        public bool Update(Product product)
        {
            try
            {
                string query = "update Product set ProductName = @productName, ProductContent = @productContent, ProductShortDescription = @productShortDescription," +
                    " ProductTitleCard=@ProductTitleCard,ProductDescriptionCard=@ProductDescriptionCard,ProductAlias=@ProductAlias," +
                    " ProductState = @productState, SupplierID = @supplierID, ProductStyleID = @productStyleID, ModifiedDateTime = @ModifiedDateTime, Tags = @Tags " +
                        " where ProductID = @productID ";
                return 0 < connect.Execute(query, new
                {
                    product.ProductName,
                    product.ProductContent,
                    product.ProductShortDescription,
                    product.ProductTitleCard,
                    product.ProductDescriptionCard,
                    product.ProductAlias,
                    product.ProductState,
                    product.SupplierID,
                    product.ProductStyleID,
                    product.ModifiedDateTime,
                    product.Tags,
                    productID = product.ProductID
                });

            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return false;
            }
        }

        public bool DeleteByPrimary(int productID)
        {
            try
            {
                if (productID <= 0)
                {
                    return false;
                }
                string query = "delete from Product where ProductID = " + productID;
                return 0 < connect.Execute(query);
            }
            catch (Exception ex)
            {
                LogService.WriteException(ex);
                return false;
            }
        }
    }
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        [AllowHtml]
        public string ProductContent { get; set; }
        [AllowHtml]
        public string ProductShortDescription { get; set; }
        public string ProductTitleCard { get; set; }
        public string ProductDescriptionCard { get; set; }
        public string ProductAlias { get; set; }
        public Nullable<bool> ProductState { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> ProductStyleID { get; set; }
        public string ProductUrl { get; set; }
        public string CreatedDateTime { get; set; }
        public string ModifiedDateTime { get; set; }
        public string Tags { get; set; }
        public bool IsNew { get; set; }
        public bool IsSale { get; set; }
        public bool AutoGenerate { get; set; }
    }
}