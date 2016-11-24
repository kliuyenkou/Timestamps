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
using TimestampsWeb.Models;

namespace TimestampsWeb.Controllers.API
{
    public class ProjectNominations1Controller : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProjectNominations1
        public IQueryable<ProjectNomination> GetProjectNominations()
        {
            return db.ProjectNominations;
        }

        // GET: api/ProjectNominations1/5
        [ResponseType(typeof(ProjectNomination))]
        public IHttpActionResult GetProjectNomination(int id)
        {
            ProjectNomination projectNomination = db.ProjectNominations.Find(id);
            if (projectNomination == null)
            {
                return NotFound();
            }

            return Ok(projectNomination);
        }

        // PUT: api/ProjectNominations1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjectNomination(int id, ProjectNomination projectNomination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectNomination.Id)
            {
                return BadRequest();
            }

            db.Entry(projectNomination).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectNominationExists(id))
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

        // POST: api/ProjectNominations1
        [ResponseType(typeof(ProjectNomination))]
        public IHttpActionResult PostProjectNomination(ProjectNomination projectNomination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectNominations.Add(projectNomination);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectNomination.Id }, projectNomination);
        }

        // DELETE: api/ProjectNominations1/5
        [ResponseType(typeof(ProjectNomination))]
        public IHttpActionResult DeleteProjectNomination(int id)
        {
            ProjectNomination projectNomination = db.ProjectNominations.Find(id);
            if (projectNomination == null)
            {
                return NotFound();
            }

            db.ProjectNominations.Remove(projectNomination);
            db.SaveChanges();

            return Ok(projectNomination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectNominationExists(int id)
        {
            return db.ProjectNominations.Count(e => e.Id == id) > 0;
        }
    }
}