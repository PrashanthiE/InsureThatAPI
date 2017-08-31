using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsureThatAPI.Models;
using InsureThatAPI.CommonMethods;
using static InsureThatAPI.CommonMethods.EnumInsuredDetails;

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
            EnumInsuredDetails.InsuredResult resultEnum = new EnumInsuredDetails.InsuredResult();
            InsuredDetailsRef insuredref = new InsuredDetailsRef();
            List<string> Errors = new List<string>();
            insuredref.ErrorMessage = new List<string>();
            if (string.IsNullOrWhiteSpace(value.ABN.Trim()))
            {               
                Errors.Add("ABN is required");                        
            }
            if (string.IsNullOrWhiteSpace(value.EmailID.Trim()))
            {           
                Errors.Add("EmailID is required");          
            }
            if (value.ClientType==null || value.ClientType<=0)
            { 
                Errors.Add("Client Type is required");             
            }
            if (string.IsNullOrWhiteSpace(value.Title.Trim()))
            {
                Errors.Add("Title is required");              
            }
            if (string.IsNullOrWhiteSpace(value.FirstName.Trim()))
            {             
                Errors.Add("First Name is required");             
            }
            if (string.IsNullOrWhiteSpace(value.Lastname.Trim()))
            {               
                Errors.Add("Last Name is required");               
            }
            if ( value.AddressID == null || value.AddressID <= 0)
            {
                Errors.Add("AddressID is required");
            }
            if (value.PostalAddressID == null || value.PostalAddressID <= 0)
            {             
                Errors.Add("Postal AddressID is required");          
            }
            if (string.IsNullOrWhiteSpace(value.PhoneNo.Trim()))
            {              
                Errors.Add("Phone Number is required");
                if(value.PhoneNo.Count()> (int)InsuredResult.PhoneNumberLength || value.PhoneNo.Count()< (int)InsuredResult.PhoneNumberLength)
                {
                    Errors.Add("Phone Number is required, must not be more than 9 digits and less than 9 digits.");
                }              
            }
            if (string.IsNullOrWhiteSpace(value.MobileNo.Trim()))
            {
               
                Errors.Add("Mobile Number is required");
                if (value.MobileNo.Count() > (int)InsuredResult.PhoneNumberLength || value.MobileNo.Count() < (int)InsuredResult.PhoneNumberLength)
                {
                    Errors.Add("Mobile Number is required, must not be more than 9 digits and less than 9 digits.");
                }
              
            }
            if (value.DOB == null)
            {
                Errors.Add("DOB is required");
            }
            if (Errors!=null && Errors.Count() > 0)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = Errors;
                return insuredref;
            }
            else
            {
                int? result = insureddetails.InsertUpdateInsuredDetails(null, value);
                if (result.HasValue && result>0)
                {
                    insuredref.Status = "Success";
                    insuredref.Insured.InsuredID = result.Value;
                }
                else if (result.HasValue && result == (int)InsuredResult.Exception)
                {
                    insuredref.Status = "Failure";
                    insuredref.ErrorMessage.Add("Failed to insert.");
                   
                }
               
                else if (result.HasValue && result == (int)InsuredResult.EmailAlreadyExists)
                {
                    insuredref.Status = "Failure";
                    insuredref.ErrorMessage.Add("Email Id already exists.");
                   
                }
            }
            return insuredref;
        }

        // PUT: api/InsuredDetails/5
        public InsuredDetailsRef Put(int id, [FromBody]InsuredDetails value)
        {
            int? result = 0;
            InsuredDetailsClass insureddetails = new InsuredDetailsClass();
            InsuredDetailsRef insuredref = new InsuredDetailsRef();
            List<string> Errors = new List<string>();
            insuredref.ErrorMessage = new List<string>();
            if (string.IsNullOrWhiteSpace(value.ABN.Trim()))
            {
                Errors.Add("ABN is required");
            }
            if (string.IsNullOrWhiteSpace(value.EmailID.Trim()))
            {
                Errors.Add("EmailID is required");
            }
            if (value.ClientType == null || value.ClientType <= 0)
            {
                Errors.Add("Client Type is required");
            }
            if (string.IsNullOrWhiteSpace(value.Title.Trim()))
            {
                Errors.Add("Title is required");
            }
            if (string.IsNullOrWhiteSpace(value.FirstName.Trim()))
            {
                Errors.Add("First Name is required");
            }
            if (string.IsNullOrWhiteSpace(value.Lastname.Trim()))
            {
                Errors.Add("Last Name is required");
            }
            if (value.AddressID == null || value.AddressID <= 0)
            {
                Errors.Add("AddressID is required");
            }
            if (value.PostalAddressID == null || value.PostalAddressID <= 0)
            {
                Errors.Add("Postal AddressID is required");
            }
            if (string.IsNullOrWhiteSpace(value.PhoneNo.Trim()))
            {
                Errors.Add("Phone Number is required");
                if (value.PhoneNo.Count() > (int)InsuredResult.PhoneNumberLength || value.PhoneNo.Count() < (int)InsuredResult.PhoneNumberLength)
                {
                    Errors.Add("Phone Number is required, must not be more than 9 digits and less than 9 digits.");
                }
            }
            if (string.IsNullOrWhiteSpace(value.MobileNo.Trim()))
            {

                Errors.Add("Mobile Number is required");
                if (value.MobileNo.Count() > (int)InsuredResult.PhoneNumberLength || value.MobileNo.Count() < (int)InsuredResult.PhoneNumberLength)
                {
                    Errors.Add("Mobile Number is required, must not be more than 9 digits and less than 9 digits.");
                }

            }
            if (value.DOB == null)
            {
                Errors.Add("DOB is required");
            }
            if (Errors != null && Errors.Count() > 0)
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage = Errors;
               
            }
            if (id > 0)
            {
                result = insureddetails.InsertUpdateInsuredDetails(id, value);
                if(result == (int)InsuredResult.UpdatedSuccess)
                {
                    insuredref.Status = "Success";
                }
                if (result == (int)InsuredResult.Exception)
                {
                    insuredref.Status = "Failure";
                    insuredref.ErrorMessage.Add("Failed to insert.");
                }
            }
            else
            {
                insuredref.Status = "Failure";
                insuredref.ErrorMessage.Add("Insured ID is required.");
            }
            return insuredref;

        }

        // DELETE: api/InsuredDetails/5
        public void Delete(int id)
        {
        }
    }
}
