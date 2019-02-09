using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface ICustomer
    {
        List<CustomerDTO> GetAllCustomers(CustomerGetDTO objCustomer);
        CustomerDTO GetCustomerById(CustomerGetDTO objCustomer);
        List<GetAllSuccessCustomerDTO> GetAllSuccessCustomers(GetSuccessCustomerDTO objCustomer);
        List<CustomerDTO> GetActiveCustomer(CustomerGetDTO objCustomer);
        List<CustomerDTO> GetInActiveCustomer(CustomerGetDTO objCustomer);
        bool InsertCustomer(CustomerInsertDTO objCustomer);
        bool MoveCustomer(CustomertoMove objCustomer);
        bool UpdateCustomer(CustomerUpdateDTO objCustomer);
        bool RemoveCustomerById(CustomerRemoveDTO objRemoveCusById);
    }
}
