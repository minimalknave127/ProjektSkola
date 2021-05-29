using System;
using System.Collections.Generic;



namespace BookKeeperBECommon.BusinessObjects
{


   [Table("BK_ACCOUNTING_CODE")]
    public class AccountingCode
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CODE")]
        public string Code { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("NOTE")]
        public string Note { get; set; }

        [Column("IS_TAXABLE")]
        public bool IsTaxable { get; set; }



    }



}
