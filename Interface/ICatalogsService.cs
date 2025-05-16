using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ICatalogsService
    {
        ICollection<Catalogs> GetCatalogs();
    }
}
