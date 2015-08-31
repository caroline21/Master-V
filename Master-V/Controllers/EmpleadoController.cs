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
    public class EmpleadoController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Empleado
        public IEnumerable<EmpleadoDTO> GettblEmpleado()
        {
            var emp = from a in db.tblEmpleado select a;
            var empleado = AutoMapper.Mapper.Map<IEnumerable<EmpleadoDTO>>(emp);

            return empleado;
            
        }

        // GET api/Empleado/5
        [ResponseType(typeof(tblEmpleado))]
        public IHttpActionResult GettblEmpleado(int id)
        {
            var emp = db.tblEmpleado.Find(id);
            var empleado = AutoMapper.Mapper.Map<EmpleadoDTO>(emp);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // PUT api/Empleado/5
        public IHttpActionResult PuttblEmpleado(int id, EmpleadoDTO empleado)
        {
            var emp = AutoMapper.Mapper.Map<EmpleadoDTO,tblEmpleado>(empleado);
            emp.IdEmpleado = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp.IdEmpleado)
            {
                return BadRequest();
            }

            db.Entry(emp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEmpleadoExists(id))
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

        // POST api/Empleado
        [ResponseType(typeof(EmpleadoDTO))]
        public IHttpActionResult PosttblEmpleado(EmpleadoDTO empleado)
        {
            var emp = AutoMapper.Mapper.Map<tblEmpleado>(empleado);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEmpleado.Add(emp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emp.IdEmpleado }, emp);
        }

        // DELETE api/Empleado/5
        [ResponseType(typeof(tblEmpleado))]
        public IHttpActionResult DeletetblEmpleado(int id)
        {
            var  emp = db.tblEmpleado.Find(id);
            var empleado = AutoMapper.Mapper.Map<tblEmpleado>(emp);

            if (empleado == null)
            {
                return NotFound();
            }

            db.tblEmpleado.Remove(empleado);
            db.SaveChanges();

            return Ok(emp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEmpleadoExists(int id)
        {
            return db.tblEmpleado.Count(e => e.IdEmpleado == id) > 0;
        }
    }
}