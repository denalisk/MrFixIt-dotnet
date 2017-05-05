using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //This property went unused due to a decision to allow workers to be working on multiple different projects
        public bool Avaliable { get; set; }

        //this comes from Identity.User
        public string UserName { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public Worker()
        {
            Avaliable = true;
        }

    }
}