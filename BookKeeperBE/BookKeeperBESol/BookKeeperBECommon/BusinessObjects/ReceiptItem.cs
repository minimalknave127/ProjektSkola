using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeperBECommon.BusinessObjects
{


    [Table("BK_RECEIPT_ITEM")]
    public class ReceiptItem
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("RECEIPT_ID")]
        public Receipt Receipt { get; set; }

        [Column("ORDINAL")]
        public int Ordinal { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("ACCOUNTING_CODE_ID")]
        public User Accounting { get; set; }

        [Column("AMOUNT")]
        public decimal Amount { get; set; }



    }



}
