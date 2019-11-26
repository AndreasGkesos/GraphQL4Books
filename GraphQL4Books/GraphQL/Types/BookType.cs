using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;
using System.Linq;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(ReviewRepository reviewRepository, AuthorRepository authorRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(t => t.Title).Description("The title of the book");
            Field(t => t.Description);
            Field<AuthorType>(
                "author",
                resolve: context =>
                {
                    var author = authorRepository.GetById(context.Source.AuthodId);
                    return author;
                }
            );
            Field<ListGraphType<ReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var reviews = reviewRepository.GetForBooks(context.Source.Reviews.Select(x => x.BookId).ToList());
                    return reviews;
                }
            );
            //FieldAsync<AuthorType>(
            //    "author",
            //    resolve: async context =>
            //    {
            //        var author = await authorRepository.GetByIdAsync(context.Source.AuthodId);
            //        return author;

            //        //return await context.TryAsyncResolve(
            //        //    async c => await authorRepository.GetById(context.Source.AuthodId)
            //        //);

            //        //object lockObj = new object(); ;
            //        //lock (lockObj)
            //        //{
            //        //    var author = authorRepository.GetById(context.Source.AuthodId);
            //        //    return author;
            //        //}
            //    }
            //);
        }
    }
}
