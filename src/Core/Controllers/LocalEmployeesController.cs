using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalEmployeesController : ControllerBase
    {
        private readonly INodeRepository _repository;

        public LocalEmployeesController(
            INodeRepository repository)
        {
            _repository = repository;
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var objId = new ObjectId(id);
            var res = _repository.Delete<LocalEmployee>(objId);

            if (res)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}