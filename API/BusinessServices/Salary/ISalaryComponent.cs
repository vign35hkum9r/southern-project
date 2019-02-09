using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface ISalaryComponent
    {
        bool InsertSalaryComponent(InsertSalaryComponent obj);
        bool UpdateSalaryComponent(UpdateSalaryComponent obj);
        bool DeleteSalaryComponent(int id);
        List<GetSalaryComponent> GetAllSalaryComponents(int? id);
    }
}
