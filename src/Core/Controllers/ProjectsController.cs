using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : XpController<Project>
    {
        public ProjectsController(
            INodeRepository repository)
            : base(repository) { }
    }
}
