using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : XpController<Employee>
    {
        public EmployeesController(
            IRepository repository) 
            : base(repository) { }
    }
}
