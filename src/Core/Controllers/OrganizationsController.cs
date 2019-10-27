using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : XpController<Organization>
    {

        public OrganizationsController(
            IRepository repository)
            : base(repository) { }
    }
}
