using BusinessEntities;
using DataModel.DBLayer;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class BDMAppointmentDetailDAL:IBDMAppointment
    {

        private readonly IUnitOfWork _unitOfWork;

        public BDMAppointmentDetailDAL(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<BDMAppointmentServerFilter> GetAllAppointmentDetails(BDMAppoinmentDetailGetDetailDTO objAppointmentDetail)
        {
            List<BDMAppointmentServerFilter> appoinment = new List<BDMAppointmentServerFilter>();
            using (DbLayer dbLayer = new DbLayer())
            {
                if(objAppointmentDetail.Position == 1)
                {
                    SqlCommand SqlCmd = new SqlCommand("spCEOSelectBDMAppoinmentDetail");
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@Position", objAppointmentDetail.Position);
                    if (objAppointmentDetail.FromDate.Year != 1)
                    {
                        SqlCmd.Parameters.AddWithValue("@FromDate", objAppointmentDetail.FromDate);
                        if (objAppointmentDetail.ToDate.Year != 1)
                        {
                            SqlCmd.Parameters.AddWithValue("@ToDate", objAppointmentDetail.ToDate);
                        }
                    }
                    else
                    {
                        SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    }
    
                    SqlCmd.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ActionBy);
                    appoinment = dbLayer.GetEntityList<BDMAppointmentServerFilter>(SqlCmd); 
                }               
                else
                {
                    SqlCommand SqlCmd1 = new SqlCommand("spSelectBDMAppoinmentDetail");
                    SqlCmd1.CommandType = CommandType.StoredProcedure;
                    SqlCmd1.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ActionBy);
                    if (objAppointmentDetail.FromDate.Year != 1)
                    {
                        SqlCmd1.Parameters.AddWithValue("@FromDate", objAppointmentDetail.FromDate);
                        if (objAppointmentDetail.ToDate.Year != 1)
                        {
                            SqlCmd1.Parameters.AddWithValue("@ToDate", objAppointmentDetail.ToDate);
                        }
                    }
                    else
                    {
                        SqlCmd1.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        SqlCmd1.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    }
                    appoinment = dbLayer.GetEntityList<BDMAppointmentServerFilter>(SqlCmd1);
                }
              
            }
            return appoinment;
        }

        public List<BDMAppointmentDetailDTO> GetAppointmentDetailById(GetBDMAppointmentDetailDTO objAppointmentDetail)
        {
            List<BDMAppointmentDetailDTO> appoinment = new List<BDMAppointmentDetailDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentDetail");
                SqlCmd.CommandType = CommandType.StoredProcedure;
               // SqlCmd.Parameters.AddWithValue("@EmployeeId", objAppointmentDetail.Id);
                SqlCmd.Parameters.AddWithValue("@position", objAppointmentDetail.Position);
                SqlCmd.Parameters.AddWithValue("@EmployeeId", objAppointmentDetail.Id);
                //if (objAppointmentDetail.Position == 4)
                //{

                //    SqlCmd.Parameters.AddWithValue("@State", objAppointmentDetail.State);
                //    SqlCmd.Parameters.AddWithValue("@City", objAppointmentDetail.City);
                //}
                //if (objAppointmentDetail.Position != 4)
                //{
                //    SqlCmd.Parameters.AddWithValue("@EmployeeId", objAppointmentDetail.Id);
                //}
                SqlCmd.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ActionBy);
                if (objAppointmentDetail.FromDate.Year != 1 && objAppointmentDetail.ToDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objAppointmentDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", objAppointmentDetail.ToDate);
                }  
                else
                {
                    var fr = DateTime.Now.AddDays(-30);
                    var en = DateTime.Now;
                    SqlCmd.Parameters.AddWithValue("@FromDate", fr);
                    SqlCmd.Parameters.AddWithValue("@ToDate", en);
                }
                appoinment = dbLayer.GetEntityList<BDMAppointmentDetailDTO>(SqlCmd);
            }
            return appoinment;
        }

        public List<BDMAppoinmentDetailByStatus> GetAllStatusCoordinator(GetStatus objAppointmentDetail)
        {
            List<BDMAppoinmentDetailByStatus> appoinment = new List<BDMAppoinmentDetailByStatus>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectHotandWarm");
                SqlCmd.CommandType = CommandType.StoredProcedure;              
                SqlCmd.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ActionBy);
                if (objAppointmentDetail.FromDate.Year != 1 && objAppointmentDetail.ToDate.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@FromDate", objAppointmentDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", objAppointmentDetail.ToDate);
                }
                else
                {
                    var fr = DateTime.Now.AddDays(-30);
                    var en = DateTime.Now;
                    SqlCmd.Parameters.AddWithValue("@FromDate", fr);
                    SqlCmd.Parameters.AddWithValue("@ToDate", en);
                }
                appoinment = dbLayer.GetEntityList<BDMAppoinmentDetailByStatus>(SqlCmd);
            }
            return appoinment;
        }

        public BDMSurveyDetailDTO GetAppointmentDetailByClientId(BDMAppointmentGetIdDTO objSurveyAppointmentDetail)
        {
            BDMSurveyDetailDTO surveyDetail = new BDMSurveyDetailDTO();
            List<BDMSurveyCompetitorsDTO> surveyCompetitorsDetail = new List<BDMSurveyCompetitorsDTO>();
            List<BDMSurveyRequirementDTO> surveyRequirementDetail = new List<BDMSurveyRequirementDTO>();
            List<BDMAppointmentReportDTO> surveyReportDetail = new List<BDMAppointmentReportDTO>();

            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectAppointmentDetailById");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objSurveyAppointmentDetail.ClientId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objSurveyAppointmentDetail.ActionBy);
                surveyDetail = dbLayer.GetEntityList<BDMSurveyDetailDTO>(SqlCmd).FirstOrDefault();
            }
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd1 = new SqlCommand("spSelectCompetitorsById");
                SqlCmd1.CommandType = CommandType.StoredProcedure;
                SqlCmd1.Parameters.AddWithValue("@ClientId", objSurveyAppointmentDetail.ClientId);
                SqlCmd1.Parameters.AddWithValue("@ActionBy", objSurveyAppointmentDetail.ActionBy);
                surveyCompetitorsDetail = dbLayer.GetEntityList<BDMSurveyCompetitorsDTO>(SqlCmd1);
                surveyDetail.surveyCompetitorsDetail = surveyCompetitorsDetail;
            }

            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd2 = new SqlCommand("spSelectRequirementDetailsById");
                SqlCmd2.CommandType = CommandType.StoredProcedure;
                SqlCmd2.Parameters.AddWithValue("@ClientId", objSurveyAppointmentDetail.ClientId);
                SqlCmd2.Parameters.AddWithValue("@ActionBy", objSurveyAppointmentDetail.ActionBy);
                surveyRequirementDetail = dbLayer.GetEntityList<BDMSurveyRequirementDTO>(SqlCmd2);
                surveyDetail.BDMSurveyRequirement = surveyRequirementDetail;
            }

            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd3 = new SqlCommand("spSelectAppointmentReportById");
                SqlCmd3.CommandType = CommandType.StoredProcedure;
                SqlCmd3.Parameters.AddWithValue("@ClientId", objSurveyAppointmentDetail.ClientId);
                SqlCmd3.Parameters.AddWithValue("@ActionBy", objSurveyAppointmentDetail.ActionBy);
                surveyReportDetail = dbLayer.GetEntityList<BDMAppointmentReportDTO>(SqlCmd3);
                surveyDetail.BDMSurveyReport = surveyReportDetail;
            }
            return surveyDetail;
        }

        public bool InsertBDMAppointmentDetail(BDMAppointmentDetailInsertDTO objAppointmentDetail)
        {
            bool res = false;
            BDMAppointmentGetIdDTO bdm = new BDMAppointmentGetIdDTO();
            SqlCommand SqlCmd = new SqlCommand("spInsertBDMAppoinmentDetail");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@EmployeeId", objAppointmentDetail.EmployeeId);
            SqlCmd.Parameters.AddWithValue("@ClientName", objAppointmentDetail.ClientName);
            SqlCmd.Parameters.AddWithValue("@ClientAddress", objAppointmentDetail.ClientAddress);
            SqlCmd.Parameters.AddWithValue("@ClientContactNo", objAppointmentDetail.ClientContactNo);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objAppointmentDetail.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@Designation", objAppointmentDetail.Designation);
            SqlCmd.Parameters.AddWithValue("@Mobile", objAppointmentDetail.Mobile);
            SqlCmd.Parameters.AddWithValue("@Email", objAppointmentDetail.Email);
            SqlCmd.Parameters.AddWithValue("@ReferBy", (objAppointmentDetail.ReferBy == null) ? "" : objAppointmentDetail.ReferBy);
            SqlCmd.Parameters.AddWithValue("@State", objAppointmentDetail.State);
            SqlCmd.Parameters.AddWithValue("@City", objAppointmentDetail.City);          
            SqlCmd.Parameters.AddWithValue("@ExistCompetitors", objAppointmentDetail.ExistCompetitors);          
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objAppointmentDetail.CreatedBy);
            bdm = _unitOfWork.DbLayer.GetEntityList<BDMAppointmentGetIdDTO>(SqlCmd).FirstOrDefault();
            if (bdm != null)
            {

                SqlCommand sqlCmd1 = new SqlCommand("spInsertRequirementDetails");
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@ClientId", bdm.ClientId);
                sqlCmd1.Parameters.AddWithValue("@CreatedBy", objAppointmentDetail.CreatedBy);
                sqlCmd1.Parameters.Add(new SqlParameter("@Designation", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@Service", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@RatePerEmployee", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@EmployeeCount", SqlDbType.Int));
                foreach (var requirement in objAppointmentDetail.RequirementDetail)
                {
                    if (sqlCmd1.Connection != null)
                    {
                        if (sqlCmd1.Connection.State == ConnectionState.Closed)
                            sqlCmd1.Connection.Open();
                    }

                    sqlCmd1.Parameters["@Designation"].Value = requirement.Designation;
                    sqlCmd1.Parameters["@Service"].Value = requirement.Service;
                    sqlCmd1.Parameters["@RatePerEmployee"].Value = requirement.RatePerEmployee;
                    sqlCmd1.Parameters["@EmployeeCount"].Value = requirement.EmployeeCount;
                    int queryRes = _unitOfWork.DbLayer.ExecuteNonQuery(sqlCmd1);
                    if (queryRes != Int32.MaxValue)
                    {
                        res = true;
                    }
                    else
                    {
                        // this part needed error handling code.
                        res = false;
                    }
                }
                if (objAppointmentDetail.ExistCompetitors)
                {
                    SqlCommand sqlCmd2 = new SqlCommand("spInsertCompetitors");
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.Parameters.AddWithValue("@ClientId", bdm.ClientId);
                    sqlCmd2.Parameters.AddWithValue("@CreatedBy", objAppointmentDetail.CreatedBy);
                    sqlCmd2.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@Designation", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@Service", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@RatePerEmployee", SqlDbType.Int));
                    sqlCmd2.Parameters.Add(new SqlParameter("@EmployeeCount", SqlDbType.Int));
                    foreach (var competitor in objAppointmentDetail.Competitor)
                    {
                        if (sqlCmd2.Connection != null)
                        {
                            if (sqlCmd2.Connection.State == ConnectionState.Closed)
                                sqlCmd2.Connection.Open();
                        }
                        sqlCmd2.Parameters["@Name"].Value = competitor.Name;
                        sqlCmd2.Parameters["@Designation"].Value = competitor.Designation;
                        sqlCmd2.Parameters["@Service"].Value = competitor.Service;
                        sqlCmd2.Parameters["@RatePerEmployee"].Value = competitor.RatePerEmployee;
                        sqlCmd2.Parameters["@EmployeeCount"].Value = competitor.EmployeeCount;
                        int queryRes = _unitOfWork.DbLayer.ExecuteNonQuery(sqlCmd2);
                        if (queryRes != Int32.MaxValue)
                        {
                            res = true;
                        }
                        else
                        {
                            // this part needed error handling code.
                            res = false;
                        }
                    }
                }
                res = true;
            }
            return res;
        }

        public bool UpdateBDMAppointmentDetail(BDMAppointmentDetailUpdateDTO objAppointmentDetail)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateBDMAppoinmentDetail");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objAppointmentDetail.Id);  
            SqlCmd.Parameters.AddWithValue("@ClientName", objAppointmentDetail.ClientName);
            SqlCmd.Parameters.AddWithValue("@ClientAddress", objAppointmentDetail.ClientAddress);
            SqlCmd.Parameters.AddWithValue("@ClientContactNo", objAppointmentDetail.ClientContactNo);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objAppointmentDetail.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@Designation", objAppointmentDetail.Designation);
            SqlCmd.Parameters.AddWithValue("@Mobile", objAppointmentDetail.Mobile);
            SqlCmd.Parameters.AddWithValue("@Email", objAppointmentDetail.Email);         
            SqlCmd.Parameters.AddWithValue("@State", objAppointmentDetail.State);
            SqlCmd.Parameters.AddWithValue("@City", objAppointmentDetail.City);
            SqlCmd.Parameters.AddWithValue("@ReferBy", (objAppointmentDetail.ReferBy == null) ? "" : objAppointmentDetail.ReferBy);
            SqlCmd.Parameters.AddWithValue("@ExistCompetitors", objAppointmentDetail.ExistCompetitors);          
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objAppointmentDetail.ModifiedBy);
            int bdm = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);

            SqlCommand SqlCmdDelReq = new SqlCommand("spDeleteRequirementDetails");
            SqlCmdDelReq.CommandType = CommandType.StoredProcedure;
            SqlCmdDelReq.Parameters.AddWithValue("@ClientId", objAppointmentDetail.Id);
            SqlCmdDelReq.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ModifiedBy);
            int resultReq = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmdDelReq);

            if (bdm != Int32.MaxValue && resultReq != Int32.MaxValue)
            {

                SqlCommand sqlCmd1 = new SqlCommand("spInsertRequirementDetails");
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@ClientId", objAppointmentDetail.Id);
                sqlCmd1.Parameters.AddWithValue("@CreatedBy", objAppointmentDetail.ModifiedBy);
                sqlCmd1.Parameters.Add(new SqlParameter("@Designation", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@Service", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@RatePerEmployee", SqlDbType.Int));
                sqlCmd1.Parameters.Add(new SqlParameter("@EmployeeCount", SqlDbType.Int));
                foreach (var requirement in objAppointmentDetail.RequirementDetail)
                {
                    if (sqlCmd1.Connection != null)
                    {
                        if (sqlCmd1.Connection.State == ConnectionState.Closed)
                            sqlCmd1.Connection.Open();
                    }

                    sqlCmd1.Parameters["@Designation"].Value = requirement.Designation;                  
                    sqlCmd1.Parameters["@Service"].Value = requirement.Service;
                    sqlCmd1.Parameters["@RatePerEmployee"].Value = requirement.RatePerEmployee;
                    sqlCmd1.Parameters["@EmployeeCount"].Value = requirement.EmployeeCount;
                    int queryRes = _unitOfWork.DbLayer.ExecuteNonQuery(sqlCmd1);
                    if (queryRes != Int32.MaxValue)
                    {
                        res = true;
                    }
                    else
                    {
                        // this part needed error handling code.
                        res = false;
                    }
                }


                SqlCommand SqlCmdDelCom = new SqlCommand("spDeleteCompetitors");
                SqlCmdDelCom.CommandType = CommandType.StoredProcedure;
                SqlCmdDelCom.Parameters.AddWithValue("@ClientId", objAppointmentDetail.Id);
                SqlCmdDelCom.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ModifiedBy);
                int resultCom = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmdDelCom);

                if (objAppointmentDetail.ExistCompetitors && resultCom != Int32.MaxValue)
                {
                    SqlCommand sqlCmd2 = new SqlCommand("spInsertCompetitors");
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.Parameters.AddWithValue("@ClientId", objAppointmentDetail.Id);
                    sqlCmd2.Parameters.AddWithValue("@CreatedBy", objAppointmentDetail.ModifiedBy);
                    sqlCmd2.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@Designation", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@Service", SqlDbType.VarChar));
                    sqlCmd2.Parameters.Add(new SqlParameter("@RatePerEmployee", SqlDbType.Int));
                    sqlCmd2.Parameters.Add(new SqlParameter("@EmployeeCount", SqlDbType.Int));
                    foreach (var competitor in objAppointmentDetail.Competitor)
                    {
                        if (sqlCmd2.Connection != null)
                        {
                            if (sqlCmd2.Connection.State == ConnectionState.Closed)
                                sqlCmd2.Connection.Open();
                        }
                        sqlCmd2.Parameters["@Name"].Value = competitor.Name;
                        sqlCmd2.Parameters["@Designation"].Value = competitor.Designation;
                        sqlCmd2.Parameters["@Service"].Value = competitor.Service;
                        sqlCmd2.Parameters["@RatePerEmployee"].Value = competitor.RatePerEmployee;
                        sqlCmd2.Parameters["@EmployeeCount"].Value = competitor.EmployeeCount;
                        int queryRes = _unitOfWork.DbLayer.ExecuteNonQuery(sqlCmd2);
                        if (queryRes != Int32.MaxValue)
                        {
                            res = true;
                        }
                        else
                        {
                            // this part needed error handling code.
                            res = false;
                        }
                    }
                }
                res = true;
            }
            return res;
        }

        public bool RemoveBDMAppointmentDetail(BDMAppoinmentDetailRemoveDTO objAppointmentDetail)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("");
            sqlcmd.Parameters.AddWithValue("@Id", objAppointmentDetail.Id);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<BDMAppoinmentExportExcel> GetAppoinmentDetailtoExport(BDMAppoinmentDetailExport ExportDetail)
        {
            List<BDMAppoinmentExportExcel> appoinments = new List<BDMAppoinmentExportExcel>();
            using (DbLayer dbLayer = new DbLayer())
            {
                if (ExportDetail.Position != 1)
                {
                    SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentDetailExport");
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionBy", ExportDetail.ActionBy);
                    if (ExportDetail.EmployeeId != 0)
                    {
                        SqlCmd.Parameters.AddWithValue("@EmployeeId", ExportDetail.EmployeeId);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    if (ExportDetail.FirstName != null && ExportDetail.FirstName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@FirstName", ExportDetail.FirstName);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    if (ExportDetail.ClientName != null && ExportDetail.ClientName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@ClientName", ExportDetail.ClientName);
                    }
                    //{
                    //    SqlCmd.Parameters.AddWithValue("@FromDate", FilterDetail.FromDate);
                    //    if (FilterDetail.ToDate.Year != 1)
                    //    {
                    //        SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);
                    //    }
                    //}                   
                    SqlCmd.Parameters.AddWithValue("@FromDate", ExportDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", ExportDetail.ToDate);
                    appoinments = dbLayer.GetEntityList<BDMAppoinmentExportExcel>(SqlCmd);
                }
                else
                {
                    SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentDetailExport");
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionBy", ExportDetail.ActionBy); 
                    if (ExportDetail.EmployeeId != 0)
                    {
                        SqlCmd.Parameters.AddWithValue("@EmployeeId", ExportDetail.EmployeeId);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    else if (ExportDetail.FirstName != null)
                    {
                        SqlCmd.Parameters.AddWithValue("@FirstName", ExportDetail.FirstName);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    else if (ExportDetail.ClientName != null)
                    {
                        SqlCmd.Parameters.AddWithValue("@ClientName", ExportDetail.ClientName);
                        //if (FilterDetail.ToDate.Year != 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);
                        //}
                    }
                    //else
                    //{
                    //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                    //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    //}
                    SqlCmd.Parameters.AddWithValue("@FromDate", ExportDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", ExportDetail.ToDate);
                    appoinments = dbLayer.GetEntityList<BDMAppoinmentExportExcel>(SqlCmd);
                }

                return appoinments;
            }

        }

        public List<BDMReportExportExcel> GetAppoinmentReporttoExport(BDMReportExport ExportDetail)
        {
            List<BDMReportExportExcel> appoinments = new List<BDMReportExportExcel>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentReportExport");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ClientId", ExportDetail.ClientId);
                if (ExportDetail.Date.Year != 1)
                {
                    SqlCmd.Parameters.AddWithValue("@Date", ExportDetail.Date);
                }
                appoinments = dbLayer.GetEntityList<BDMReportExportExcel>(SqlCmd);
            }
            return appoinments;
        }

        public List<BDMAppointmentServerFilter> GetAppoinmentDetailfromServerFilter(BDMAppointmentFilter FilterDetail)
        {
            List<BDMAppointmentServerFilter> appoinments = new List<BDMAppointmentServerFilter>();
            using (DbLayer dbLayer = new DbLayer())
            {
                if (FilterDetail.Position != 1)
                {
                    SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentDetailExport");
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionBy", FilterDetail.ActionBy);
                    if (FilterDetail.EmployeeId != 0)
                    {
                        SqlCmd.Parameters.AddWithValue("@EmployeeId", FilterDetail.EmployeeId);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    if (FilterDetail.FirstName != null && FilterDetail.FirstName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@FirstName", FilterDetail.FirstName);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    if (FilterDetail.ClientName != null && FilterDetail.ClientName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@ClientName", FilterDetail.ClientName);
                    }
                    //{
                    //    SqlCmd.Parameters.AddWithValue("@FromDate", FilterDetail.FromDate);
                    //    if (FilterDetail.ToDate.Year != 1)
                    //    {
                    //        SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);
                    //    }
                    //}                   
                    SqlCmd.Parameters.AddWithValue("@FromDate", FilterDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);                 
                    appoinments = dbLayer.GetEntityList<BDMAppointmentServerFilter>(SqlCmd);
                }
                else
                {
                    SqlCommand SqlCmd = new SqlCommand("spSelectBDMAppoinmentDetailExport");   
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@ActionBy", FilterDetail.ActionBy);
                    if (FilterDetail.EmployeeId != 0)
                    {
                        SqlCmd.Parameters.AddWithValue("@EmployeeId", FilterDetail.EmployeeId);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                    if (FilterDetail.FirstName != null && FilterDetail.FirstName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@FirstName", FilterDetail.FirstName);
                        //if (FilterDetail.FromDate.Year == 1 && FilterDetail.ToDate.Year == 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                        //}
                    }
                   if (FilterDetail.ClientName != null && FilterDetail.ClientName != "")
                    {
                        SqlCmd.Parameters.AddWithValue("@ClientName", FilterDetail.ClientName);
                        //if (FilterDetail.ToDate.Year != 1)
                        //{
                        //    SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);
                        //}
                    }
                    //else
                    //{
                    //    SqlCmd.Parameters.AddWithValue("@FromDate", DateTime.Now.AddDays(-30));
                    //    SqlCmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    //}
                    SqlCmd.Parameters.AddWithValue("@FromDate", FilterDetail.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", FilterDetail.ToDate);
                    appoinments = dbLayer.GetEntityList<BDMAppointmentServerFilter>(SqlCmd);
                }
            }          
            return appoinments;
        }

        public List<BDMGetDistinctEmployeeId> GetDistinctEmployeeId(BDMGetDistinctEmployeeId objId)
        {
            List<BDMGetDistinctEmployeeId> EmployeeList = new List<BDMGetDistinctEmployeeId>();
            using (DbLayer dbLayer = new DbLayer())
            {
                if (objId.Position != 1)
                {
                    SqlCommand SqlCmd = new SqlCommand("spSelectDistinctEmployeeID");
                    SqlCmd.Parameters.AddWithValue("@ActionBy", objId.ActionBy);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    EmployeeList = dbLayer.GetEntityList<BDMGetDistinctEmployeeId>(SqlCmd);
                }
                else
                {
                    SqlCommand SqlCmd = new SqlCommand("spCEOSelectDistinctEmployeeID");                  
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    EmployeeList = dbLayer.GetEntityList<BDMGetDistinctEmployeeId>(SqlCmd);
                }
            }
            return EmployeeList;
        }

        public List<BDMDistinctEmployeeName> GetDistinctEmployeeName(BDMDistinctEmployeeName objbdmName)
        {
            List<BDMDistinctEmployeeName> EmployeeList = new List<BDMDistinctEmployeeName>();
            using (DbLayer dbLayer = new DbLayer())
            {
                if(objbdmName.Position != 1)
                {               
                SqlCommand SqlCmd = new SqlCommand("spSelectDistinctEmployeeName");
                SqlCmd.Parameters.AddWithValue("@ActionBy", objbdmName.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                EmployeeList = dbLayer.GetEntityList<BDMDistinctEmployeeName>(SqlCmd);
                }
                else
                {
                    SqlCommand SqlCmd = new SqlCommand("spCEOSelectDistinctEmployeeName");                   
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    EmployeeList = dbLayer.GetEntityList<BDMDistinctEmployeeName>(SqlCmd);
                }

            }
            return EmployeeList;
        }
    }
}
