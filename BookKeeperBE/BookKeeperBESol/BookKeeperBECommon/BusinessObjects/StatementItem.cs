using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookKeeperBECommon.BusinessObjects
{


    [Table("BK_STATEMENT_ITEM")]
    public class StatementItem
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Key]
        [Column("STATEMENT_ID")]
        public Statement Statement { get; set; }

        [Column("ORDINAL")]
        public int Ordinal { get; set; }

        [Column("DATE_TRANSACTION")]
        public DateTime? DateTransaction { get; set; }
  
        [Column("DESCREPTION")]
        public string Description { get; set; }
 
        [Column("ACCOUNTING_CODE_ID")]
        public User Accounting { get; set; }
  
        [Column("CONTACT_ID")]
        public Contact Contact { get; set; }
 
        [Column("AMOUNT")]
        public decimal Amount { get; set; }
    
        [Column("CONTRA_ACCOUNT")]
        public string ContraAccount { get; set; }
  
        [Column("VS")]
        public string Vs { get; set; }
   
        [Column("KS")]
        public string Ks { get; set; }

        [Column("SS")]
        public string Ss { get; set; }



    }



}
