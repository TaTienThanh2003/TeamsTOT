using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface IUserVocabularysService
    {
        ICollection<UserVocabularys> GetUserVocabularys(int studentId,int toppicId);
        bool AddUserVocabularys(UserVocabularys userVocabularys);
        bool Save();
    }
}
