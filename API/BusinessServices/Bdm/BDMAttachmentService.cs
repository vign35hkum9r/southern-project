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
    public class BDMAttachmentService: IBDMAttachment
    {
        private readonly IUnitOfWork _unitOfWork;

        public BDMAttachmentService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public bool InsertBDMAttachment(BDMAttachmentDTO objAttachment)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertBDMAttachment");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@AppoinmentId", objAttachment.AppointmentId);
            SqlCmd.Parameters.AddWithValue("@FileUrl", objAttachment.FileUrl);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool InsertBDMAttachmentQuote(BDMAttachmentInsertQuotation objAttachment)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertQuotefile");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ClientId", objAttachment.ClientId);
            SqlCmd.Parameters.AddWithValue("@QuoteFileUrl", objAttachment.QuoteFileUrl);
            SqlCmd.Parameters.AddWithValue("@CreatedBy",objAttachment.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public List<BDMAttachementGetQuotation> GetAllQuoteById(BDMAppoinmentGetById objAppointmentDetail)
        {
            List<BDMAttachementGetQuotation> quote = new List<BDMAttachementGetQuotation>();
            using (DbLayer dbLayer = _unitOfWork.DbLayer)
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectQuotefile");
                SqlCmd.Parameters.AddWithValue("@ClientId", objAppointmentDetail.ClientId);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objAppointmentDetail.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                quote = dbLayer.GetEntityList<BDMAttachementGetQuotation>(SqlCmd);
            }
            return quote;
        }

        public List<BDMAttachmentGetDTO> GetAllAttachmentById(BDMAttachmentGetDTO objAppointmentDetail)
        {
            List<BDMAttachmentGetDTO> appoinment = new List<BDMAttachmentGetDTO>();
            using (DbLayer dbLayer = _unitOfWork.DbLayer)
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectBDMAttachment");
                SqlCmd.Parameters.AddWithValue("@AppoinmentId", objAppointmentDetail.AppoinmentId);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                appoinment = dbLayer.GetEntityList<BDMAttachmentGetDTO>(SqlCmd);
            }
            return appoinment;
        }
    }

}
