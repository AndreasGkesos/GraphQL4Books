using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL4Books.BL
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
