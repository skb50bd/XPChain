using System;
using System.Collections.Generic;
using Data.Persistence;
using Domain;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public abstract class XpController<T> : ControllerBase where T : Entity
    {
        protected readonly INodeRepository Repository;

        protected XpController(
            INodeRepository repository)
        {
            Repository = repository;
        }


        [HttpGet]
        public IEnumerable<T> Get()
        {
            return Repository.GetAll<T>();
        }

        [HttpGet("{id}")]
        public T Get(ObjectId id) => 
            Repository.SingleById<T>(id);

        // POST: api/Organizations
        [HttpPost]
        public IActionResult Post([FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest("The model is not valid");

            var prev =
                Repository.FirstOrDefault<T>(o => o.Id == item.Id);
            if (!(prev is null))
                return BadRequest("An item with the same ID already exists");

            Repository.Insert(item);
            var obj =
                Repository.FirstOrDefault<T>(o => o.Id == item.Id);

            return Ok(obj);
        }
    }
}
