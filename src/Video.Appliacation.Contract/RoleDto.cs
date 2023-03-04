using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract
{
    public class RoleDto:EntityDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
