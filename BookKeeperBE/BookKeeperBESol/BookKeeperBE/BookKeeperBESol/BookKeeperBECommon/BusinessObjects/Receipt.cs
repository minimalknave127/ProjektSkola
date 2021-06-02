using System;
using System.Collections.Generic;
using BookKeeperBECommon.Enums;



namespace BookKeeperBECommon.BusinessObjects
{


    [Table("BK_RECEIPT")]
    public class Receipt
    {


        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("YEAR")]
        public int Year { get; set; }

        [Column("DIRECTION")]
        public DocumentDirection Direction { get; set; }

        [Column("RECEIPT_NUMBER")]
        public string ReceiptNumber { get; set; }

        [Column("CONTACT_ID")]
        public Contact Contact { get; set; }

        [Column("NOTE")]
        public string Note { get; set; }

        [Column("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }

        [Column("DATE_PAID")]
        public DateTime? DatePaid { get; set; }

        [Column("IS_BOOKED")]
        public bool IsBooked { get; set; }



        public IList<ReceiptItem> ReceiptItems { get; set; }



    }



}
