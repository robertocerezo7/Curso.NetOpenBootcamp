using InternationalAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace InternationalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IStringLocalizer<PostController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;


        public PostController(IStringLocalizer<PostController> stringLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }


        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource() 
        {

            // Find Text
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName

            });

        }


        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {

            // Find Text
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;

            var todayIs = string.Format(_sharedResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());

            return Ok(new
            {
                PostType = article.Value,
                PostName = postName,
                TodayIs = todayIs

            });

        }

    }
}
