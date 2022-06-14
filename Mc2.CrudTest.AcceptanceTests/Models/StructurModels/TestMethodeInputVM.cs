using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Models
{
    public class TestMethodeInputVM
    {
        public ServicesTestTypes servicesTestTypes { get; set; }
        public string Address { get; set; }
    }

    public static class ControllersListCls{
        public static List<string> ControllersList()
        {
            List<string> Controllers = new List<string>();
            Controllers.Add("Test_CustomerController");
            return Controllers;
        }
    }
}
