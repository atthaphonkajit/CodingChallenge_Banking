using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge_Banking
{
    public class Account
    {
        public string IBAN { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public decimal accountBalance { get; set; }

    }
}