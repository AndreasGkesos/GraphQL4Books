using GraphQL.Types;
using GraphQL4Books.BL;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title).Description("The title of the review");
            Field(t => t.Body);
            Field(t => t.Book);
            Field(t => t.User);
        }
    }
}