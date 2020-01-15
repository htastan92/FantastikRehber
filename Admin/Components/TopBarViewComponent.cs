﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Dtos.MemberDtos;
using DataAccess.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Components
{
    public class TopBarViewComponent : ViewComponent
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Member> _userManager;

        public TopBarViewComponent(Microsoft.AspNetCore.Identity.UserManager<Member> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var id = User.Identity.GetUserId();
            var user = _userManager.FindByIdAsync(id).Result;
            var dto = new TopBarDto
            {
                ImageUrl = user.ImageUrl,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View("~/Views/Shared/TopBarPartialView.cshtml", dto);
        }
    }
}
