using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerMaintenanceClasses;

namespace CustomerMaintenance
{
    // This is the starting point for exercise 12-1 from
    // "Murach's C# 2010" by Joel Murach
    // (c) 2010 by Mike Murach & Associates, Inc. 
    // www.murach.com

    public partial class frmCustomers : Form
    {
        List<Customer> customers = null;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            Customer c = frm.GetNewCustomer();
            if (c != null)
            {
                customers.Add(c);
                CustomerDB.SaveCustomers(customers);
            }

            lstCustomers.Items.Clear();
            foreach (Customer cx in customers)
                lstCustomers.Items.Add(cx);

        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();

            foreach (Customer c in customers)
                lstCustomers.Items.Add(c);
            
        }
    }
}