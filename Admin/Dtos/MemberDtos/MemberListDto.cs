using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;

namespace Admin.Dtos.MemberDtos
{
    public class MemberListDto
    {
        public IList<Member> Members { get; set; }
        public IList<IdentityRole> Roles { get; set; }
    }
}
