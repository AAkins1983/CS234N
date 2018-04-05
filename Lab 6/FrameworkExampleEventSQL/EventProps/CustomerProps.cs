using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader; 

namespace EventPropsClasses
{
    [Serializable]
    public class CustomerProps : IBaseProps
    {
        //ID, Name, Address, City, State, ZipCode, ConcurrencyID
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
         
        public int ID = Int32.MinValue;
        /// <summary>
        /// 
        /// </summary>

        public string Name = "";
        /// <summary>
        /// 
        /// </summary>
         
        public string Address = "";
        /// <summary>
        /// 
        /// </summary>

        public string City = "";
        /// <summary>
        /// 
        /// </summary>

        public string State = "";
        /// <summary>
        /// 
        /// </summary>

        public int ZipCode = 0;
        /// <summary>
        /// 
        /// </summary>

        public int ConcurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// 
        /// </summary>
        public CustomerProps()
        {
        }
        #endregion

        #region BaseProps Members
        /// <summary>
        /// Serializes this props object to XML, and writes the key-value pairs to a string.
        /// </summary>
        /// <returns>String containing key-value pairs</returns>
        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType()); //Takes object and turns it into a string
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        // I don't always want to generate xml in the db class so the 
        // props class can read in from xml
        public void SetState(DBDataReader dr) //Takes fields out of the database and puts it into object
        {
            this.ID = (Int32)dr["CustomerID"]; //properties - fields in database        
            this.Name = (string)dr["Name"];//casting the properties as needed data type
            this.Address = (string)dr["Address"];//taking it out of the data reader (dr)
            this.City = (string)dr["City"];
            this.State = (string)dr["State"];
            this.ZipCode = (int)dr["ZipCode"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType()); //De-seralizes the stuff we just seralized
            StringReader reader = new StringReader(xml);
            CustomerProps c = (CustomerProps)serializer.Deserialize(reader);
            this.ID = c.ID;
            this.Name = c.Name;
            this.Address = c.Address;
            this.City = c.City;
            this.State = c.State;
            this.ZipCode = c.ZipCode;
            this.ConcurrencyID = c.ConcurrencyID;
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public Object Clone()
        {
            CustomerProps c = new CustomerProps(); //Puts properties out of objects that we have and puts into the properties we just created
            c.ID = this.ID;
            c.Name = this.Name;
            c.Address = this.Address;
            c.City = this.City;
            c.State = this.State;
            c.ZipCode = this.ZipCode;
            c.ConcurrencyID = this.ConcurrencyID;
            return c;
        }
        #endregion
    }
}
