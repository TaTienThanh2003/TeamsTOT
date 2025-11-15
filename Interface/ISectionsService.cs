using backTOT.Entitys;

namespace backTOT.Interface
{
    public interface ISectionsService
    {
        Sections GetSectionById(Guid id);
        bool ischeckId(Guid lessonId);
        bool ischeckName(String name);
        bool addSection(Sections sections);
        bool deleteSection(Guid sectionId);
        bool updateSection(Sections sections);
        bool Save();
    }
}
