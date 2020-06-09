using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace chatapp.web.server.Data
{
    /// <summary>
    /// The database representational model for our application
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        #region Public Properties

        /// <summary>
        /// The settings for the application
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="option"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)  : base(option)
        {

        } 

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API

            modelBuilder.Entity<SettingsDataModel>()
                .HasIndex(a => a.Name);
        }

    }
}
