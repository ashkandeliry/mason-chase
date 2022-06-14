using Mc2.Crud.Core.Entities;
using Mc2.Crud.Models;
using Mc2.Crud.Models.Generics;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Crud.Service.Customer
{
    public interface ICustomerService
    {
        Task<GenericOutputResult<TblCustomer>> GetCustommer(int id);
        Task<GenericOutputResult<IEnumerable<TblCustomer>>> GetAll();
        Task<GenericOutputResult<QueryResult<TblCustomer>>> GetPaged(QueryObjectParams queryResult);
        Task<GenericOutputResult<TblCustomer>> Add(TblCustomer Resource);
        Task<GenericOutputResult<bool>> Delete(int id);
    }
}
