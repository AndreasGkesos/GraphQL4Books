using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;
using System.Linq;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(BookRepository bookRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(t => t.Name).Description("The name of the author");
            Field(t => t.Bio);
            Field(t => t.Email);
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context =>
                {
                    var books = bookRepository.GetForAuthor(context.Source.Id);
                    return books;
                }
            );
        }
    }
}