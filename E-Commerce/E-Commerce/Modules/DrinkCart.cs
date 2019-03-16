using System.Data.SqlClient;
using System.Data;


namespace E_Commerce.Modules
{
    public class DrinkCart
    {
        public string CategoryName, ProductName, ProductImage, ProductPrice, ProductDescription;
        public int CategoryId;

        public void AddNewCategory()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            //parameters[0] = DataAccess.AddParamater("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            parameters[0] = DataAccess.AddParamater("@CategoryName", CategoryName, SqlDbType.VarChar, 200);
            DataTable dt = DataAccess.ExecuteDTByProcedure("SP_AddNewCategory", parameters);
        }

        public void AddNewProduct()
        {

        }

        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataAccess.ExecuteDTByProcedure("SP_GetAllCategories", parameters);
            return dt;
        }
    }
}