using ParrisConnection.DataLayer.Entities;
using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.DataLayer.Repositories;

namespace ParrisConnection.DataLayer.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public IRepository<AlbumPhoto> AlbumPhotoes { get; set; }
        public IRepository<Education> Educations { get; set; }
        public IRepository<Email> Emails { get; set; }
        public IRepository<EmailType> EmailTypes { get; set; }
        public IRepository<Employer> Employers { get; set; }
        public IRepository<Link> Links { get; set; }
        public IRepository<LinkType> LinkTypes { get; set; }
        public IRepository<Phone> Phones { get; set; }
        public IRepository<PhoneType> PhoneTypes { get; set; }
        public IRepository<ProfilePhoto> ProfilePhotoes { get; set; }
        public IRepository<Quote> Quotes { get; set; }
        public IRepository<Comment> Comments { get; set; }
        public IRepository<Status> Statuses { get; set; }

        public DataAccess(ParrisDbContext context)
        {
            AlbumPhotoes   = new Repository<AlbumPhoto>(context);
            Educations     = new Repository<Education>(context);
            Emails         = new Repository<Email>(context);
            EmailTypes     = new Repository<EmailType>(context);
            Employers      = new Repository<Employer>(context);
            Links          = new Repository<Link>(context);
            LinkTypes      = new Repository<LinkType>(context);
            Phones         = new Repository<Phone>(context);
            PhoneTypes     = new Repository<PhoneType>(context);
            ProfilePhotoes = new Repository<ProfilePhoto>(context);
            Quotes         = new Repository<Quote>(context);
            Statuses       = new Repository<Status>(context);
            Comments       = new Repository<Comment>(context);
        }
    }
}
