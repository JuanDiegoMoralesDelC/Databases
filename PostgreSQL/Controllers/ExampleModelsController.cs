using Data.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleModelsController : BaseController<ExampleModel>
    {
        public ExampleModelsController(ApplicationContext context) : base(context)
        {

        }
    }
}
