using System.Data.SqlClient;
using System.Data;


namespace E_Commerce.Modules
{
    public class DrinkCart
    {
        public string CategoryName, ProductName, ProductImage, ProductPrice, ProductDescription;
        public int CategoryID;

        public void AddNewCategory()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            //parameters[0] = DataAccess.AddParamater("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            parameters[0] = DataAccess.AddParamater("@CategoryName", CategoryName, SqlDbType.VarChar, 200);
            DataTable dt = DataAccess.ExecuteDTByProcedure("SP_AddNewCategory", parameters);
        }

        public void AddNewProduct()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataAccess.AddParamater("@ProductName", ProductName, SqlDbType.VarChar, 300);
            parameters[1] = DataAccess.AddParamater("@ProductPrice", ProductPrice, SqlDbType.Int, 100);
            parameters[2] = DataAccess.AddParamater("@ProductImage", ProductImage, SqlDbType.VarChar, 500);
            parameters[3] = DataAccess.AddParamater("@ProductDescription", ProductDescription, SqlDbType.VarChar, 1000);
            parameters[4] = DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataAccess.ExecuteDTByProcedure("SP_AddNewProduct", parameters);
        }

        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataAccess.ExecuteDTByProcedure("SP_GetAllCategories", parameters);
            return dt;
        }
    }
}