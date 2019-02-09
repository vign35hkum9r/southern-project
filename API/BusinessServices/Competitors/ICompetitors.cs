using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface ICompetitors
    {
        List<CompetitorsDTO> GetAllCompetitors(CompetitorsGetDTO objCompetitors);
        List<CompetitorsDTO> GetCompetitorsById(CompetitorsGetDTO objCompetitors);
        List<CompetitorsDTO> GetActiveCompetitors(CompetitorsGetDTO objCompetitors);
        List<CompetitorsDTO> GetInActiveCompetitors(CompetitorsGetDTO objCompetitors);
        bool InsertCompetitors(CompetitorsInsertDTO objCompetitors);
        bool UpdateCompetitors(CompetitorsUpdateDTO objCompetitors);
        bool RemoveCompetitors(CompetitorsRemoveDTO objCompetitors);
    }
}
