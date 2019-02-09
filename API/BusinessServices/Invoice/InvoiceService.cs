using BusinessEntities;
using BusinessServices;
using DataModel.DBLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace BusinessServices
{
    public class InvoiceDataAccessLayer:IInvoiceService
    {
        public InvoiceDTO GetInvoiceReport(InvoiceGetDTO objInvoiceGetDTO)
        {
            DataSet ds = new DataSet();
            InvoiceDTO invoice = new InvoiceDTO();
            try
            {
                using (DbLayer dbLayer = new DbLayer())
                {
                    SqlCommand SqlCmd = new SqlCommand("spInvoiceReportByCustomer");
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@CustomerId", objInvoiceGetDTO.CustomerId);
                    SqlCmd.Parameters.AddWithValue("@FromDate", objInvoiceGetDTO.FromDate);
                    SqlCmd.Parameters.AddWithValue("@ToDate", objInvoiceGetDTO.ToDate);
                    ds = dbLayer.fillDataSet(SqlCmd);
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        invoice.CustomerInvoice = DataModel.Utilities.Utility.ConvertDataTableToEntityList<CustomerInvoiceDTO>(ds.Tables[0]).FirstOrDefault();
                        invoice.InvoiceList = DataModel.Utilities.Utility.ConvertDataTableToEntityList<InvoiceListDTO>(ds.Tables[1]);
                    }
                    else
                    {
                        invoice.CustomerInvoice = null;
                        invoice.InvoiceList = null;
                    }
                }
            }
            catch(Exception ex)
            {
               ErrorLog.LogFileWrite(ex.Message);
            };
            return invoice;
        }

        public bool InsertInvoice(InvoiceSaveDTO obj)
        {
            bool res = false;
            //SqlCommand SqlCmd = new SqlCommand("spInsertInvoice");
            //SqlCmd.CommandType = CommandType.StoredProcedure;
            //SqlCmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            //SqlCmd.Parameters.AddWithValue("@InvoiceDate", obj.InvoiceDate);
            //SqlCmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            //SqlCmd.Parameters.AddWithValue("@ActionBy", obj.ActionBy);           
            //int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            //if (result != Int32.MaxValue)
            //{
            //    res = true;
            //}
            return res;
        }
    }
}
