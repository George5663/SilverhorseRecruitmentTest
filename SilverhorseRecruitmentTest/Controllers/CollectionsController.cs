using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SilverhorseRecruitmentTest.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverhorseRecruitmentTest.Controllers
{
    [Route("/collections")]
    public class CollectionsController : Controller
    {
        [HttpGet]
        [Authorize]
        //Return the collection of posts/albums/users
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var collection = await GetData.Collections();

                return Ok(collection);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message.ToString());
            }
        }
    }
}