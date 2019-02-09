using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessEntities
{
    [Serializable]
    [DataContract]
    public class BDMAppointmentDetailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public String ClientName { get; set; }
        [DataMember]
        public String ClientAddress { get; set; }
        [DataMember]
        public String ClientContactNo { get; set; }
        [DataMember]
        public String ContactPerson { get; set; }
        [DataMember]
        public String Designation { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public String Mobile { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String ContractValue { get; set; }
        [DataMember]
        public int? TotalEmployee { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public int? ExistCompetitors { get; set; }
        [DataMember]
        public DateTime ExpectedConfirmationDate { get; set; }
        [DataMember]
        public string Calltype { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public byte AttachmentFlag { get; set; }
        [DataMember]
        public String ActionBy { get; set; }
      
    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentDetailByStatus
    {
         [DataMember]
        public int Id { get; set; }
        [DataMember]      
        public string EmployeeNo { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientAddress { get; set; }
        [DataMember]
        public string ClientContactNo { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }       
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string ContractValue { get; set; }
        [DataMember]
        public string TotalEmployee { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string CallType { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentDetailGetDetailDTO
    {
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppointmentDetailInsertDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientAddress { get; set; }
        [DataMember]
        public string ClientContactNo { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string ReferBy { get; set; }
        [DataMember]
        public bool ExistCompetitors { get; set; }
        [DataMember]
        public DateTime ExpectedConfirmationDate { get; set; }
        [DataMember]
        public string CallType { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public List<RequirementDetailsInsertDTO> RequirementDetail { get; set; }
        [DataMember]
        public List<CompetitorsInsertDTO> Competitor { get; set; }

    }

    [Serializable]
    [DataContract]
    public class BDMAppointmentGetIdDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppointmentDetailUpdateDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientAddress { get; set; }
        [DataMember]
        public string ClientContactNo { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }     
        [DataMember]
        public bool ExistCompetitors { get; set; }
        [DataMember]
        public DateTime ExpectedConfirmationDate { get; set; }
        [DataMember]
        public string ReferBy { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public List<RequirementDetailsInsertDTO> RequirementDetail { get; set; }
        [DataMember]
        public List<CompetitorsInsertDTO> Competitor { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentDetailRemoveDTO
    {
        [DataMember]
        public int Id { get; set; }
    }


    [Serializable]
    [DataContract]
    public class GetBDMAppointmentDetailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int City { get; set; }
        [DataMember]
        public int ActionBy { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class GetStatus
    {
        [DataMember]
        public string ActionBy { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentDetailExport
    {
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppoinmentExportExcel
    {
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public String ClientName { get; set; }
        [DataMember]
        public String ClientAddress { get; set; }
        [DataMember]
        public String ContactPerson { get; set; }
        [DataMember]
        public String Designation { get; set; }
        [DataMember]
        public String Mobile { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public String ContractValue { get; set; }
        [DataMember]
        public String TotalEmployee { get; set; }  
        [DataMember]
        public String Calltype { get; set; }       
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public String Remarks { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMReportExport
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMReportExportExcel
    {
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Calltype { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Mobile { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMAppointmentFilter
    {
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public string ActionBy { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BDMAppointmentServerFilter
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public String ClientName { get; set; }
        [DataMember]
        public String ClientAddress { get; set; }
        [DataMember]
        public String ContactPerson { get; set; }
        [DataMember]
        public String Designation { get; set; }
        [DataMember]
        public String Mobile { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String StatusName { get; set; }
        [DataMember]
        public String CityName { get; set; }
        [DataMember]
        public String StateName { get; set; }
        [DataMember]
        public String ContractValue { get; set; }
        [DataMember]
        public String TotalEmployee { get; set; }
        [DataMember]
        public int? ExistCompetitors { get; set; }       
        [DataMember]
        public String CallType { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMGetDistinctEmployeeId
    {
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }
        [DataMember]
        public string ActionBy { get; set; }

    }

    [Serializable]
    [DataContract]
    public class BDMDistinctEmployeeName
    {
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string ActionBy { get; set; }

    }


    [Serializable]
    [DataContract]
    public class BDMSurveyDetailDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string EmployeeNo { get; set; }      
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string ClientAddress { get; set; }
        [DataMember]
        public string ClientContactNo { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public bool ExistCompetitors { get; set; }
        [DataMember]
        public DateTime ExpectedConfirmationDate { get; set; }
        [DataMember]
        public string CallType { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public List<BDMSurveyCompetitorsDTO> surveyCompetitorsDetail { get; set; }
        [DataMember]
        public List<BDMSurveyRequirementDTO> BDMSurveyRequirement { get; set; }
        [DataMember]
        public List<BDMAppointmentReportDTO> BDMSurveyReport { get; set; }
    }

    [Serializable]
    [DataContract]
    public class BDMSurveyCompetitorsDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public string Service { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
    }


    [Serializable]
    [DataContract]
    public class BDMSurveyRequirementDTO
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int Designation { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public int RatePerEmployee { get; set; }
        [DataMember]
        public int EmployeeCount { get; set; }
        [DataMember]
        public int Service { get; set; }
        [DataMember]
        public string ServiceName { get; set; }
    }
}
