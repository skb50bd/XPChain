using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : XpController<Organization>
    {

        public OrganizationsController(
            INodeRepository repository)
            : base(repository) { }
    }
}
