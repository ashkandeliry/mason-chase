using AutoMapper;
using Mc2.Crud.Core.Domain;
using Mc2.Crud.Core.Entities;
using Mc2.Crud.Models;
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
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _customerService.GetOrder(id);
            if (order is null)
                return NotFound();
            var mappedOrder = _mapper.Map<CustomerViewModel>(order);
            return Ok(mappedOrder);
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _customerService.GetAll();
            if (orders is null)
                return NotFound();
            var mappedOrders = _mapper.Map<IEnumerable<CustomerViewModel>>(orders);
            return Ok(new QueryResult<CustomerViewModel>(mappedOrders, mappedOrders.Count()));
        }


        [HttpPost]
        [Route("GetPaged")]
        public async Task<IActionResult> GetPaged([FromBody] QueryObjectParams queryObject)
        {
            var queryResult = await _customerService.GetPaged(queryObject);
            if (queryResult is null)
                return NotFound();

            var mappedOrders = _mapper.Map<IEnumerable<CustomerViewModel>>(queryResult.Entities);

            return Ok(new QueryResult<CustomerViewModel>(mappedOrders, queryResult.TotalCount));
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CustomerSaveRequestModel Resource)
        {
            var order = _mapper.Map<CustomerSaveRequestModel, TblCustomer>(Resource);
            var res = await _customerService.Add(order);
            if (!res.Status)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return Ok();
        }
    }
}
