using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IManPower
    {
        List<GetAllManpowerDTO> GetAllManPowerMaster(GetManpowerDTO objGetMaster);
        GetAgeCalculationDTO GetAgeCalculation(GetAgeDTO objGetAge);
        List<ManpowerInsertDTO> GetManPowerMasterById(GetProofDTO objGetMasterById);
        List<ProofMasterGetDTO> GetProofMaster(GetManpowerDTO objGetProof);
        GetManPowerId InsertManPower(ManpowerInsertDTO objManPower);
        bool UpdateManPower(ManpowerUpdateDTO objManPower);
        bool InsertVerifyProof(ManpowerProofInsertDTO objVerifyProof);
        bool InsertManpowerFamily(ManpowerFamilyInsertDTO objFamily);
        List<GetManpowerFamilyDTO> GetManpowerFamily(GetProofDTO objGetFamily);
        List<GetManpowerProofDTO> GetVerifyDetail(GetProofDTO objGetVerify);
        bool RemoveManpowerFamily(RemoveFamilyDTO objfamily);
        bool RemoveManpowerVerify(RemoveVerifyDTO objVerify);
        bool RemoveManpower(GetProofDTO objManpower);
        SearchManpowerDTO SearchManpower(GetVerifyDTO objSearch);
        List<GetAllPayment> GetAllManPayment();
        bool InsertManpowerBankDetails(ManpowerBankDetailsInsertDTO objBankDetails);
        List<ManpowerBankDetailsGetDTO> GetManpowerBankDetails(ManpowerBankDetailsGetDTO objBankDetails);
        List<BankNameListGetDTO> GetAllBankNameList();
        List<AccountTypeGetDTO> GetAllAccountTypeList();
        bool RemoveManpowerBank(RemoveBankDTO objBank);
    }
}
