using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    public class SalaryAllocationDTO
    {         
    }

    [Serializable]
    [DataContract]
    public class getSalaryAllocation
    {
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public int? ManpowerId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllSalaryAllocation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int SalaryComponentId { get; set; }
        [DataMember]
        public String Type { get; set; }
        [DataMember]
        public int? Value { get; set; }
        [DataMember]
        public int? FromDeduction { get; set; }
        [DataMember]
        public string DeductionName { get; set; }
        [DataMember]
        public String FromDeductionName { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public Decimal Amount { get; set; }
    }


    [Serializable]
    [DataContract]
    public class getDepartmentByEmployeeType
    {
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getAllDepartmentByEmployeeType
    {
        [DataMember]
        public int DepartmentId { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getDesignationByDepartment
    {
        [DataMember]
        public int DepartmentId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class getAllDesignationByDepartment
    {
        [DataMember]
        public int DesignationId { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class getEmployeeByDesignation
    {
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public int DesignationId { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }
    [Serializable]
    [DataContract]
    public class getAllEmployeeByDesignation
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo{ get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public string ManpowerName { get; set; }
    }

    [Serializable]
    [DataContract]
    public class InsertSalaryAllocation
    {
        [DataMember]
        public int EmployeeType { get; set; }
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public int? ManpowerId { get; set; }
        [DataMember]
        public int SalaryComponentId { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int? FromDeduction { get; set; }
        [DataMember]
        public int? Value { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetAllSalaryReport
    {
        [DataMember]
        public int ManpowerId { get; set; }
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public int? SalaryComponentId { get; set; }
        [DataMember]
        public String ComponentName { get; set; }
        [DataMember]
        public int? Value { get; set; }
        [DataMember]
        public Decimal TotalEarning { get; set; }
        [DataMember]
        public List<Debit> DebitSalary { get; set; }
        [DataMember]
        public List<Total> NetSalary { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Debit
    {
        [DataMember]
        public int? ManpowerId { get; set; }
        [DataMember]
        public String ManpowerName { get; set; }
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public String EmployeeName { get; set; }
        [DataMember]
        public int? SalaryComponentId { get; set; }
        [DataMember]
        public String ComponentName { get; set; }
        [DataMember]
        public int? Value { get; set; }
        [DataMember]
        public Decimal TotalDeductions { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Total
    {
        [DataMember]
        public int? TotalAmount { get; set; }
    }
}
