using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphQL4Books.BL
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("Author")]
        public Guid AuthodId { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
