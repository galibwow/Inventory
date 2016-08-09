//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sale
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int customer_id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double total { get; set; }
        public int tax_id { get; set; }
        public System.DateTime sell_date { get; set; }
        public int bundle_id { get; set; }
        public int warehouse_id { get; set; }
    
        public virtual bundle_lot bundle_lot { get; set; }
        public virtual customer customer { get; set; }
        public virtual product product { get; set; }
        public virtual tax tax { get; set; }
        public virtual warehouse warehouse { get; set; }
    }
}