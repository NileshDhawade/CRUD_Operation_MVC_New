using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CRUD_In_MVC_New_Project.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        // public List<Product> Products { get; private set; }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            cmd = new SqlCommand("select * from Product", con);
            con.Open();
            dr = cmd.ExecuteReader();
            list = ArrageList(dr);
            con.Close();
            return list;
        }
        public int Save(Product p)
        {
            cmd = new SqlCommand("insert into Product values(@name,@price)", con);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@price", p.price);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public List<Product> ArrageList(SqlDataReader dr)
        {
            List<Product> list = new List<Product>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(dr["id"]);
                    p.name = dr["name"].ToString();
                    p.price = Convert.ToDecimal(dr["price"]);
                    list.Add(p);
                }
                return list;
            }
            else
            {
                return null;
            }
        }
        public Product GetProductByid(int id)
        {
            Product prod = new Product();
            cmd = new SqlCommand("select * from Product where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod.id = Convert.ToInt32(dr["id"]);
                    prod.name = dr["name"].ToString();
                    prod.price = Convert.ToDecimal(dr["price"]);
                }

            }
            con.Close();
            return prod;
        }

        public int Upate(Product p)
        {
            cmd = new SqlCommand("update Product set name=@name,price=@price where id=@id", con);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@price", p.price);
            cmd.Parameters.AddWithValue("@id", p.id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            cmd = new SqlCommand("delete from Product where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }



    }
}
