using System;
using System.Collections.Generic;
using BookKeeperBECommon.Enums;



namespace BookKeeperBECommon.BusinessObjects
{


   [Table("BK_INVOICE")]
    public class Invoice
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("YEAR")]
        public int Year { get; set; }

        [Column("DIRECTION")]
        public DocumentDirection Direction { get; set; }

        [Column("INVOICE_NUMBER")]
        public string InvoiceNumber { get; set; }

        [Column("CONTACT_ID")]
        public Contact Contact { get; set; }

        [Column("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }

        [Column("DATE_ISSUED")]
        public DateTime? DateIssued { get; set; }

        [Column("DATE_DUE")]
        public DateTime? DateDue { get; set; }



        public IList<InvoiceItem> InvoiceItems { get; set; }



    }



}
