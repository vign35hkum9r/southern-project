using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IMappingSalaryComponent
    {
        bool InsertMapping_SalaryComponents(InsertMapping_SalaryComponents obj);
        bool UpdateMapping_SalaryComponents(UpdateMapping_SalaryComponents obj);
        bool DeleteMapping_SalaryComponents(int id);
        List<GetMapping_SalaryComponents> GetAllMapping_SalaryComponentss(int? id);

    }
}
