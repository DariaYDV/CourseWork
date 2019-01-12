using ComputersDBCW.Context;
using ComputersDBCW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;


namespace ComputersDBCW.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComputersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        /*[HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = from computer in db.Computers
                             select new
                             {
                                 computer.Index,
                                 computer.Model,
                                 computer.Price,
                                 computer.CPU,
                                 computer.RAM
                             };
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }*/
        public IQueryable<Computers> GetComputer()
        {
            return db.Computers;
        }

        // GET: api/Computers/5
        [ResponseType(typeof(Computers))]
        public IHttpActionResult GetComputer(int id)
        {
            Computers computer = db.Computers.Find(id);
            if (computer == null)
            {
                return NotFound();
            }

            return Ok(computer);
        }
        // PUT: api/Computers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComputer(int id, Computers computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.Index)
            {
                return BadRequest();
            }

            db.Entry(computer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Computers
        [ResponseType(typeof(Computers))]
        public IHttpActionResult PostComputer(Computers computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Computers.Add(computer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = computer.Index }, computer);
        }

        // DELETE: api/Computers/5
        [ResponseType(typeof(Computers))]
        public IHttpActionResult DeleteComputer(int id)
        {
            Computers computer = db.Computers.Find(id);
            if (computer == null)
            {
                return NotFound();
            }

            db.Computers.Remove(computer);
            db.SaveChanges();

            return Ok(computer);
        }
        //метод особождения распределенных ресурсов 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComputerExists(int id)
        {
            return db.Computers.Count(e => e.Index == id) > 0;
        }

    }
}
