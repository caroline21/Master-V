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
    public class SolicitdController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Solicitd
        public IQueryable<tblSolicitudV> GettblSolicitudV()
        {
            return db.tblSolicitudV;
        }

        // GET api/Solicitd/5
        [ResponseType(typeof(tblSolicitudV))]
        public IHttpActionResult GettblSolicitudV(int id)
        {
            tblSolicitudV tblsolicitudv = db.tblSolicitudV.Find(id);
            if (tblsolicitudv == null)
            {
                return NotFound();
            }

            return Ok(tblsolicitudv);
        }

        // PUT api/Solicitd/5
        public IHttpActionResult PuttblSolicitudV(int id, tblSolicitudV tblsolicitudv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblsolicitudv.IdSolicitud)
            {
                return BadRequest();
            }

            db.Entry(tblsolicitudv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSolicitudVExists(id))
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

        // POST api/Solicitd
        [ResponseType(typeof(tblSolicitudV))]
        public IHttpActionResult PosttblSolicitudV(tblSolicitudV tblsolicitudv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSolicitudV.Add(tblsolicitudv);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblsolicitudv.IdSolicitud }, tblsolicitudv);
        }

        // DELETE api/Solicitd/5
        [ResponseType(typeof(tblSolicitudV))]
        public IHttpActionResult DeletetblSolicitudV(int id)
        {
            tblSolicitudV tblsolicitudv = db.tblSolicitudV.Find(id);
            if (tblsolicitudv == null)
            {
                return NotFound();
            }

            db.tblSolicitudV.Remove(tblsolicitudv);
            db.SaveChanges();

            return Ok(tblsolicitudv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSolicitudVExists(int id)
        {
            return db.tblSolicitudV.Count(e => e.IdSolicitud == id) > 0;
        }
    }
}