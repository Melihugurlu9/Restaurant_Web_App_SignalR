using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
{
    public EfSocialMediaDal(SignalRContext context) : base(context)
    {
    }
}