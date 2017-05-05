using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
        // This controller helps mediate the display of job-related information regardless of user state, and allows visitors to submit jobs
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Claim(Job job)
            // This route claims a job for a worker, and makes the appropriate edits in the database. There is currently no funcitonality to un-claim a job
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public Job ToggleActive(int targetId)
            //This route toggles jobs as being worked on or not
        {
            var pendingJob = db.Jobs.FirstOrDefault(job => job.JobId == targetId);
            pendingJob.Pending = (!(pendingJob.Pending));
            db.Entry(pendingJob).State = EntityState.Modified;
            db.SaveChanges();
            return pendingJob;
        }

        [HttpPost]
        public Job Complete(int targetId)
            // This route toggles jobs as complete or not. There is no implemented functionality currently for "uncompleting" a job, but a call to this route would do it
        {
            var pendingJob = db.Jobs.FirstOrDefault(job => job.JobId == targetId);
            pendingJob.Completed = (!(pendingJob.Completed));
            db.Entry(pendingJob).State = EntityState.Modified;
            db.SaveChanges();
            return pendingJob;
        }
    }
}
