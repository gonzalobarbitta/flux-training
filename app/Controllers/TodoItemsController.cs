using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CloudSample.App.Web.Models;

namespace CloudSample.App.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return new[]
            {
                new TodoItem("Install prerequisites", true),
                new TodoItem("Create flux namespace", true),
                new TodoItem("Install flux", true),
                new TodoItem("Give write access on GitHub repository", true),
                new TodoItem("Demo"),
                new TodoItem("Review integration with Helm Operator"),
            };
        }
    }
}
