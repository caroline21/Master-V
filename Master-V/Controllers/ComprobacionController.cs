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
using Master_V.Models;

namespace Master_V.Controllers
{
    public class ComprobacionController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Comprobacion
        public IQueryable<tblComprobación> GettblComprobación()
        {
            return db.tblComprobación;
        }

        // GET api/Comprobacion/5
        [ResponseType(typeof(tblComprobación))]
        public IHttpActionResult GettblComprobación(int id)
        {
            tblComprobación tblcomprobación = db.tblComprobación.Find(id);
            if (tblcomprobación == null)
            {
                return NotFound();
            }

            return Ok(tblcomprobación);
        }

        // PUT api/Comprobacion/5
        public IHttpActionResult PuttblComprobación(int id, tblComprobación tblcomprobación)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblcomprobación.Idcomprobacion)
            {
                return BadRequest();
            }

            db.Entry(tblcomprobación).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblComprobaciónExists(id))
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

        // POST api/Comprobacion
        [ResponseType(typeof(tblComprobación))]
        public IHttpActionResult PosttblComprobación(tblComprobación tblcomprobación)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblComprobación.Add(tblcomprobación);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblComprobaciónExists(tblcomprobación.Idcomprobacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblcomprobación.Idcomprobacion }, tblcomprobación);
        }

        // DELETE api/Comprobacion/5
        [ResponseType(typeof(tblComprobación))]
        public IHttpActionResult DeletetblComprobación(int id)
        {
            tblComprobación tblcomprobación = db.tblComprobación.Find(id);
            if (tblcomprobación == null)
            {
                return NotFound();
            }

            db.tblComprobación.Remove(tblcomprobación);
            db.SaveChanges();

            return Ok(tblcomprobación);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblComprobaciónExists(int id)
        {
            return db.tblComprobación.Count(e => e.Idcomprobacion == id) > 0;
        }
    }
}