using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase 
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILogger<LocationController> logger, ILocationRepository repository)
        {
            _logger = logger;
            _locationRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPost() 
        {
            return Ok(_locationRepository.GetAllPost());
        }

        [HttpGet]
        [Route("{PostId:int}")]
        public ActionResult<Post> GetPostById(int postId) 
        {
            var post = _locationRepository.GetPostById(postId);
            if (post == null) {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> CreatePost(Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            var newPost = _locationRepository.CreatePost(post);
            return Created(nameof(GetPostById), newPost);
        }

        [HttpPut]
        [Route("{PostId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> UpdatePost(Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            return Ok(_locationRepository.UpdatePost(post));
        }

        [HttpDelete]
        [Route("{PostId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeletePost(int postId) 
        {
            _locationRepository.DeletePostById(postId); 
            return NoContent();
        }
    }
}
