using Microsoft.AspNetCore.Mvc;
using Quiz.Dal;
using Quiz.Dtos;

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
            return Ok("Servis çalışıyor.");
        }

        [HttpGet("createDb")]
        public ActionResult CreateDb()
        {
            bool result = _repo.CreateDb();

            string message = result ? "Db oluşturuldu..." : "Db oluşturulamadı...";
            return Ok(message);
        }

        [HttpPost("saveQuiz")]
        public ActionResult<bool> SaveQuiz(List<QuestionAndAnswerPackDto> questionAndAnswerPackDtos)
        {
            List<QuestionDto> insertableQuestionDtos = new List<QuestionDto>();
            List<AnswerDto> insertableAnswerDtor = new List<AnswerDto>();

            foreach (QuestionAndAnswerPackDto item in questionAndAnswerPackDtos)
            {
                
            }

            return true;
        }
    }
}
