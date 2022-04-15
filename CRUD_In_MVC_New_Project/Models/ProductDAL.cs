namespace CRUD_In_MVC_New_Project.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter dr;

        public ProductDAL()
        {
            con = new SqlConnection(StartUp.ConnectionString);
        }

        // public List<Product> Products { get; private set; }

        public List<Product> GetAllProduct()
        {
            string qry = "Select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();





            //Retrieve data from table and Display result
            List<Product> products = new List<Product>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.name = dr["Name"].ToString();
                    p.id = Convert.ToInt32(dr["ID"].ToString());
                    p.price = Convert.ToInt32(dr["Price"]);
                    products.Add(p);
                }
            }

            //Close the connection
            con.Close();
            return products;

        }
        public int Save(Product p)
        {
            return 0;
        }
    }
}
