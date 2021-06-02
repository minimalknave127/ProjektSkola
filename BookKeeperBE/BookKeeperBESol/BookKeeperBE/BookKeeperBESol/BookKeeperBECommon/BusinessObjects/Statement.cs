using System;
using System.Collections.Generic;



namespace BookKeeperBECommon.BusinessObjects
{


   [Table("BK_STATEMENT")]
    public class Statement
    {

        [Key]
        [Column("ID")]
         public int ID { get; set; }
         
        [Column("YEAR")]
        public int Year { get; set; }
    
        [Column("STATEMENT_NUMBER")]
        public string StatementNumber { get; set; }

        [Column("DATE_ISSUED")]
        public DateTime? DateIssued { get; set; }

       [Column("IS_BOOKED")]
        public bool IsBooked { get; set; }



        public IList<StatementItem> StatementItems { get; set; }



    }



}
