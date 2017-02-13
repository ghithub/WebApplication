using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessEntities;

namespace WebApplication1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select top 8 * from Customers;");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
            }
        }


        //Code first entity framework add a new student to the database.
        [TestMethod]
        public void AddStudent()
        {
            using (var ctx = new SchoolContext())
            {
                Student s = new Student() { FirstName = "John", LastName = "Doe", MiddleName = "Mike" };
                ctx.Students.Add(s);
                ctx.SaveChanges();
            }
        }
    }   
}
