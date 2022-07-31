using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SilverhorseRecruitmentTest.Models;

namespace SilverhorseRecruitmentTest.Database
{
    //Implementing the Create, Read, Update, and Delete operations for a post object
    public class PostCRUD
    {
        public static async Task<List<Posts>> PostsAsync()
        {
            string response = await DataIn.Get("posts");
            List<Posts> postList = JsonConvert.DeserializeObject<List<Posts>>(response);

            return postList;
        }

        public static async Task<Posts> CreatePostAsync(int id)
        {
            //Calling Get method on specific id
            string response = await DataIn.Get("posts", id);
            var postObject = JsonConvert.DeserializeObject<Posts>(response);

            return postObject;
        }

        public static async Task<Posts> AddPostAsync(Posts postIn)
        {
            string response = await DataIn.Post("posts", postIn);
            var postObject = JsonConvert.DeserializeObject<Posts>(response);

            return postObject;
        }

        public static async Task<Posts> UpdatePostAsync(Posts postIn, int id)
        {
            string response = await DataIn.Put("posts", postIn, id);
            var postObject = JsonConvert.DeserializeObject<Posts>(response);

            return postObject;
        }

        public static async Task<Posts> DeletePostAsync(int id)
        {
            string response = await DataIn.Delete("posts", id);
            var postObject = JsonConvert.DeserializeObject<Posts>(response);

            return postObject;
        }
    }
}