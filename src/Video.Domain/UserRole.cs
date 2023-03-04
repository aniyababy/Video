using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain
{
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
