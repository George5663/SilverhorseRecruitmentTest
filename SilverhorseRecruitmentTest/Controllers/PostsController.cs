using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SilverhorseRecruitmentTest.Controllers
{
    //Controller for Post CRUD routes
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        //Get all posts
        // GET: api/<PostsController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPosts()
        {

        }

    }
}
