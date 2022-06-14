using AutoMapper;
using Mc2.Crud.Core.Domain;
using Mc2.Crud.Core.Entities;
using Mc2.Crud.Models;
using Mc2.Crud.Models.Generics;
using Mc2.Crud.Service.Customer;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerService = customerService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<GenericOutputResult<CustomerViewModel>> GetCustomer(int id)
        {
            var Customer = await _customerService.GetCustommer(id);
            var mappedCustomer = _mapper.Map<CustomerViewModel>(Customer);
            return new GenericOutputResult<CustomerViewModel> { DataResult = mappedCustomer, Status = Customer.Status };
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<GenericOutputResult<QueryResult<CustomerViewModel>>> GetAll()
        {
            var Customers = await _customerService.GetAll();
            var mappedCustomers = _mapper.Map<IEnumerable<CustomerViewModel>>(Customers);
            var Data = new QueryResult<CustomerViewModel>(mappedCustomers, mappedCustomers.Count());
            return new GenericOutputResult<QueryResult<CustomerViewModel>> { DataResult = Data, Status = Customers.Status };
        }


        [HttpPost]
        [Route("GetPaged")]
        public async Task<GenericOutputResult<QueryResult<CustomerViewModel>>> GetPaged([FromBody] QueryObjectParams queryObject)
        {
            var queryResult = await _customerService.GetPaged(queryObject);

            var mappedCustomers = _mapper.Map<IEnumerable<CustomerViewModel>>(queryResult.DataResult.Entities);

            var data = new QueryResult<CustomerViewModel>(mappedCustomers, queryResult.DataResult.TotalCount);

            return new GenericOutputResult<QueryResult<CustomerViewModel>> { Status = queryResult.Status , DataResult = data };
        }


        [HttpPost]
        [Route("Add")]
        public async Task<GenericOutputResult<TblCustomer>> Add([FromBody] CustomerSaveRequestModel Resource)
        {
            var Customer = _mapper.Map<CustomerSaveRequestModel, TblCustomer>(Resource);
            var res = await _customerService.Add(Customer);
            return new GenericOutputResult<TblCustomer> { DataResult = Customer, Status = res.Status };
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<GenericOutputResult<bool>> Delete(int id)
        {
            var res = await _customerService.Delete(id);
            return new GenericOutputResult<bool> { Status = res.Status, DataResult = res.DataResult };
        }
    }
}
