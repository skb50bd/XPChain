using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfWorkController : XpController<UnitOfWork>
    {

        public UnitOfWorkController(
            IRepository repository)
            : base(repository) { }
    }
}
