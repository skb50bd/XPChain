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
    public class PiecesOfWorkController : XpController<UnitOfWork>
    {

        public PiecesOfWorkController(
            IRepository repository)
            : base(repository) { }
    }
}
