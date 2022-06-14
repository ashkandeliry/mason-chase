using Mc2.Crud.Models;
using Mc2.Crud.Models.Generics;
using Mc2.CrudTest.AcceptanceTests.Models;
using Mc2.CrudTest.AcceptanceTests.TestMethodes.IntegrationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Public
{
    public class Test_CustomerController : ApiController
    {
        #region props
        private readonly IT_GetAll _IT_GetAll = new IT_GetAll();
        private readonly IT_GetByID _IT_GetByID = new IT_GetByID();
        private readonly IT_Modify _IT_Modify = new IT_Modify();
        #endregion
        #region Arrenges
        private static readonly string ServerUrl = "http://localhost:6717/api/v1/";
        private readonly Guid DefaultGuID = new Guid("00000000-0000-0000-0000-000000000000");
        private CustomerViewModel _Customer = new CustomerViewModel
        {
            BankAccountNumber = "123",
            DateOfBirth=DateTime.Parse("1998-01-05"),
            Email = "Test@gmail.com",
            Firstname = "Ashkan",
            Lastname = "Deliry",
            PhoneNumber = "09149321256"
        };
        #endregion

        #region GetAll Test 
        public async Task StatusCode200_GetAll()
        {
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.StatusCode200 }, _Customer);
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
        }
        public async Task NotStatusCode200_GetAll()
        {
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.NotStatusCode200 }, _Customer);
            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
        }
        public async Task MethodeResultCodeOk_GetAll()
        {
            GenericOutputResult<QueryResult<CustomerViewModel>> MethodResult = new GenericOutputResult<QueryResult<CustomerViewModel>>();
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.MethodeResultCodeOk }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<QueryResult<CustomerViewModel>>>(Result);
            Assert.Equals(true, MethodResult.Status);
        }
        public async Task MethodeResultCodeNotOk_GetAll()
        {
            GenericOutputResult<QueryResult<CustomerViewModel>> MethodResult = new GenericOutputResult<QueryResult<CustomerViewModel>>();
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.MethodeResultCodeNotOk }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<QueryResult<CustomerViewModel>>>(Result);
            Assert.AreNotEqual(true, MethodResult.Status);
        }
        public async Task CheckResultTotalCountIsNot0_GetAll()
        {
            GenericOutputResult<QueryResult<CustomerViewModel>> MethodResult = new GenericOutputResult<QueryResult<CustomerViewModel>>();
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.CheckResultTotalCountIsNot0 }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<QueryResult<CustomerViewModel>>>(Result);
            Assert.AreNotEqual(0, MethodResult.DataResult.TotalCount);
        }
        public async Task CheckResultTotalCountIs0_GetAll()
        {
            GenericOutputResult<QueryResult<CustomerViewModel>> MethodResult = new GenericOutputResult<QueryResult<CustomerViewModel>>();
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.CheckResultTotalCountIs0 }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<QueryResult<CustomerViewModel>>>(Result);
            Assert.Equals(0, MethodResult.DataResult.TotalCount);
        }
        public async Task CheckResultDataIsNull_GetAll()
        {
            GenericOutputResult<QueryResult<CustomerViewModel>> MethodResult = new GenericOutputResult<QueryResult<CustomerViewModel>>();
            var response = await _IT_GetAll.ListAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/List", servicesTestTypes = ServicesTestTypes.CheckResultDataIsNull }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<QueryResult<CustomerViewModel>>>(Result);
            Assert.IsNull(MethodResult.DataResult);
        }

        #endregion

        #region GetByID Test 
        public async Task StatusCode200_GetByID()
        {
            var response = await _IT_GetByID.GetAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/Get/" + DefaultGuID, servicesTestTypes = ServicesTestTypes.StatusCode200 }, _Customer);
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
        }
        public async Task NotStatusCode200_GetByID()
        {
            var response = await _IT_GetByID.GetAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/Get/" + DefaultGuID, servicesTestTypes = ServicesTestTypes.NotStatusCode200 }, _Customer);
            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
        }
        public async Task MethodeResultCodeOk_GetByID()
        {
            GenericOutputResult<CustomerViewModel> MethodResult = new GenericOutputResult<CustomerViewModel>();
            var response = await _IT_GetByID.GetAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/Get/" + DefaultGuID, servicesTestTypes = ServicesTestTypes.MethodeResultCodeOk }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<CustomerViewModel>>(Result);
            Assert.Equals(true, MethodResult.Status);
        }
        public async Task MethodeResultCodeNotOk_GetByID()
        {
            GenericOutputResult<CustomerViewModel> MethodResult = new GenericOutputResult<CustomerViewModel>();
            var response = await _IT_GetByID.GetAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/Get/" + DefaultGuID, servicesTestTypes = ServicesTestTypes.MethodeResultCodeNotOk }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<CustomerViewModel>>(Result);
            Assert.AreNotEqual(0, MethodResult.Status);
        }
        public async Task CheckResultDataIsNull_GetByID()
        {
            GenericOutputResult<CustomerViewModel> MethodResult = new GenericOutputResult<CustomerViewModel>();
            var response = await _IT_GetByID.GetAsync(new TestMethodeInputVM { Address = ServerUrl + "Customer/Get/" + DefaultGuID, servicesTestTypes = ServicesTestTypes.CheckResultDataIsNull }, _Customer);
            var Result = response.Content.ReadAsStringAsync().Result;
            MethodResult = JsonConvert.DeserializeObject<GenericOutputResult<CustomerViewModel>>(Result);
            Assert.IsNull(MethodResult.DataResult);
        }

        #endregion

        public class TestAssigner
        {
            Test_CustomerController _test_CustomerController = new Test_CustomerController();

            [Fact]
            async Task StatusCode200_GetAll() => await _test_CustomerController.StatusCode200_GetAll();
            [Fact]
            async Task MethodeResultCodeNotOk_GetByID() => await _test_CustomerController.MethodeResultCodeNotOk_GetByID();

        }


    }
}
