using Core.Abstract;
using EntityLayer.Concrete;
using Service.Abstract;

namespace Service.Concrete
{
    public class PersonelService : GenericService<Personel>, IPersonelService
    {
        public PersonelService(IGenericRepository<Personel> repository) : base(repository)
        {
        }
    }
}
