using GraphQL.Types;
using GraphQL4Books.API.GraphQL.Types;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL
{
    public class GraphQL4BooksQuery : ObjectGraphType
    {
        public GraphQL4BooksQuery(BookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => bookRepository.GetAll()
            );

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return bookRepository.GetById(id);
                }
            );
        }
    }
}
