using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using EventPropsClasses;
using EventPropsClassses;
using EventDBClasses;

using System.Data;
using System.Data.SqlClient;
using DBCommand = System.Data.SqlClient.SqlCommand;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductDBTests
    {
        private string dataSource = "Data Source=MANDA\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        private CustomerSQLDB db;

        [SetUp]
        public void TestResetDatabase()
        {
            db = new CustomerSQLDB(dataSource);
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestProductDBRetrieve()
        {
            ProductProps props = (ProductProps)db.Retrieve(1);
            Assert.AreEqual("A4CS", props.Code);
        }

        [Test]
        public void TestProductDBRetrieveAll()
        {
            List<ProductProps> list = new List<ProductProps>();
            list = (List<ProductProps>)db.RetrieveAll(list.GetType()); //This is different than anything else we've done before -- type class
            Assert.AreEqual(16, list.Count);
        }

        [Test]
        public void TestProductDBCreate()
        {
            ProductProps p = new ProductProps();
            p.Code = "p100";
            p.Description = "Test Product";
            p.Quantity = 10;
            p.UnitPrice = 100m;

            ProductProps newP = (ProductProps)db.Create(p);
            Assert.AreEqual(17, newP.ID);
            Assert.AreEqual(newP.ConcurrencyID, 1);
        }

        [Test]
        public void TestProductDBUpdate()
        {
            //ProductProps p = new ProductProps();
            //p.Code = "p100";
            //p.Description = "Test Product";
            //p.Quantity = 10;
            //p.UnitPrice = 100m;
        }

        [Test]
        public void TestProductDBDelete()
        {
            ProductProps p = new ProductProps();           
        }
    }
}
