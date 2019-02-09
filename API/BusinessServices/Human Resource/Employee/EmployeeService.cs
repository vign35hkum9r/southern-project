using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessEntities;
using DataModel.DBLayer;

namespace BusinessServices
{
    public class EmployeeDataAccessLayer:IEmployeeService
    {

        public List<EmployeeDTO> GetAllEmployees(EmployeeGetDTO ObjGetEmp)
        {
            List<EmployeeDTO> employee = new List<EmployeeDTO>();

            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployee");
                SqlCmd.Parameters.AddWithValue("@ActionBy", ObjGetEmp.ActionBy);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                employee = dbLayer.GetEntityList<EmployeeDTO>(SqlCmd);

                foreach (var emp in employee)
                {
                    foreach (var emp2 in employee)
                    {
                        if (emp.ReportTo == emp2.Id)
                        {
                            emp.ReportToName = emp2.FirstName + " " + emp2.SecondName;
                        }
                    }
                }
            }
            return employee;
        }

        public EmployeeDTO GetEmployeeById(EmployeeGetDTO ObjGetEmpById)
        {
            EmployeeDTO employee = new EmployeeDTO();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployee");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", ObjGetEmpById.Id);
                SqlCmd.Parameters.AddWithValue("@ActionBy", ObjGetEmpById.ActionBy);
                employee = dbLayer.GetEntityList<EmployeeDTO>(SqlCmd).FirstOrDefault();
            }
            return employee;
        }

        public List<EmployeeDTO> GetActiveEmployee(EmployeeGetDTO objActive)
        {
            List<EmployeeDTO> activeList = new List<EmployeeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployee");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objActive.Id);
                SqlCmd.Parameters.AddWithValue("@Active", 1);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objActive.ActionBy);
                activeList = dbLayer.GetEntityList<EmployeeDTO>(SqlCmd);
            }
            return activeList;
        }

        public List<GetEmployeeBankDetail> GetActiveEmployeeBankDetails(int id)
        {
            List<GetEmployeeBankDetail> activeList = new List<GetEmployeeBankDetail>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployeeBank");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@EmployeeId", id);                           
                activeList = dbLayer.GetEntityList<GetEmployeeBankDetail>(SqlCmd);
            }
            return activeList;
        }

        public List<EmployeeDTO> GetInActiveEmployee(EmployeeGetDTO objInActive)
        {
            List<EmployeeDTO> inActiveList = new List<EmployeeDTO>();
            using (DbLayer dbLayer = new DbLayer())
            {
                SqlCommand SqlCmd = new SqlCommand("spSelectEmployee");
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@Id", objInActive.Id);
                SqlCmd.Parameters.AddWithValue("@Active", 0);
                SqlCmd.Parameters.AddWithValue("@ActionBy", objInActive.ActionBy);
                inActiveList = dbLayer.GetEntityList<EmployeeDTO>(SqlCmd);
            }
            return inActiveList;
        }

        public bool InsertEmployee(EmployeeInsertDTO employee)
        {
            bool res = false;
           EmployeeGetDTO emp = new EmployeeGetDTO();
            SqlCommand SqlCmd = new SqlCommand("spInsertEmployee");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@ReferenceId", ((employee.ReferenceId == null) ? "" : employee.ReferenceId));
            SqlCmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            SqlCmd.Parameters.AddWithValue("@SecondName", ((employee.SecondName == null) ? "" : employee.SecondName));
            SqlCmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
            SqlCmd.Parameters.AddWithValue("@Gender", employee.Gender);
            SqlCmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            SqlCmd.Parameters.AddWithValue("@ContactNo", employee.ContactNo);
            SqlCmd.Parameters.AddWithValue("@Email", ((employee.Email == null) ? "" : employee.Email));
            SqlCmd.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
            SqlCmd.Parameters.AddWithValue("@PermanentAddress", employee.PermanentAddress);
            SqlCmd.Parameters.AddWithValue("@NativePlace", employee.NativePlace);
            SqlCmd.Parameters.AddWithValue("@BloodGroup", employee.BloodGroup);
            SqlCmd.Parameters.AddWithValue("@MedicalExam", employee.MedicalExam);
            SqlCmd.Parameters.AddWithValue("@DesignationId", employee.DesignationId);
            SqlCmd.Parameters.AddWithValue("@ReportTo", employee.ReportTo);
            SqlCmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            SqlCmd.Parameters.AddWithValue("@State", employee.State);
            SqlCmd.Parameters.AddWithValue("@City", employee.City); 
            SqlCmd.Parameters.AddWithValue("@AdhaarNo", employee.AdhaarNo);
            SqlCmd.Parameters.AddWithValue("@AlternateContactNo", employee.AlternateContactNo);
            SqlCmd.Parameters.AddWithValue("@Photo", employee.Photo);
            SqlCmd.Parameters.AddWithValue("@PreviousCompany", employee.PreviousCompany);
            SqlCmd.Parameters.AddWithValue("@JobType", employee.JobType);
            SqlCmd.Parameters.AddWithValue("@DOJ", employee.DOJ);
            SqlCmd.Parameters.AddWithValue("@ReferenceBy", employee.ReferenceBy);
            SqlCmd.Parameters.AddWithValue("@ReferenceContact1", employee.ReferenceContact1);
            SqlCmd.Parameters.AddWithValue("@ReferenceContact2", employee.ReferenceContact2);
            SqlCmd.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStatus);
            SqlCmd.Parameters.AddWithValue("@MotherName", employee.MotherName);

            emp = new DbLayer().GetEntityList<EmployeeGetDTO>(SqlCmd).FirstOrDefault();
            if(emp.EmpId > 0)
            {
                res = true;
            }
            if (emp.EmpId > 0 && employee.BankDetail.Count > 0)
            {
               
                foreach (var c in employee.BankDetail)
                {
                    SqlCommand sqlCmd2 = new SqlCommand("spInsertEmployeeBank");
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    if (sqlCmd2.Connection != null)
                    {
                        if (sqlCmd2.Connection.State == ConnectionState.Closed)
                            sqlCmd2.Connection.Open();
                    }
                    sqlCmd2.Parameters.AddWithValue("@EmployeeId", emp.EmpId);               
                    sqlCmd2.Parameters.AddWithValue("@AccountNumber", c.AccountNo);
                    sqlCmd2.Parameters.AddWithValue("@BankName", c.BankName);
                    sqlCmd2.Parameters.AddWithValue("@BranchName", c.Branch);
                    sqlCmd2.Parameters.AddWithValue("@IFSCCode", c.IFSC);
                    sqlCmd2.Parameters.AddWithValue("@MICRCode", c.MICR);
                    sqlCmd2.Parameters.AddWithValue("@IsPrimaryAccount", c.isPrimary);
                    sqlCmd2.Parameters.AddWithValue("@CreatedBy", c.CreatedBy);
                    int queryRes = new DbLayer().ExecuteNonQuery(sqlCmd2);
                    if (queryRes != Int32.MaxValue)
                    {
                        res = true;
                        sqlCmd2.Connection.Close();
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

        public bool InsertEmployeeBankDtl(EmployeeBankDetailInsertDTO employee)
        {
            bool res = false;
            SqlCommand sqlCmd = new SqlCommand("spInsertEmployeeBank"); 
            sqlCmd.CommandType = CommandType.StoredProcedure;          
            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.Id);
            sqlCmd.Parameters.AddWithValue("@AccountNumber", employee.AccountNo);
            sqlCmd.Parameters.AddWithValue("@BankName", employee.BankName);
            sqlCmd.Parameters.AddWithValue("@BranchName", employee.Branch);
            sqlCmd.Parameters.AddWithValue("@IFSCCode", employee.IFSC);
            sqlCmd.Parameters.AddWithValue("@MICRCode", employee.MICR);
            sqlCmd.Parameters.AddWithValue("@IsPrimaryAccount", employee.isPrimary);
            sqlCmd.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);
            int queryRes = new DbLayer().ExecuteNonQuery(sqlCmd);
            if (queryRes != Int32.MaxValue)
            {
                res = true;
            }
            else
            {
                // this part needed error handling code.
                res = false;
            }

            return res;
        }

        public bool UpdateEmployeeBankDtl(EmployeeBankDetailInsertDTO employee)
        {
            bool res = false;
            SqlCommand sqlCmd = new SqlCommand("spUpdateEmployeeBankDtl");
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EmployeeBankId", employee.EmployeeBankId);
            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.Id);
            sqlCmd.Parameters.AddWithValue("@AccountNumber", employee.AccountNo);
            sqlCmd.Parameters.AddWithValue("@BankName", employee.BankName);
            sqlCmd.Parameters.AddWithValue("@BranchName", employee.Branch);
            sqlCmd.Parameters.AddWithValue("@IFSCCode", employee.IFSC);
            sqlCmd.Parameters.AddWithValue("@MICRCode", employee.MICR);
            sqlCmd.Parameters.AddWithValue("@IsPrimaryAccount", employee.isPrimary);
            sqlCmd.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);
            int queryRes = new DbLayer().ExecuteNonQuery(sqlCmd);
            if (queryRes != Int32.MaxValue)
            {
                res = true;
            }
            else
            {
                // this part needed error handling code.
                res = false;
            }

            return res;
        }

        public bool UpdateEmployee(EmployeeUpdateDTO employee)
        {
            bool res = false;
            SqlCommand SqlCmd = new SqlCommand("spUpdateEmployee");
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@Id", employee.Id);
            SqlCmd.Parameters.AddWithValue("@ReferenceId", ((employee.ReferenceId == null) ? "" : employee.ReferenceId));
            //SqlCmd.Parameters.AddWithValue("@EmployeeId", ((employee.EmployeeId == null) ? "" : employee.EmployeeId));
            SqlCmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            SqlCmd.Parameters.AddWithValue("@SecondName", ((employee.SecondName == null) ? "" : employee.SecondName));
            SqlCmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
            SqlCmd.Parameters.AddWithValue("@Gender", employee.Gender);
            SqlCmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            SqlCmd.Parameters.AddWithValue("@BloodGroup", employee.BloodGroup);
            SqlCmd.Parameters.AddWithValue("@ContactNo", employee.ContactNo);
            SqlCmd.Parameters.AddWithValue("@Email", ((employee.Email == null) ? "" : employee.Email));
            SqlCmd.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
            SqlCmd.Parameters.AddWithValue("@PermanentAddress", employee.PermanentAddress);
            SqlCmd.Parameters.AddWithValue("@NativePlace", employee.NativePlace);
            SqlCmd.Parameters.AddWithValue("@MedicalExam", employee.MedicalExam);
            SqlCmd.Parameters.AddWithValue("@DesignationId", employee.DesignationId);
            SqlCmd.Parameters.AddWithValue("@ReportTo", employee.ReportTo);
            SqlCmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            SqlCmd.Parameters.AddWithValue("@State", employee.State);
            SqlCmd.Parameters.AddWithValue("@City", employee.City);
            SqlCmd.Parameters.AddWithValue("@ModifiedBy", employee.ModifiedBy);
            SqlCmd.Parameters.AddWithValue("@Active", employee.Active);
            int result = new DbLayer().ExecuteNonQuery(SqlCmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool DeactivateEmployee(int id)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", id);
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveAllEmployee()
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteEmployee");
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveEmployee(EmployeeRemoveDTO objRemoveEmp)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteEmployee");
            sqlcmd.Parameters.AddWithValue("@Id", objRemoveEmp.Id);
            sqlcmd.Parameters.AddWithValue("@Active", objRemoveEmp.Active);
            sqlcmd.Parameters.AddWithValue("@ActionBy", objRemoveEmp.ActionBy);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }

        public bool RemoveEmployeeBankDtl(int id)
        {
            bool res = false;
            SqlCommand sqlcmd = new SqlCommand("spDeleteEmployeeBank");
            sqlcmd.Parameters.AddWithValue("@EmployeeBankId", id);            
            sqlcmd.CommandType = CommandType.StoredProcedure;
            int result = new DbLayer().ExecuteNonQuery(sqlcmd);
            if (result != Int32.MaxValue)
            {
                res = true;
            }
            return res;
        }
    }
}
//spDeleteEmployee