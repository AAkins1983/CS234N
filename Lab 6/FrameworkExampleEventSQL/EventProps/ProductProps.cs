using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader; //Gave data reader an alias to use when we want to swap databases

namespace EventPropsClassses
{
    [Serializable]
    public class ProductProps : IBaseProps
    {
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
        public int ID = Int32.MinValue;

        public string Code = "";

        /// <summary>
        /// 
        /// </summary>
        
        public string Description = "";
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice = 0m;

        /// <summary>
        /// 
        /// </summary>
        public int Quantity = 0;

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly 
        /// Are two people trying to do stuff with the same class at the same time
        /// </summary>
        public int ConcurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor. This object should only be instantiated by Customer, not used directly.
        /// </summary>
        public ProductProps()
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
            this.ID = (Int32)dr["ProductID"]; //properties - fields in database        
            this.Code = ((string)dr["ProductCode"]).Trim();//casting the properties as needed data type
            this.Description = (string)dr["Description"];//taking it out of the data reader (dr)
            this.UnitPrice = (decimal)dr["UnitPrice"];
            this.Quantity = (int)dr["OnHandQuantity"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType()); //De-seralizes the stuff we just seralized
            StringReader reader = new StringReader(xml);
            ProductProps p = (ProductProps)serializer.Deserialize(reader);
            this.ID = p.ID;
            this.Code = p.Code;
            this.Description = p.Description;
            this.UnitPrice = p.UnitPrice;
            this.Quantity = p.Quantity;
            this.ConcurrencyID = p.ConcurrencyID;
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public Object Clone()
        {
            ProductProps p = new ProductProps(); //Puts properties out of objects that we have and puts into the properties we just created
            p.ID = this.ID;
            p.Code = this.Code;
            p.Description = this.Description;
            p.UnitPrice = this.UnitPrice;
            p.Quantity = this.Quantity;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }
        #endregion
    }
}
