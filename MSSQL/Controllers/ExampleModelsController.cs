using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MSSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleModelsController : BaseController<ExampleModel>
    {
        public ExampleModelsController(ApplicationContext context):base(context)
        {
            
        }
    }
}
