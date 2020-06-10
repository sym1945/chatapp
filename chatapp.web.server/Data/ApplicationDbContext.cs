using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace chatapp.web.server.Data
{
    /// <summary>
    /// The database representational model for our application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
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
