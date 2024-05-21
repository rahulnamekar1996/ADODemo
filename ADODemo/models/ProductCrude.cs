using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace ADODemo.models
{
    public class ProductCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductCrud()
        {
            string connstr = ConfigurationManager.ConnectionStrings["defaultConnect"].ConnectionString;
            con = new SqlConnection(connstr);
        }

        public int AddProduct(Product prod)
        {
            // step1 -> qry
            string qry = "insert into Product values(@name,@price,@cid)";
            // step2- assign qry to command
            cmd = new SqlCommand(qry, con);
            // step3- pass valeu to the parameters
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            cmd.Parameters.AddWithValue("@cid", prod.Cid);
            // step4- open the connection
            con.Open();
            //step5- fire the query
            int result = cmd.ExecuteNonQuery();
            //step6- close the conn
            con.Close();
            return result;
        }

        public List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            //step1- write a query
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.Cid = Convert.ToInt32(dr["cid"]);
                    c.Cname = dr["cname"].ToString();
                    list.Add(c);
                }

            }
            con.Close();
            return list;
        }
    }

}
