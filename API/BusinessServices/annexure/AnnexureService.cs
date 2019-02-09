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
    public class AnnexureDataAccessLayer:IAnnexure
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnexureDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public AnnexureDTO GetAnnexureReport(AnnexureGetDTO objAnnexureGetDTO)
        {
            DataSet ds = new DataSet();
            AnnexureDTO annuexure = new AnnexureDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spAnnexureReportByCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@CustomerId", objAnnexureGetDTO.CustomerId);
                SqlCmd.Parameters.AddWithValue("@Date", objAnnexureGetDTO.Date);
                ds = dbLayer.fillDataSet(SqlCmd);
                if(ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    annuexure.CustomerDetail = DataModel.Utilities.Utility.ConvertDataTableToEntityList<AnnexureCustomerDTO>(ds.Tables[0]).FirstOrDefault();
                    annuexure.AnnexureList = DataModel.Utilities.Utility.ConvertDataTableToEntityList<AnnexureListDTO>(ds.Tables[1]);
                }
                else
                {
                    annuexure.CustomerDetail = null;
                    annuexure.AnnexureList = null;
                }
            }
            return annuexure;
        }
    }
}
