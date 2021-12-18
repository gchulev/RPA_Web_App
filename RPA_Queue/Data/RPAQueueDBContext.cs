using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPA_Queue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA_Queue.Data
{
    public class RPAQueueDBContext : IdentityDbContext<ApplicationUser>
    {
        public RPAQueueDBContext(DbContextOptions<RPAQueueDBContext> options) : base(options)
        {

        }

        public DbSet<RPAQueueModel> RPAQueue { get; set; }

    }
}
