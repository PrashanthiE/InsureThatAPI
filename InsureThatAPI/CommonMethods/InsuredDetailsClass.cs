using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsureThatAPI.Models;
namespace InsureThatAPI.CommonMethods
{
    public class InsuredDetailsClass
    {
        #region GET INSURED CUSTOMER DETAILS
        /// <summary>
        /// Get Customer Details by passing Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public InsuredDetailsRef GetInsuredDetails(string emailid,string name, string phoneno)
        {
            InsuredDetailsRef insuredref = new InsuredDetailsRef();
            InsuredDetails insureddetailsmodel = new InsuredDetails();
            MasterDataEntities db = new MasterDataEntities();
            try
            {
                if (emailid != null)
                {

                    var Insured = db.IT_CC_GET_InsuredDetails(emailid,name,phoneno).FirstOrDefault();
                    if (Insured != null)
                    {

                        insureddetailsmodel.ClientType = Convert.ToInt16(Insured.ClientType);
                        insureddetailsmodel.InsuredID = Insured.InsuredID;
                        insureddetailsmodel.Title = Insured.Title;
                        insureddetailsmodel.FirstName = Insured.FirstName;
                        insureddetailsmodel.Lastname = Insured.LastName;
                        insureddetailsmodel.MiddleName = Insured.MiddleName;
                        insureddetailsmodel.CompanyBusinessName = Insured.CompanyBusinessName;
                        insureddetailsmodel.TradingName = Insured.TradingName;
                        insureddetailsmodel.ABN = Insured.ABN;
                        insureddetailsmodel.AddressID = Convert.ToInt16(Insured.AddressID);
                        insureddetailsmodel.PostalAddressID = Convert.ToInt16(Insured.PostalAddressID);
                        insureddetailsmodel.PhoneNo = Insured.PhoneNo;
                        insureddetailsmodel.MobileNo = Insured.MobileNo;
                        insureddetailsmodel.DOB = Convert.ToDateTime(Insured.DOB);
                        insureddetailsmodel.EmailID = Insured.EmailID;
                        insuredref.Insured = insureddetailsmodel;
                        insuredref.Status = "Success";
                    }
                    else
                    {

                        insuredref.ErrorMessage = "No Data Available";
                        insuredref.Status = "Failure";
                    }
                }
            }
            catch (Exception xp)
            {

            }
            finally
            {

            }
            return insuredref;
        }
        #endregion

        #region INSURT AND UPDATE INSURED CUSTOMER DETAILS
        /// <summary>
        /// Get Customer Details by passing Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public int? InsertUpdateInsuredDetails(int? ID,InsuredDetails insureddetailsmodel)
        {
            int? result = 0;
            try
            {
                MasterDataEntities db = new MasterDataEntities();
                if (ID.HasValue && ID>0)
                {//UPDATE the Insured Details
                    result = db.IT_CC_Insert_InsuredDetails(ID, insureddetailsmodel.ClientType, insureddetailsmodel.Title, insureddetailsmodel.FirstName, insureddetailsmodel.Lastname, insureddetailsmodel.MiddleName, insureddetailsmodel.CompanyBusinessName, insureddetailsmodel.TradingName, insureddetailsmodel.ABN, insureddetailsmodel.AddressID, insureddetailsmodel.PostalAddressID, insureddetailsmodel.PhoneNo, insureddetailsmodel.MobileNo, insureddetailsmodel.DOB, insureddetailsmodel.EmailID).SingleOrDefault();
                }
                else
                {
                    //INSERT the Insured details
                    result = db.IT_CC_Insert_InsuredDetails(null, insureddetailsmodel.ClientType, insureddetailsmodel.Title, insureddetailsmodel.FirstName, insureddetailsmodel.Lastname, insureddetailsmodel.MiddleName, insureddetailsmodel.CompanyBusinessName, insureddetailsmodel.TradingName, insureddetailsmodel.ABN, insureddetailsmodel.AddressID, insureddetailsmodel.PostalAddressID, insureddetailsmodel.PhoneNo, insureddetailsmodel.MobileNo, insureddetailsmodel.DOB, insureddetailsmodel.EmailID).SingleOrDefault();
                }

            }
            catch (Exception xp)
            {

            }
            finally
            {

            }
            return result;
        }
        #endregion


    }
}