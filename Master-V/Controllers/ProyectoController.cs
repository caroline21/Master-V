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
    public class ProyectoController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Proyecto
        public IQueryable<tblProyecto> GettblProyecto()
        {
            return db.tblProyecto;
        }

        // GET api/Proyecto/5
        [ResponseType(typeof(tblProyecto))]
        public IHttpActionResult GettblProyecto(string id)
        {
            tblProyecto tblproyecto = db.tblProyecto.Find(id);
            if (tblproyecto == null)
            {
                return NotFound();
            }

            return Ok(tblproyecto);
        }

        // PUT api/Proyecto/5
        public IHttpActionResult PuttblProyecto(string id, tblProyecto tblproyecto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblproyecto.IdProyecto)
            {
                return BadRequest();
            }

            db.Entry(tblproyecto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProyectoExists(id))
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

        // POST api/Proyecto
        [ResponseType(typeof(tblProyecto))]
        public IHttpActionResult PosttblProyecto(tblProyecto tblproyecto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblProyecto.Add(tblproyecto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblProyectoExists(tblproyecto.IdProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblproyecto.IdProyecto }, tblproyecto);
        }

        // DELETE api/Proyecto/5
        [ResponseType(typeof(tblProyecto))]
        public IHttpActionResult DeletetblProyecto(string id)
        {
            tblProyecto tblproyecto = db.tblProyecto.Find(id);
            if (tblproyecto == null)
            {
                return NotFound();
            }

            db.tblProyecto.Remove(tblproyecto);
            db.SaveChanges();

            return Ok(tblproyecto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblProyectoExists(string id)
        {
            return db.tblProyecto.Count(e => e.IdProyecto == id) > 0;
        }
    }
}