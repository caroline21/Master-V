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
    public class GastosSinComprobarController : ApiController
    {
        private Entities db = new Entities();

        // GET api/GastosSinComprobar
        public IQueryable<tblGastosSinComprobar> GettblGastosSinComprobar()
        {
            return db.tblGastosSinComprobar;
        }

        // GET api/GastosSinComprobar/5
        [ResponseType(typeof(tblGastosSinComprobar))]
        public IHttpActionResult GettblGastosSinComprobar(int id)
        {
            tblGastosSinComprobar tblgastossincomprobar = db.tblGastosSinComprobar.Find(id);
            if (tblgastossincomprobar == null)
            {
                return NotFound();
            }

            return Ok(tblgastossincomprobar);
        }

        // PUT api/GastosSinComprobar/5
        public IHttpActionResult PuttblGastosSinComprobar(int id, tblGastosSinComprobar tblgastossincomprobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblgastossincomprobar.IdGastosSinComprobar)
            {
                return BadRequest();
            }

            db.Entry(tblgastossincomprobar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGastosSinComprobarExists(id))
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

        // POST api/GastosSinComprobar
        [ResponseType(typeof(tblGastosSinComprobar))]
        public IHttpActionResult PosttblGastosSinComprobar(tblGastosSinComprobar tblgastossincomprobar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGastosSinComprobar.Add(tblgastossincomprobar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblGastosSinComprobarExists(tblgastossincomprobar.IdGastosSinComprobar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblgastossincomprobar.IdGastosSinComprobar }, tblgastossincomprobar);
        }

        // DELETE api/GastosSinComprobar/5
        [ResponseType(typeof(tblGastosSinComprobar))]
        public IHttpActionResult DeletetblGastosSinComprobar(int id)
        {
            tblGastosSinComprobar tblgastossincomprobar = db.tblGastosSinComprobar.Find(id);
            if (tblgastossincomprobar == null)
            {
                return NotFound();
            }

            db.tblGastosSinComprobar.Remove(tblgastossincomprobar);
            db.SaveChanges();

            return Ok(tblgastossincomprobar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGastosSinComprobarExists(int id)
        {
            return db.tblGastosSinComprobar.Count(e => e.IdGastosSinComprobar == id) > 0;
        }
    }
}