using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Entities.Wall;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParrisConnection.DataLayer.Entities
{
    public class ParrisDbContext : IdentityDbContext<ConnectionUser>
    {
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<AlbumPhoto> AlbumPhotos { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
        public DbSet<Link> Type { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ParrisDbContext() : base("ParrisConnection")
        {
            
        }

        public static ParrisDbContext Create()
        {
            return new ParrisDbContext();
        }
    }
}
