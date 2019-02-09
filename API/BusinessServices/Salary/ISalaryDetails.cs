using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface ISalary_Details
    {
        bool InsertSalary_Details(InsertSalary_Details obj);
        bool UpdateSalary_Details(UpdateSalary_Details obj);
        bool DeleteSalary_Details(int id);
        List<GetSalary_Details> GetAllSalary_Detailss(int? id);
    }
}
