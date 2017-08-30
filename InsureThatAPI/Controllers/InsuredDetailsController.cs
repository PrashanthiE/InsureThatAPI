using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsureThatAPI.Models;
using InsureThatAPI.CommonMethods;
namespace InsureThatAPI.Controllers
{
    public class InsuredDetailsController : ApiController
    {
        // GET: api/InsuredDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// Get customer details by searching through email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        // GET: api/InsuredDetails/5
        #region GET CUSTOMER DETAILS BY SEARCHING THROUGH EMAILID
        [HttpGet]
        public InsuredDetailsRef Get(string emailId, string name, string phoneno)
        {
          
            InsuredDetailsRef insuredref = new InsuredDetailsRef();
            InsuredDetailsClass insureddetails = new InsuredDetailsClass();
            insuredref = insureddetails.GetInsuredDetails(emailId,name,phoneno);
            return insuredref;
        }
        #endregion

        // POST: api/InsuredDetails
        public InsuredDetailsRef Post([FromBody]InsuredDetails value)
        {
            InsuredDetailsClass insureddetails = new InsuredDetailsClass();
            InsuredDetailsRef insuredref = new InsuredDetailsRef();          
        
            if (string.IsNullOrWhiteSpace(value.ABN.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "ABN is required";
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.EmailID.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "EmailID is required";
                return insuredref;
            }
            if (value.ClientType.HasValue && value.ClientType>0)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Client Type is required";
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.Title.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Title is required";
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.FirstName.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "First Name is required";
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.Lastname.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Last Name is required";
                return insuredref;
            }
            if (value.AddressID.HasValue || value.AddressID==null || value.AddressID<=0)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "AddressID is required";
                return insuredref;
            }
            if (value.PostalAddressID.HasValue || value.PostalAddressID == null || value.PostalAddressID <= 0)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Postal AddressID is required";
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.PhoneNo.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Phone Number is required";
                if(value.PhoneNo.Count()>9 || value.PhoneNo.Count()<9)
                {
                    insuredref.ErrorMessage = "Phone Number is required, must not be more than 9 digits and less than 9 digits.";
                }
                return insuredref;
            }
            if (string.IsNullOrWhiteSpace(value.MobileNo.Trim()))
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Mobile Number is required";
                if (value.MobileNo.Count() > 9 || value.MobileNo.Count() < 9)
                {
                    insuredref.ErrorMessage = "Mobile Number is required, must not be more than 9 digits and less than 9 digits.";
                }
                return insuredref;
            }
            if (value.DOB==null)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "DOB is required";              
                return insuredref;
            }
            int? result = insureddetails.InsertUpdateInsuredDetails(null,value);
            if(result.HasValue && result==1)
            {
                insuredref.Status = "Success";
                         
            }
            else if(result.HasValue && result==-1)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Failed to insert.";
                return insuredref;
            }
            else if (result.HasValue && result == -3)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = "Email Id already exists.";
                return insuredref;
            }
            return insuredref;
        }

        // PUT: api/InsuredDetails/5
        public int? Put(int id, [FromBody]InsuredDetails value)
        {
            int? result = 0;
            InsuredDetailsClass insureddetails = new InsuredDetailsClass();
            if (id > 0)
            {
                result = insureddetails.InsertUpdateInsuredDetails(id, value);
            }
            return result;
        }

        // DELETE: api/InsuredDetails/5
        public void Delete(int id)
        {
        }
    }
}
