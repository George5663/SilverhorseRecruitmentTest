using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SilverhorseRecruitmentTest.Database;
using SilverhorseRecruitmentTest.Models;

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
            try
            {
                var posts = await PostCRUD.PostsAsync();
                return Ok(posts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //Get a specified post
        // GET: api/<PostsController>/10
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                var singularPost = await PostCRUD.CreatePostAsync(id);
                return Ok(singularPost);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //Get a specified post
        // GET: api/<PostsController>/10
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> AddPost([FromBody] Posts post)
        {
            try
            {
                //Check if post isn't null
                if (post == null)
                {
                    return BadRequest("Post is empty");
                }
                else
                {
                    var addedPost = await PostCRUD.AddPostAsync(post);
                    return Ok(addedPost);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //Update a specified post
        // GET: api/<PostsController>/10
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost([FromBody] Posts post, int id)
        {
            try
            {
                //Check if post isn't null
                if (post == null)
                {
                    return BadRequest("Post is empty");
                }
                else
                {
                    var updatedPost = await PostCRUD.UpdatePostAsync(post, id);
                    return Ok(updatedPost);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //Delete a specified post
        // GET: api/<PostsController>/10
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var deletedPost = await PostCRUD.DeletePostAsync(id);
                return StatusCode(StatusCodes.Status200OK, "Delete successful");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
