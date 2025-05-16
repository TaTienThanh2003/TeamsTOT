using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class CatalogsService : ICatalogsService
    {
        private DataContext _context;
        public CatalogsService(DataContext context)
        {
            _context = context;
        }
        public ICollection<Catalogs> GetCatalogs()
        {
            return _context.Catalogs.OrderBy(c => c.Id).ToList();
        }
    }
}
