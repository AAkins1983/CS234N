using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fillComboButton_Click(object sender, EventArgs e)
        {
            // *** Use both syntax to get a list of state objects sorted by statename
            //List<State> states = MMABooksEntity.mmaBooks.States.OrderBy(s => s.StateName).ToList();
            List<State> states = (from state in MMABooksEntity.mmaBooks.States orderby state.StateCode select state).ToList();
            // *** bind the list to a combo box
            comboBox1.DataSource = states;
            comboBox1.DisplayMember = "StateName";
            comboBox1.ValueMember = "StateCode";

            // *** Use lambda expression syntax to get sorted list of customers
            //List<Customer> customers = MMABooksEntity.mmaBooks.Customers.OrderBy(c => c.Name).ToList();
            // *** Use both syntax filter by state
            //List<Customer> customers = MMABooksEntity.mmaBooks.Customers.Where(c => c.State == "NY").OrderBy(c => c.Name).ToList();
            //List<Customer> customers = (from c in MMABooksEntity.mmaBooks.Customers orderby c.Name select c).ToList();
            // *** create an "implicitly typed" list that contains just the customer id and name
            //var customers = (from c in MMABooksEntity.mmaBooks.Customers orderby c.Name select new { c.CustomerID, c.Name }).ToList();
            //comboBox1.DataSource = customers;
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "CustomerID";

            // *** Can you use both syntax to
            //Get a list of products sorted by product name
            //Get a list of products with a unit price of 56.50 sorted by product name

            
        }

        private void fillGridButton_Click(object sender, EventArgs e)
        {
            // *** Use both syntax to return implicitly typed list
            //var customers = (from c in MMABooksEntity.mmaBooks.Customers orderby c.Name select new { c.CustomerID, c.Name }).ToList();
            //var customers = MMABooksEntity.mmaBooks.Customers.Where(c => c.State == "NY").OrderBy(c => c.Name).Select(c => new { c.CustomerID, c.Name }).ToList();
            // *** Use both syntax to combine customer and state information
            var customers = (from c in MMABooksEntity.mmaBooks.Customers
                             join s in MMABooksEntity.mmaBooks.States
                             on c.State equals s.StateCode
                             orderby c.Name
                             select new { c.CustomerID, c.Name, c.State, s.StateName }).ToList();
            //var customers = MMABooksEntity.mmaBooks.Customers.Join(
            //    MMABooksEntity.mmaBooks.States,
            //    c => c.State,
            //    s => s.StateCode,
            //    (c, s) => new { c.CustomerID, c.Name, c.State, s.StateName }).OrderBy(r => r.StateName).ToList();
            
            dataGridView1.DataSource = customers;

            // *** Can you use both syntax to
            // Get a list of Invoices
            // Add the customer name to the invoices
            // Get a list of items ordered on each invoice
            // Add the product name to the list of items
        }
    }
}
