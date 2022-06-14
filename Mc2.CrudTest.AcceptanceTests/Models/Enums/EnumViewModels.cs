using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Models
{
    public enum ServicesTestTypes
    {
        [Display(Name = "فراخوانی موفق سرویس")]
        StatusCode200 = 1,
        [Display(Name = "فراخوانی ناموفق سرویس")]
        NotStatusCode200 = 2,
        [Display(Name = "عملیات موفق متد")]
        MethodeResultCodeOk = 3,
        [Display(Name = "عملیات ناموفق متد")]
        MethodeResultCodeNotOk = 4,
        [Display(Name = "بررسی خالی بودن خروجی متد")]
        CheckResultDataIsNull = 5,
        [Display(Name = "بررسی خالی نبودن خروجی متد")]
        CheckResultDataIsNotNull = 6,
        [Display(Name = "بررسی صفر بودن فیلد getTotalCount")]
        CheckResultTotalCountIs0 = 7,
        [Display(Name = "بررسی صفر نبودن فیلد getTotalCount")]
        CheckResultTotalCountIsNot0 = 8,
    }
}
