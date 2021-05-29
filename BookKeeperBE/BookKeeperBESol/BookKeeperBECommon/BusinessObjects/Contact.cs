using System;
using System.Collections.Generic;



namespace BookKeeperBECommon.BusinessObjects
{


   [Table("BK_CONTACT")]
    public class Contact
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("ICO")]
        public string Ico { get; set; }

        [Column("DIC")]
        public string Dic { get; set; }

        [Column("BANK_ACCOUNT")]
        public string BankAccount { get; set; }

        [Column("MOBILE")]
        public string Mobile { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("WWW")]
        public string Www { get; set; }

        [Column("ADRESS_STREET")]
        public string AddressStreet { get; set; }

        [Column("ADRESS_CITY")]
        public string AddressCity { get; set; }

        [Column("ADRESS_ZIP")]
        public string AddressZip { get; set; }

        [Column("ADRESS_COUNTRY")]
        public string AddressCountry { get; set; }



    }



}
