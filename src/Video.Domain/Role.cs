using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain
{
    public class Role : Entity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
