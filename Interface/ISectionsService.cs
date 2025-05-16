using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ISectionsService
    {
        Sections GetSectionById(int id);
        bool ischeckId(int lessonId);
        bool ischeckName(String name);
        bool addSection(Sections sections);
        bool deleteSection(int sectionId);
        bool updateSection(Sections sections);
        bool Save();
    }
}
