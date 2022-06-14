using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Crud.Models.Generics
{
    public class GenericOutputResult<T>
    {
            public T DataResult { get; set; }
            public bool Status { get; set; } = false;
    }
}
