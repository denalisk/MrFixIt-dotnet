﻿using System;
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
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public Job ToggleActive(int targetId)
        {
            var pendingJob = db.Jobs.FirstOrDefault(job => job.JobId == targetId);
            pendingJob.Pending = (!(pendingJob.Pending));
            db.Entry(pendingJob).State = EntityState.Modified;
            db.SaveChanges();
            return pendingJob;
        }

        [HttpPost]
        public Job Complete(int targetId)
        {
            var pendingJob = db.Jobs.FirstOrDefault(job => job.JobId == targetId);
            pendingJob.Completed = (!(pendingJob.Completed));
            db.Entry(pendingJob).State = EntityState.Modified;
            db.SaveChanges();
            return pendingJob;
        }
    }
}
