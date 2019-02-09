using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ICompanyHolidayService
    {
        List<CompanyHolidayDTO> GetAllCompanyHoliday(CompanyHolidayGetDTO objLeave);
        CompanyHolidayDTO GetCompanyHolidayById(CompanyHolidayGetDTO objLeave);
        List<CompanyHolidayDTO> GetActiveCompanyHoliday(CompanyHolidayGetDTO objLeave);
        List<CompanyHolidayDTO> GetInActiveCompanyHoliday(CompanyHolidayGetDTO objLeave);
        bool InsertCompanyHoliday(CompanyHolidayInsertDTO objLeave);
        bool UpdateCompanyHoliday(CompanyHolidayUpdateDTO Leave);
        bool DeactivateCompanyHoliday(CompanyHolidayRemoveDTO objLeave);
    }
}
