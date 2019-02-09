
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Threading.Tasks;
using BusinessEntities;
using WebApi.ActionFilters;
using BusinessServices;

namespace WebApi.Controllers
{
    // [AuthorizationRequired]
    [RoutePrefix("Manpower")]
    public class ManpowerController : ApiController
    {
        private readonly IManPower _obj;
       
        public ManpowerController(IManPower obj)
        {
            _obj = obj;           
        }

        [Route("GetAllManPowerMaster")]
        [HttpPost]
        public HttpResponseMessage GetAllManPowerMaster(GetManpowerDTO objGetMaster)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetAllManPowerMaster(objGetMaster) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetAllManPowerMaster");
            }
            return message;
        }

        [Route("GetAgeCalculation")]
        [HttpPost]
        public HttpResponseMessage GetAgeCalculation(GetAgeDTO objGetAge)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetAgeCalculation(objGetAge) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetAge");
            }
            return message;
        }

        [Route("GetProofMaster")]
        [HttpPost]
        public HttpResponseMessage GetProofMaster(GetManpowerDTO objGetProof)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetProofMaster(objGetProof) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetProofMaster");
            }
            return message;
        }

        [Route("GetVerifyDetail")]
        [HttpPost]
        public HttpResponseMessage GetVerifyDetail(GetProofDTO objGetVerify)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetVerifyDetail(objGetVerify) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetVerifyDetail");
            }
            return message;
        }

        [Route("GetManpowerFamily")]
        [HttpPost]
        public HttpResponseMessage GetManpowerFamily(GetProofDTO objGetFamily)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetManpowerFamily(objGetFamily) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetManpowerFamily");
            }
            return message;
        }

        [Route("CreateManPower")]
        [HttpPost]
        public HttpResponseMessage CreateManPower(ManpowerInsertDTO objManPower)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.InsertManPower(objManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "CreateManPower");
            }
            return message;
        }

        [Route("UpdateManPower")]
        [HttpPost]
        public HttpResponseMessage UpdateManPower(ManpowerUpdateDTO objManPower)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.UpdateManPower(objManPower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "UpdateManPower");
            }
            return message;
        }

        [Route("CreateProofDetail")]
        [HttpPost]
        public HttpResponseMessage CreateProofDetail(ManpowerProofInsertDTO objVerifyProof)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.InsertVerifyProof(objVerifyProof) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "CreateProofDetail");
            }
            return message;
        }

        [Route("CreateManpowerFamily")]
        [HttpPost]
        public HttpResponseMessage CreateManpowerFamily(ManpowerFamilyInsertDTO objFamily)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.InsertManpowerFamily(objFamily) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "CreateManpowerFamily");
            }
            return message;
        }

        [Route("GetAllPayment")]
        [HttpPost]
        public HttpResponseMessage GetAllPayment()
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetAllManPayment() };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetAllPayment");
            }
            return message;
        }


        //Create New ManpowerDetils
        [Route("CreateManpowerDetils")]
        [HttpPost]
        public HttpResponseMessage CreateManpowerDetils()
        {
            HttpResponseMessage message;

            ManpowerInsertDTO objManpower = new ManpowerInsertDTO();

            var VerifyProof = HttpContext.Current.Request.Files[0];
            var PhotoName = DateTime.Now.Ticks + "_" + VerifyProof.FileName;
            objManpower.Name = HttpContext.Current.Request.Form[0];
            objManpower.Gender = HttpContext.Current.Request.Form[1];
            var DateofBirth = HttpContext.Current.Request.Form[2];
            var Age = HttpContext.Current.Request.Form[3];
            objManpower.Mobile = HttpContext.Current.Request.Form[4];
            objManpower.AlternateNumber = HttpContext.Current.Request.Form[5];
            var MaritalStatus = HttpContext.Current.Request.Form[6];
            objManpower.CurrentAddress = HttpContext.Current.Request.Form[7];
            objManpower.PermanentAddress = HttpContext.Current.Request.Form[8];
            objManpower.Photo = PhotoName;
            var State = HttpContext.Current.Request.Form[9];
            var City = HttpContext.Current.Request.Form[10];
            objManpower.JobType = HttpContext.Current.Request.Form[11];
            var Company = HttpContext.Current.Request.Form[12];
            var DateofJoin = HttpContext.Current.Request.Form[13];
            var Designation = HttpContext.Current.Request.Form[14];
            objManpower.ReferenceBy = HttpContext.Current.Request.Form[15];
            objManpower.PreviousCompany = HttpContext.Current.Request.Form[16];
            objManpower.ReferenceContact1 = HttpContext.Current.Request.Form[17];
            objManpower.ReferenceContact2 = HttpContext.Current.Request.Form[18];
            objManpower.TotalExperience = HttpContext.Current.Request.Form[19];
            var VerificationStatus = HttpContext.Current.Request.Form[20];
            objManpower.FatherName = HttpContext.Current.Request.Form[21];
            objManpower.MotherName = HttpContext.Current.Request.Form[22];
            var Payment = HttpContext.Current.Request.Form[23];
            objManpower.CreatedBy = HttpContext.Current.Request.Form[24];

            objManpower.DateofBirth = Convert.ToDateTime(DateofBirth);
            objManpower.Age = Convert.ToInt16(Age);
            objManpower.MaritalStatus = Convert.ToByte(MaritalStatus);
            objManpower.State = Convert.ToInt32(State);
            objManpower.City = Convert.ToInt32(City);
            objManpower.DateofJoin = Convert.ToDateTime(DateofJoin);
            objManpower.Company = Convert.ToInt32(Company);
            objManpower.Designation = Convert.ToInt32(Designation);
            objManpower.VerificationStatus = Convert.ToByte(VerificationStatus);
            objManpower.Payment = Convert.ToInt32(Payment);
            if (VerifyProof != null && PhotoName != null)
            {
                var pathf = HttpContext.Current.Server.MapPath("~/PersonalImages");
                var fileSavePath = Path.Combine(pathf, PhotoName);

                Directory.CreateDirectory(pathf);
                VerifyProof.SaveAs(fileSavePath);
            }

            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.InsertManPower(objManpower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "CreateManpowerDetils");
            }

            return message;
        }

        //Update ManpowerDetils
        [Route("UpdateManpowerDetils")]
        [HttpPost]
        public HttpResponseMessage UpdateManpowerDetils()
        {
            HttpResponseMessage message;

            ManpowerUpdateDTO objManpower = new ManpowerUpdateDTO();

            var VerifyProof = HttpContext.Current.Request.Files[0];
            var PhotoName = DateTime.Now.Ticks + "_" + VerifyProof.FileName;
            objManpower.Name = HttpContext.Current.Request.Form[0];
            objManpower.Gender = HttpContext.Current.Request.Form[1];
            var DateofBirth = HttpContext.Current.Request.Form[2];
            var Age = HttpContext.Current.Request.Form[3];
            objManpower.Mobile = HttpContext.Current.Request.Form[4];
            objManpower.AlternateNumber = HttpContext.Current.Request.Form[5];
            var MaritalStatus = HttpContext.Current.Request.Form[6];
            objManpower.CurrentAddress = HttpContext.Current.Request.Form[7];
            objManpower.PermanentAddress = HttpContext.Current.Request.Form[8];
            objManpower.Photo = PhotoName;
            var State = HttpContext.Current.Request.Form[9];
            var City = HttpContext.Current.Request.Form[10];
            objManpower.JobType = HttpContext.Current.Request.Form[11];
            var Company = HttpContext.Current.Request.Form[12];
            var DateofJoin = HttpContext.Current.Request.Form[13];
            var Designation = HttpContext.Current.Request.Form[14];
            objManpower.ReferenceBy = HttpContext.Current.Request.Form[15];
            objManpower.PreviousCompany = HttpContext.Current.Request.Form[16];
            objManpower.ReferenceContact1 = HttpContext.Current.Request.Form[17];
            objManpower.ReferenceContact2 = HttpContext.Current.Request.Form[18];
            objManpower.TotalExperience = HttpContext.Current.Request.Form[19];
            var VerificationStatus = HttpContext.Current.Request.Form[20];
            objManpower.FatherName = HttpContext.Current.Request.Form[21];
            objManpower.MotherName = HttpContext.Current.Request.Form[22];
            var Payment = HttpContext.Current.Request.Form[23];

            objManpower.ModifiedBy = HttpContext.Current.Request.Form[24];
            var Active = HttpContext.Current.Request.Form[25];
            var ManPowerId = HttpContext.Current.Request.Form[26];

            objManpower.DateofBirth = Convert.ToDateTime(DateofBirth);
            objManpower.Age = Convert.ToInt16(Age);
            objManpower.MaritalStatus = Convert.ToByte(MaritalStatus);
            objManpower.State = Convert.ToInt32(State);
            objManpower.City = Convert.ToInt32(City);
            objManpower.DateofJoin = Convert.ToDateTime(DateofJoin);
            objManpower.Company = Convert.ToInt32(Company);
            objManpower.Designation = Convert.ToInt32(Designation);
            objManpower.VerificationStatus = Convert.ToByte(VerificationStatus);
            objManpower.Active = Convert.ToByte(Active);
            objManpower.ManPowerId = Convert.ToInt32(ManPowerId);
            objManpower.Payment = Convert.ToInt32(Payment);

            if (VerifyProof != null && PhotoName != null)
            {
                var pathf = HttpContext.Current.Server.MapPath("~/PersonalImages");
                var fileSavePath = Path.Combine(pathf, PhotoName);

                Directory.CreateDirectory(pathf);
                VerifyProof.SaveAs(fileSavePath);
            }

            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.UpdateManPower(objManpower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "UpdateManpowerDetils");
            }

            return message;
        }

        //Create New ProofDetils--
        [Route("VerifyProofDetils")]
        [HttpPost]
        public HttpResponseMessage VerifyProofDetils()
        {
            bool res = false;
            HttpResponseMessage message;

            ManpowerProofInsertDTO objVerifyDetil = new ManpowerProofInsertDTO();

            var VerifyProof = HttpContext.Current.Request.Files[0];
            var ProofFileName = DateTime.Now.Ticks + "_" + VerifyProof.FileName;
            var ManpowerId = HttpContext.Current.Request.Form[0];
            var ProofId = HttpContext.Current.Request.Form[1];
            objVerifyDetil.ProofCardNo = HttpContext.Current.Request.Form[2];
            objVerifyDetil.CreatedBy = HttpContext.Current.Request.Form[3];
            objVerifyDetil.ProofUrl = ProofFileName;
            objVerifyDetil.ManpowerId = Convert.ToInt32(ManpowerId);
            objVerifyDetil.ProofId = Convert.ToInt32(ProofId);
            CreateProofDetail(objVerifyDetil);
            if (VerifyProof != null && ProofFileName != null)
            {
                var pathf = HttpContext.Current.Server.MapPath("~/ProofImages");
                var fileSavePath = Path.Combine(pathf, ProofFileName);

                Directory.CreateDirectory(pathf);
                VerifyProof.SaveAs(fileSavePath);
                res = true;
            }

            return message = Request.CreateResponse(HttpStatusCode.OK, new { msgText = "Success!", result = res });

        }


        //Remove Manpower Family Detail 
        [Route("RemoveManpowerFamily")]
        [HttpPost]
        public HttpResponseMessage RemoveManpowerFamily(RemoveFamilyDTO objfamily)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.RemoveManpowerFamily(objfamily) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "RemoveManpowerFamily");
            }
            return message;
        }

        //Remove Manpower Detail 
        [Route("RemoveManpower")]
        [HttpPost]
        public HttpResponseMessage RemoveManpower(GetProofDTO objManpower)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.RemoveManpower(objManpower) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "RemoveManpower");
            }
            return message;
        }

        //Remove Manpower Verify Detail 
        [Route("RemoveManpowerVerify")]
        [HttpPost]
        public HttpResponseMessage RemoveManpowerVerify(RemoveVerifyDTO objVerify)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();

                var dynObj = new { result = _obj.RemoveManpowerVerify(objVerify) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);

                if (dynObj.result)
                {
                    var pathf = HttpContext.Current.Server.MapPath("~/ProofImages");
                    var fileDeletePath = Path.Combine(pathf, objVerify.ProofUrl);
                    File.Delete(fileDeletePath);
                }

            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "RemoveManpower");
            }
            return message;
        }

        [Route("SearchManpower")]
        [HttpPost]
        public HttpResponseMessage SearchManpower(GetVerifyDTO objSearch)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.SearchManpower(objSearch) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "RemoveManpower");
            }
            return message;
        }

        #region Create Manpower Bank details
        [Route("CreateManpowerBankDetails")]
        [HttpPost]
        public HttpResponseMessage CreateManpowerBankDetails()
        {


            HttpResponseMessage message;
            ManpowerBankDetailsInsertDTO objBankDetails = new ManpowerBankDetailsInsertDTO();

            var BankDetail = HttpContext.Current.Request.Files[0];
            var PassbookFileName = DateTime.Now.Ticks + "_" + BankDetail.FileName;
            var ManpowerId = HttpContext.Current.Request.Form[0];
            var BankId = HttpContext.Current.Request.Form[1];
            var AccountType = HttpContext.Current.Request.Form[2];
            objBankDetails.AccountNumber = HttpContext.Current.Request.Form[3];
            objBankDetails.IFSCCode = HttpContext.Current.Request.Form[4];
            objBankDetails.CreatedBy = HttpContext.Current.Request.Form[5];
            objBankDetails.PassbookUrl = PassbookFileName;
            objBankDetails.ManpowerId = Convert.ToInt32(ManpowerId);
            objBankDetails.BankId = Convert.ToInt32(BankId);
            objBankDetails.AccountType = Convert.ToInt32(AccountType);

            if (BankDetail != null && PassbookFileName != null)
            {
                var pathf = HttpContext.Current.Server.MapPath("~/PassbookImages");
                var fileSavePath = Path.Combine(pathf, PassbookFileName);

                Directory.CreateDirectory(pathf);
                BankDetail.SaveAs(fileSavePath);
            }

            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.InsertManpowerBankDetails(objBankDetails) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "CreateManpower Bank");
            }
            return message;
        }
        #endregion

        #region Get Manpower bank details
        [Route("GetManpowerBankDetails")]
        [HttpPost]
        public HttpResponseMessage GetManpowerBankDetails(ManpowerBankDetailsGetDTO objManpowerBankDetails)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetManpowerBankDetails(objManpowerBankDetails) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetManpowerBank");
            }
            return message;
        }

        #endregion

        #region Get bank Master details
        [Route("GetAllBankNameList")]
        [HttpPost]
        public HttpResponseMessage GetAllBankNameList()
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetAllBankNameList() };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetAllBankList");
            }
            return message;
        }

        #endregion

        #region Get Account type master
        [Route("GetAllAccountType")]
        [HttpPost]
        public HttpResponseMessage GetAllAccountType()
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();
                var dynObj = new { result = _obj.GetAllAccountTypeList() };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = "Somthing wrong, Try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "GetAllAccountTypeList");
            }
            return message;
        }

        #endregion
        //Remove Manpower Bank Detail 
        [Route("RemoveManpowerBank")]
        [HttpPost]
        public HttpResponseMessage RemoveManpowerBank(RemoveBankDTO objBank)
        {
            HttpResponseMessage message;
            try
            {
               // ManPowerDataAccessLayer dal = new ManPowerDataAccessLayer();

                var dynObj = new { result = _obj.RemoveManpowerBank(objBank) };
                message = Request.CreateResponse(HttpStatusCode.OK, dynObj);

                if (dynObj.result)
                {
                    var pathf = HttpContext.Current.Server.MapPath("~/PassbookImages");
                    var fileDeletePath = Path.Combine(pathf, objBank.PassbookUrl);
                    File.Delete(fileDeletePath);
                }

            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, new { msgText = " Something wrong,try Again!" });
                ErrorLog.CreateErrorMessage(ex, "ManPower", "RemoveManpowerBank");
            }
            return message;
        }

    }
}
