using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Dal;
using Quiz.Dtos;
using Quiz.Model;

namespace Quiz.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainRepo _repo;
        private readonly IMapper _mapper;

        public MainController(IMapper mapper)
        {
            _repo = new MainRepo();
            _mapper = mapper;
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

        [HttpPost("saveExam")]
        public async Task<ActionResult<bool>> SaveExam(ExamPack examPack)
        {
            List<QuestionDto> insertableQuestionDtos = new List<QuestionDto>();
            List<AnswerDto> insertableAnswerDtos = new List<AnswerDto>();

            Exam exam = new();
            exam.Id = examPack.ExamId;
            exam.Header = examPack.ExamHeader;
            exam.Date = examPack.ExamDate;

            List<QuestionAndAnswerPackDto> questionAndAnswers = examPack.QuestionAndAnswers;

            foreach (QuestionAndAnswerPackDto item in questionAndAnswers)
            {
                insertableQuestionDtos.Add(item.Question);
                insertableAnswerDtos.AddRange(item.Answers);
            }

            List<Question> insertableQuestions = _mapper.Map<List<Question>>(insertableQuestionDtos);
            List<Answer> insertableAnswers = _mapper.Map<List<Answer>>(insertableAnswerDtos);

            _repo.AddExam(exam);
            _repo.AddQuestions(insertableQuestions);
            _repo.AddAnswers(insertableAnswers);

            return await _repo.SaveAsync();
        }

        [HttpGet("deleteExam/{examId}")]
        public async Task<ActionResult<bool>> DeleteExam(Guid examId)
        {
            var exam = await _repo.GetExam(examId);
            exam.IsDeleted = true;

            _repo.UpdateExam(exam);

            return await _repo.SaveAsync();
        }

        [HttpGet("getExamPage")]
        public async Task<ActionResult<List<ExamPack>>> GetExamPage()
        {
            List<ExamPack> examPacks = new List<ExamPack>();

            List<Exam> exams = await _repo.GetExams();

            foreach (Exam exam in exams)
            {
                ExamPack examPack = new ExamPack();
                examPack.ExamId = exam.Id;
                examPack.ExamHeader = exam.Header;
                examPack.ExamDate = exam.Date;
                examPack.QuestionAndAnswers = new();

                var questions = await _repo.GetQuestionsByExamId(exam.Id);

                foreach (var question in questions)
                {
                    QuestionAndAnswerPackDto questionAndAnswerPackDto = new QuestionAndAnswerPackDto();

                    var answers = await _repo.GetAnswersByQuestionId(question.Id);
                    questionAndAnswerPackDto.Question =_mapper.Map<QuestionDto>(question);
                    questionAndAnswerPackDto.Answers = _mapper.Map<List<AnswerDto>>(answers);
                    examPack.QuestionAndAnswers.Add(questionAndAnswerPackDto);
                }

                examPacks.Add(examPack);
            }


            return examPacks;
        }
    }
}
