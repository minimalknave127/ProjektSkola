using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;



namespace BookKeeperBECommon.BusinessObjects
{


   [Table("BK_INVOICE_ITEM")]
    public class InvoiceItem
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("INVOICE_ID")]
        public Invoice Invoice { get; set; }

        [Column("ORDINAL")]
        public int Ordinal { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("QUANTITY")]
        public double Quantity { get; set; }

        [Column("AMOUNT_PER_UNIT")]
        public decimal AmountPerUnit { get; set; }

        [Column("AMOUNT")]
        public decimal Amount { get; set; }



    }



}
