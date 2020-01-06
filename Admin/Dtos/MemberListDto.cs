using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entity;

namespace Admin.Dtos
{
    public class MemberListDto
    {
        public IList<Member> Members { get; set; }
    }
}
