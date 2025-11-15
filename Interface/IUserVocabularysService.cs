using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserVocabularysService
    {
        ICollection<UserVocabularys> GetUserVocabularys(Guid studentId, Guid toppicId);
        bool AddUserVocabularys(UserVocabularys userVocabularys);
        bool Save();
    }
}
