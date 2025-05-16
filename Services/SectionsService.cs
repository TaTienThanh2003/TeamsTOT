using backTOT.Data;
using backTOT.Entitys;
using backTOT.Interface;

namespace backTOT.Services
{
    public class SectionsService : ISectionsService
    {
        private DataContext _context;
        public SectionsService(DataContext context)
        {
            _context = context;
        }
        public bool addSection(Sections sections)
        {
            _context.Sections.Add(sections);
            return Save();
        }

        public bool deleteSection(int sectionId)
        {
            var section = _context.Sections.FirstOrDefault(s => s.Id == sectionId);
            _context.Sections.Remove(section);
            return Save();
        }

        public Sections GetSectionById(int id)
        {
            return _context.Sections.FirstOrDefault(s => s.Id == id);
        }

        public bool ischeckId(int sectionId)
        {
            _context.Sections.FirstOrDefault(s => s.Id == sectionId);
            return true;
        }

        public bool ischeckName(string name)
        {
            return _context.Sections.Any(s => s.TitleVI == name);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool updateSection(Sections sections)
        {
            var section = _context.Sections.FirstOrDefault(s => s.Id == sections.Id);
            if (section == null)
            {
                return false;
            }
            // Cập nhật
            section.TitleVI = sections.TitleVI;
            section.TitleEN = sections.TitleEN;
            section.DesVI = sections.DesVI;
            section.DesEN = sections.DesEN;
            section.Courses_id = sections.Courses_id;
            section.Position = sections.Position;
            return Save();
        }
    }
}
