using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SilverhorseRecruitmentTest.Models;
using WebAPISilverhorse.Models;

namespace SilverhorseRecruitmentTest.Database
{
    public static class GetData
    {
        public static async Task<Dictionary<string, List<object>>> Collections()
        {

            List<Object> posts = new List<Object>();
            List<Object> albums = new List<Object>();
            List<Object> users = new List<Object>();
            Random random = new Random();

            //Recieving all data from datasource
            string postsIn = await DataIn.Get("posts");
            string albumsIn = await DataIn.Get("albums");
            string usersIn = await DataIn.Get("users");

            //Adding all data to individual lists
            List<Posts> postList = JsonConvert.DeserializeObject<List<Posts>>(postsIn);
            List<Albums> albumsList = JsonConvert.DeserializeObject<List<Albums>>(albumsIn);
            List<Users> usersList = JsonConvert.DeserializeObject<List<Users>>(usersIn);


            //Randomly add 30 items to the collection
            for (var i = 0; i < 30; i++)
            {
                //Get a random int from 0 to 2 inclusive
                var n = random.Next(0, 3);
                if (n == 0)
                {
                    //Get a random response from the 100 post objects
                    posts.Add(postList[random.Next(0, 100)]);
                }
                else if (n == 1)
                {
                    //Get a random response from the 100 album objects
                    albums.Add(albumsList[random.Next(0, 100)]);
                }
                else
                {
                    //Get a random response from the 10 user objects
                    users.Add(usersList[random.Next(0, 10)]);
                }
            }

            //Combine the individual lists into one Dictionary
            Dictionary<string, List<object>> collectionDic = new Dictionary<string, List<object>>
            {
                { "post", posts },
                { "album", albums },
                { "user", users }
            };

            string serialData = JsonConvert.SerializeObject(collectionDic);

            return collectionDic;
        }
    }
}