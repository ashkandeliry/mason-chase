using Mc2.CrudTest.AcceptanceTests.ApiHelper;
using Mc2.CrudTest.AcceptanceTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.TestMethodes.IntegrationTest
{
    public class IT_GetAll
    {
        public async Task<HttpResponseMessage> ListAsync(TestMethodeInputVM model, object MainMethodeInputVM)
        {
            var payLoad = JsonConvert.SerializeObject(MainMethodeInputVM);
            var res = await APIcaller.CsWebApiHelper.CallPostMethod(model.Address, payLoad);
            return res;
        }
    }
}
