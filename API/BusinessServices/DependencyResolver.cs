
﻿
﻿using Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using DataModel.UnitOfWork;
using DataModel;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
            registerComponent.RegisterType<IDesignationService, DesignationService>();
            registerComponent.RegisterType<ICityService, CityService>();
            registerComponent.RegisterType<ICountryService, CountryServices>();
            registerComponent.RegisterType<IRoleServices, RoleServices>();
            registerComponent.RegisterType<IRoleMenuMappingServices, RoleMenuMappingServices>();
            registerComponent.RegisterType<IUserMenuMappingServices, UserMenuMappingServices>();
            registerComponent.RegisterType<ICompanyServices, CompanyServices>();
            registerComponent.RegisterType<IStateServices, StateServices>();
            registerComponent.RegisterType<IAreaServices, AreaServices>();
            registerComponent.RegisterType<IOrganizationLevelServices, OrganizationLevelServices>();
            registerComponent.RegisterType<IActionServices, ActionServices>();
            registerComponent.RegisterType<IDepartmentServices, DepartmentServices>();
            registerComponent.RegisterType<IMenuServices, MenuServices>();
         registerComponent.RegisterType<IEmployeeService, EmployeeDataAccessLayer>();           
            registerComponent.RegisterType<IEmployeeAccountService, EmployeeAccountsDataAccessLayer>();
          //  registerComponent.RegisterType<IEmployeeExperienceService, EmployeeExperienceService>();
            registerComponent.RegisterType<IStudentService, StudentService>();
            registerComponent.RegisterType<IBDMAppoinmentReport, BDMAppointmentReportService>();
            registerComponent.RegisterType<IBDMAttachment, BDMAttachmentService>();
            registerComponent.RegisterType<IBDMAppointment, BDMAppointmentDetailDAL>();
            registerComponent.RegisterType<IContractorMaster, ContractMasterDataAccessLayer>();
            registerComponent.RegisterType<IContractorDetail, ContractDetailsDataAccessLayer>();
            registerComponent.RegisterType<IManPower, ManPowerDataAccessLayer>();
            registerComponent.RegisterType<IManpowerAttendance, ManpowerAttendanceDAL>();
            registerComponent.RegisterType<IAnnexure, AnnexureDataAccessLayer>();
            registerComponent.RegisterType<IAssignFieldOfficer, AssignFieldOfficerDataAccessLayer>();
            registerComponent.RegisterType<IAssignManpower, AssignManpowerDataAccessLayer>();
            registerComponent.RegisterType<ICustomerMapping, CustomerSiteMappingDataAccessLayer>();
            registerComponent.RegisterType<ICustomer, CustomerDataAccessLayer>();
            registerComponent.RegisterType<IClientLead, ClientLeadChangeDataAccessLayer>();
            registerComponent.RegisterType<ICompetitors, CompetitorsDataAccessLayer>();
            registerComponent.RegisterType<IEmployeeAccountService, EmployeeAccountsDataAccessLayer>();
            registerComponent.RegisterType<ICompanyHolidayService, CompanyHolidayDataAccessLayer>();
            registerComponent.RegisterType<ILeaveAllocation, LeaveAllocationDataAccessLayer>();
            registerComponent.RegisterType<ILeaveFrequencyService, LeaveFrequencyMasterDataAccessLayer>();
            registerComponent.RegisterType<ILeaveMasterService, LeaveMasterDataAccessLayer>();
            registerComponent.RegisterType<IOverallAttentance, OverAllAttendanceDataAccessLayer>();
            registerComponent.RegisterType<IRequirementServices, RequirementDetailsDataAccessLayer>();
            registerComponent.RegisterType<IMappingSalaryComponent, Mapping_SalaryComponentsDAL>();
            registerComponent.RegisterType<ISalaryAllocation, salaryAllocationDataAccessLayer>();
            registerComponent.RegisterType<ISalaryComponent, SalaryComponentDAL>();
            registerComponent.RegisterType<ISiteMapping, SiteMappingDataAccessLayer>();
            registerComponent.RegisterType<IShiftMapping, ShiftMappingDataAccessLayer>();
            registerComponent.RegisterType<IShiftMaster, ShiftMasterDataAccessLayer>();
            registerComponent.RegisterType<ITargetService, TargetDataAccessLayer>();
            registerComponent.RegisterType<IStatusMaster, StatusMasterDataAccessLayer>();
            registerComponent.RegisterType<IServiceMasterService, ServiceMasterDataAccessLayer>();

        }
    }
}

