using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace friendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        #region Static and Data
        static List<string> friendsList = new List<string>()
        {
            "Minal","Suresh","Kriti","Maitree"
        };
        #endregion

        #region Get methods
        [HttpGet]
        [Route("/list")]
        public IActionResult ShowAllFriends()
        {
            return Ok(friendsList);
        }

        [HttpGet]
        [Route("/list/index/{id}")]
        public IActionResult GetFriendByIndex(int id)
        {
            if (friendsList.Count > id)
            {
                var friend = friendsList[id];
                return Ok(friend);
            }
            return NotFound("Sorry no friend at this position");           
        }

        [HttpGet]
        [Route("/list/search/{chars}")]
        public IActionResult GetFriendByChar(string chars)
        {
            var friends = from f in friendsList
                          where f.StartsWith(chars)
                          select f;
            return Ok(friends);
        }
        #endregion

        #region Post, Update and Delete

        [HttpPost]
        [Route("/list/add/{name}")]
        public IActionResult AddFriend(string name)
        {
            friendsList.Add(name);
            return Created("", name + " Added to your friend list");
        }
        [HttpPut]
        [Route("/list/update/{idx}/{newName}")]
        public IActionResult UpdateFriend(int idx, string newName)
        {
            friendsList[idx] = newName;
            return Accepted("Friend name has been updated");
        }
        [HttpDelete]
        [Route("/list/delete/{idx}")]
        public IActionResult DeleteFriend(int idx)
        {
            friendsList.RemoveAt(idx);
            return Accepted("Friend Removed from the list");
        }
        #endregion

    }
}
