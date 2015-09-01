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
using System.Threading.Tasks;

namespace Master_V.Controllers
{
    public class ComprobacionController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Comprobacion
        public IEnumerable<ComprobacionesDTO> GettblComprobacion()
        {
            // Se obtienen las comprobaciones de la tabla.
            var comprobaciones = from c in db.tblComprobacion select c;

            // Se mapea ComprobacionesDTO con tblComprobación.
            var comprobacionesDTO = AutoMapper.Mapper.Map <IEnumerable<ComprobacionesDTO>>(comprobaciones);

            // Se regresa la información.
            return comprobacionesDTO;
        }

        // GET api/Comprobacion/5
        [ResponseType(typeof(ComprobacionDTO))]
        public IHttpActionResult GetComprobación(int idComp)
        {
            var compDTO = new ComprobacionDTO();

            if (db.tblComprobacion.Find(idComp) != null)
            {
                var compGastot    = from cg  in db.tblComprobacionGastos where cg.IdComprobacion  == idComp select cg;
                var gastosSinComp = from gsc in db.tblGastosSinComprobar where gsc.IdComprobacion == idComp select gsc;
                var totDiarios    = from td  in db.tblTotalDiario        where td.IdComprobacion  == idComp select td;
                var totGastos     = from tg  in db.tblTotalGastos        where tg.IdComprabacion  == idComp select tg;
                var comprobacion  = from c in db.tblComprobacion
                                   select new ComprobacionDTO
                                   {
                                       IdSolicitud = c.Idcomprobacion,
                                       IdProyecto = c.IdProyecto,
                                       IdEmpleado = c.IdEmpleado,
                                       fecha = c.fecha,
                                       gerenteAdmin = c.gerenteAdmin,
                                       jefeInmediato = c.jefeInmediato,
                                       areaContable = c.areaContable,
                                       tblComprobacionGastos = compGastot,
                                       tblGastosSinComprobar = gastosSinComp,
                                       tblTotalDiario = totDiarios,
                                       tblTotalGastos = totGastos
                                   };

                compDTO = AutoMapper.Mapper.Map<ComprobacionDTO>(comprobacion);
            }
            else
            {
                return NotFound();
            }

            return Ok(compDTO);
        }

        // PUT api/Comprobacion/5
        public IHttpActionResult PuttblComprobación(int id, tblComprobacion tblcomprobación)
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
        [ResponseType(typeof(tblComprobacion))]
        public IHttpActionResult PosttblComprobación(tblComprobacion tblcomprobación)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblComprobacion.Add(tblcomprobación);

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
        [ResponseType(typeof(tblComprobacion))]
        public IHttpActionResult DeletetblComprobación(int id)
        {
            tblComprobacion tblcomprobación = db.tblComprobacion.Find(id);
            if (tblcomprobación == null)
            {
                return NotFound();
            }

            db.tblComprobacion.Remove(tblcomprobación);
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
            return db.tblComprobacion.Count(e => e.Idcomprobacion == id) > 0;
        }
    }
}