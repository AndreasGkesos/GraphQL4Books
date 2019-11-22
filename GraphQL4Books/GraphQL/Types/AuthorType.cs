using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(BookRepository bookRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the author");
            Field(t => t.Bio);
            Field(t => t.Email);
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context =>
                {
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Book>(
                        "GetReviewByProductId", bookRepository.GetForAuthors);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}