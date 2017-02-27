using ParrisConnection.DataLayer.Entities.Profile;
using ParrisConnection.DataLayer.Entities.Wall;
using ParrisConnection.DataLayer.Repositories;

namespace ParrisConnection.DataLayer.DataAccess
{
    public interface IDataAccess
    {
        IRepository<AlbumPhoto> AlbumPhotoes { get; set; }
        IRepository<Education> Educations { get; set; }
        IRepository<Email> Emails { get; set; }
        IRepository<EmailType> EmailTypes { get; set; }
        IRepository<Employer> Employers { get; set; }
        IRepository<Link> Links { get; set; }
        IRepository<LinkType> LinkTypes { get; set; }
        IRepository<Phone> Phones { get; set; }
        IRepository<PhoneType> PhoneTypes { get; set; }
        IRepository<ProfilePhoto> ProfilePhotoes { get; set; }
        IRepository<Quote> Quotes { get; set; }
        IRepository<Comment> Comments { get; set; }
        IRepository<Status> Statuses { get; set; }

        string GetUserNameById(string id);
    }
}