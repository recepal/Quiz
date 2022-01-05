using Microsoft.AspNetCore.Mvc;
using Quiz.Dal;

namespace Quiz.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainRepo _repo;

        public MainController()
        {
            _repo = new MainRepo();
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("tamam");
        }

        [HttpGet("createDb")]
        public ActionResult CreateDb()
        {
            bool result = _repo.CreateDb();

            string message = result ? "Db oluşturuldu..." : "Db oluşturulamadı...";
            return Ok(message);
        }
    }
}
