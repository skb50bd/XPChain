using System;
using System.Collections.Generic;
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
    public class OrganizationsController : ControllerBase
    {
        private readonly IRepository _repository;

        public OrganizationsController(
            IRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Organizations
        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return _repository.GetAll<Organization>();
        }

        // GET: api/Organizations/50m3Gu1d
        [HttpGet("{id}", Name = "Get")]
        public Organization Get(Guid id)
        {
            return _repository.FirstOrDefault<Organization>(o => o.Id == id);
        }

        // POST: api/Organizations
        [HttpPost]
        public IActionResult Post([FromBody] Organization item)
        {
            if(!ModelState.IsValid)
                return BadRequest("The model is not valid");

            var prev =
                _repository.FirstOrDefault<Organization>(o => o.Id == item.Id);
            if (!(prev is null))
                return BadRequest("An item with the same ID already exists");

            _repository.Insert(item);
            var obj =
                _repository.FirstOrDefault<Organization>(o => o.Id == item.Id);

            return Ok(obj);
        }
    }
}
