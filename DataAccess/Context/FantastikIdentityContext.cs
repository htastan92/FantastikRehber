using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class FantastikIdentityContext:IdentityDbContext<Member,MemberRole,string>
    {
        public FantastikIdentityContext(DbContextOptions<FantastikIdentityContext> options) : base(options)
        {
            
        }

    }
}
