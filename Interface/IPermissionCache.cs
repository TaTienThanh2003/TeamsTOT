namespace backTOT.Interface
{
    public interface IPermissionCache
    {
        IEnumerable<string> GetAll();
        void Refresh();
    }
}
