using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class LanguagesDAL : BaseDAL
    {
        public IEnumerable<Languages> GetAllLanguages() { return Db.Languages; }
        public Languages GetLanguageById(int id) { return Db.Languages.Find(id); }

        public Languages CreateLanguage(Languages Language)
        {
            Db.Languages.Add(Language);
            Db.SaveChanges();
            return Language;
        }

        public Languages UpdateLanguage(int id, Languages Language)
        {
            Db.Entry(Language).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
            return Language;
        }

        public void DeleteLanguage(int id)
        {
            Db.Languages.Remove(Db.Languages.Find(id));
            Db.SaveChanges();
        }

        public bool IsThereAnyLanguage(int id)
        {
            return Db.Languages.Any(L => L.ID == id);
        }
    }
}
