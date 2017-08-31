using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsureThatAPI.Models
{
    #region CUSTOMER DETAILS
    public class InsuredDetailsRef
    {
       
        public InsuredDetails Insured { get; set; }
        public string Status { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
      public class InsuredDetails
    {
        public int InsuredID { get; set; }
        public int? ClientType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string CompanyBusinessName { get; set; }
        public string TradingName { get; set; }
        public string ABN { get; set; }
        public int? AddressID { get; set; }
        public int? PostalAddressID { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DOB { get; set; }
        public string EmailID { get; set; }
      

    }
    #endregion
}
