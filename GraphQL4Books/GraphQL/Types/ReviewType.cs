using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType(ReviewRepository reviewRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(t => t.Title).Description("The title of the review");
            Field(t => t.Body);
            Field<BookType>(
                "book",
                resolve: context =>
                {
                    var book = reviewRepository.GetForBook(context.Source.Id);
                    return book;
                }
            );
            Field<BookType>(
                "user",
                resolve: context =>
                {
                    var user = reviewRepository.GetForUser(context.Source.Id);
                    return user;
                }
            );
        }
    }
}