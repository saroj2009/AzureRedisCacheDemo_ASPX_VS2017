using AzureRedisCacheDemo.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AzureRedisCacheDemo
{
    public partial class TestCachePage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_cache_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                var list = CacheManager.GetCompanyFromCache();

                if (list.Count > 0)
                {
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                }
            //}
        }

        protected void btn_db_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=sarojwebappdb.database.windows.net;" +
"Initial Catalog=sarojwebappdb;" +
"User id=sarojwebappdb;" +
"Password=Saroj@12345678;"; ;
            string sql = "SELECT * FROM tblCompDetailsForRadisCacheDemo";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "tblCompDetailsForRadisCacheDemo");
            connection.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
           // GridView1.DataMember = "tblCompDetailsForRadisCacheDemo";
        }
    }
}