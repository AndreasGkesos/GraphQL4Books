using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(ReviewRepository reviewRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(t => t.Title).Description("The title of the book");
            Field(t => t.Description);
            Field(t => t.Author, type: typeof(AuthorType));
            Field<ListGraphType<ReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Review>(
                        "GetReviewBybookId", reviewRepository.GetForBooks);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
