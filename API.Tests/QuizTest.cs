using API.Controllers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class QuizTest
    {
        [Fact]
        public async Task GetQuestion_WithGoodHeaders_ReturnsGetQuestionDTO()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase("IN_MEMORY_DATABASE")
            .Options;

            var mockRepo = new Mock<ApiContext>(options);

            QuestionsController controller = new QuestionsController(mockRepo.Object, new JsonSerializer(), new JsonErrorFormatter());
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers["X-Api-Request"] = "true";
            var result = await controller.GetQuestion(0);

            Assert.IsType<ActionResult<GetQuestionDTO>>(result);
        }
    }
}
