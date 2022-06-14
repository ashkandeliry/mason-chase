using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.TestMethodes.IntegrationTest
{
    public class IT_Modify
    {
        public async Task<HttpResponseMessage> ModifyAsync(TestMethodeInputVM model, object MainMethodeInputVM)
        {
            var payLoad = JsonConvert.SerializeObject(MainMethodeInputVM);
            var res = await APIcaller.CsWebApiHelper.CallPostMethod(model.Address, payLoad);
            return res;
        }
    }
}
