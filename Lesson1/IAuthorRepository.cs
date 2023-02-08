using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public interface IAuthorRepository
    {
        Author Add (Author author);
        void Remove (int id);

        Author Update (Author author);
        Author GetById (int id);

        void AddAuthors(object[] authors);

        void RemoveAuthors(int[] authorsIds);

        public void UpdateAuthors(object[] authors);

        IEnumerable<Author> GetAll();
    }
}
