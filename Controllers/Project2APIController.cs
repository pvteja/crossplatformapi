using Microsoft.AspNetCore.Mvc;


namespace Project2_BuildAapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Project2APIController : ControllerBase
    {
        
        
        private readonly ILogger<Project2APIController> _logger;

        public Project2APIController(ILogger<Project2APIController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetQuestionsList")]
        public IEnumerable<Exercise> Get()
        {
            QuestionGen questionGen = new QuestionGen();
           
            var listOfQuestions = new List<string>();

            for (int i=0; i<10; i++)
            {
                listOfQuestions.Add(questionGen.question());
            }
            string[] arrayOfQuestions = listOfQuestions.ToArray();

            var listOfOptions = new List<int[]>();
            for (int i = 0; i<10; i++)
            {
                listOfOptions.Add(questionGen.genOptions(arrayOfQuestions[i]));
            }
            int[][] arrayOfOptions = listOfOptions.ToArray();

            return Enumerable.Range(1, 10).Select(index => new Exercise
            {
                id=index.ToString(),
                question=arrayOfQuestions[index-1]+"=?",
                optionA=arrayOfOptions[index-1][0].ToString(),
                optionB=arrayOfOptions[index-1][1].ToString(),
                optionC=arrayOfOptions[index-1][2].ToString(),
                answer=arrayOfOptions[index-1][3].ToString()
            })
            .ToArray();
        }
    }
}