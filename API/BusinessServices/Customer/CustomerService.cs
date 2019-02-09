using BusinessEntities;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class CustomerDataAccessLayer: ICustomer
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDataAccessLayer(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<CustomerDTO> GetAllCustomers(CustomerGetDTO objCustomer)
        {
            List<CustomerDTO> customer = new List<CustomerDTO>();
           
            
                SqlCommand SqlCmd = new SqlCommand("spSelectCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                customer = _unitOfWork.DbLayer.GetEntityList<CustomerDTO>(SqlCmd);
            
            return customer;
        }

        public CustomerDTO GetCustomerById(CustomerGetDTO objCustomer)
        {
            CustomerDTO customer = new CustomerDTO();
           
            
                SqlCommand SqlCmd = new SqlCommand("spSelectCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objCustomer.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                customer = _unitOfWork.DbLayer.GetEntityList<CustomerDTO>(SqlCmd).FirstOrDefault();
            
            return customer;
        }

        public List<GetAllSuccessCustomerDTO> GetAllSuccessCustomers(GetSuccessCustomerDTO objCustomer)
        {
            List<GetAllSuccessCustomerDTO> customer = new List<GetAllSuccessCustomerDTO>();
           
            
                SqlCommand SqlCmd = new SqlCommand("spSelectActiveCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                customer = _unitOfWork.DbLayer.GetEntityList<GetAllSuccessCustomerDTO>(SqlCmd);
            
            return customer;
        }


        public List<CustomerDTO> GetActiveCustomer(CustomerGetDTO objCustomer)
        {
            List<CustomerDTO> ActiveList = new List<CustomerDTO>();
           
            
                SqlCommand SqlCmd = new SqlCommand("spSelectCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                ActiveList = _unitOfWork.DbLayer.GetEntityList<CustomerDTO>(SqlCmd);
            
            return ActiveList;
        }

        public List<CustomerDTO> GetInActiveCustomer(CustomerGetDTO objCustomer)
        {
            List<CustomerDTO> InActiveList = new List<CustomerDTO>();
           
            
                SqlCommand SqlCmd = new SqlCommand("spSelectCustomer");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.ActionBy);
                InActiveList = _unitOfWork.DbLayer.GetEntityList<CustomerDTO>(SqlCmd);
            
            return InActiveList;
        }

        public bool InsertCustomer(CustomerInsertDTO objCustomer)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spInsertCustomer");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Name", objCustomer.Name);
            SqlCmd.Parameters.AddWithValue("@ClientId", objCustomer.ClientId);
            SqlCmd.Parameters.AddWithValue("@ContactNo", objCustomer.ContactNo);
            SqlCmd.Parameters.AddWithValue("@Mobile", objCustomer.Mobile);
            SqlCmd.Parameters.AddWithValue("@Email", objCustomer.Email);
            SqlCmd.Parameters.AddWithValue("@Address", objCustomer.Address);
            SqlCmd.Parameters.AddWithValue("@State", objCustomer.State);
            SqlCmd.Parameters.AddWithValue("@City", objCustomer.City);
            SqlCmd.Parameters.AddWithValue("@IGST", objCustomer.IGST);
            SqlCmd.Parameters.AddWithValue("@CGST", objCustomer.CGST);
            SqlCmd.Parameters.AddWithValue("@GSTNumber", objCustomer.GSTNo);
            SqlCmd.Parameters.AddWithValue("@PANNumber", objCustomer.PANNumber);
            SqlCmd.Parameters.AddWithValue("@SGST", objCustomer.SGST);
            SqlCmd.Parameters.AddWithValue("@CompanyId", objCustomer.CompanyId);
            SqlCmd.Parameters.AddWithValue("@CINNumber", objCustomer.CINNumber);
            SqlCmd.Parameters.AddWithValue("@ConcernPerson", objCustomer.ConcernPerson);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objCustomer.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@CreatedBy", objCustomer.CreatedBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            return res;
        }

        public bool MoveCustomer(CustomertoMove objCustomer)
        {
            bool res = false;
            CustomerDetailDTO cus = new CustomerDetailDTO();
            SqlCommand SqlCmd = new SqlCommand("MoveToCustomer");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ClientId", (objCustomer.ClientId == 0) ? null : objCustomer.ClientId);
            SqlCmd.Parameters.AddWithValue("@CustomerId", (objCustomer.CustomerId == 0) ? null : objCustomer.CustomerId);
            SqlCmd.Parameters.AddWithValue("@DateofCommencement", objCustomer.DateOfCommencement);
            SqlCmd.Parameters.AddWithValue("@AgreementSigned", objCustomer.AgreementSigned);
            SqlCmd.Parameters.AddWithValue("@TypeofContract", objCustomer.TypeofContract);
            SqlCmd.Parameters.AddWithValue("@FromDate", objCustomer.FromDate);
            SqlCmd.Parameters.AddWithValue("@ToDate", objCustomer.ToDate);
            SqlCmd.Parameters.AddWithValue("@ClientType", objCustomer.ClientType);
            SqlCmd.Parameters.AddWithValue("@ActionBy", objCustomer.CreatedBy);
            cus = _unitOfWork.DbLayer.GetEntityList<CustomerDetailDTO>(SqlCmd).FirstOrDefault();
            if (cus != null)
            {

                SqlCommand sqlCmd1 = new SqlCommand("spInsertCustomerManagementDetail");
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@CustomerId", cus.Customer);
                sqlCmd1.Parameters.AddWithValue("@CreatedBy", objCustomer.CreatedBy);
                sqlCmd1.Parameters.Add(new SqlParameter("@Department", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@ContactPersonName", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar));
                foreach (var detail in objCustomer.ClientDetail)
                {
                    if (sqlCmd1.Connection != null)
                    {
                        if (sqlCmd1.Connection.State == ConnectionState.Closed)
                            sqlCmd1.Connection.Open();
                    }

                    sqlCmd1.Parameters["@Department"].Value = (detail.Department == null) ? null : detail.Department;
                    sqlCmd1.Parameters["@ContactPersonName"].Value = (detail.ContactPersonName == null) ? null : detail.ContactPersonName;
                    sqlCmd1.Parameters["@ContactNumber"].Value = (detail.ContactNumber == null) ? null : detail.ContactNumber;
                    sqlCmd1.Parameters["@Email"].Value = (detail.Email == null) ? null : detail.Email;
                    sqlCmd1.Parameters["@Address"].Value = (detail.Address == null) ? null : detail.Address;
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
            }

            if (cus.ContractId != null || cus.ContractId != 0)
            {

                SqlCommand sqlCmd1 = new SqlCommand("spInsertShiftMapping");
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@ContractId", cus.ContractId);
                sqlCmd1.Parameters.AddWithValue("@CreatedBy", objCustomer.CreatedBy);
                sqlCmd1.Parameters.Add(new SqlParameter("@ShiftId", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.VarChar));
                sqlCmd1.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.VarChar));               
                foreach (var shift in objCustomer.ShiftMapping)
                {
                    if (sqlCmd1.Connection != null)
                    {
                        if (sqlCmd1.Connection.State == ConnectionState.Closed)
                            sqlCmd1.Connection.Open();
                    }

                    sqlCmd1.Parameters["@ShiftId"].Value = shift.ShiftId;
                    sqlCmd1.Parameters["@StartTime"].Value = shift.StartTime;
                    sqlCmd1.Parameters["@EndTime"].Value = shift.EndTime;                  
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
            }


            return res;
        }

        public bool UpdateCustomer(CustomerUpdateDTO objCustomer)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateCustomer");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", objCustomer.Id);
            SqlCmd.Parameters.AddWithValue("@Name", objCustomer.Name);
            SqlCmd.Parameters.AddWithValue("@ContactNo", objCustomer.ContactNo);
            SqlCmd.Parameters.AddWithValue("@Email", objCustomer.Email);
            SqlCmd.Parameters.AddWithValue("@Address", objCustomer.Address);
            SqlCmd.Parameters.AddWithValue("@ConcernPerson", objCustomer.ConcernPerson);
            SqlCmd.Parameters.AddWithValue("@ContactPerson", objCustomer.ContactPerson);
            SqlCmd.Parameters.AddWithValue("@State", objCustomer.State);
            SqlCmd.Parameters.AddWithValue("@City", objCustomer.City);
            SqlCmd.Parameters.AddWithValue("@CompanyId", objCustomer.CompanyId);
            SqlCmd.Parameters.AddWithValue("@IGST", objCustomer.IGST);
            SqlCmd.Parameters.AddWithValue("@CGST", objCustomer.CGST);
            SqlCmd.Parameters.AddWithValue("@SGST", objCustomer.SGST);
            SqlCmd.Parameters.AddWithValue("@PANNumber", objCustomer.PANNumber);
            SqlCmd.Parameters.AddWithValue("@GSTNumber", objCustomer.GSTNo);
            SqlCmd.Parameters.AddWithValue("@CINNumber", objCustomer.CINNumber);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", objCustomer.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", objCustomer.Active);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveCustomerById(CustomerRemoveDTO objRemoveCusById)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteCustomer");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", objRemoveCusById.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveCusById.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveCusById.ActionBy);
            int result = _unitOfWork.DbLayer.ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
