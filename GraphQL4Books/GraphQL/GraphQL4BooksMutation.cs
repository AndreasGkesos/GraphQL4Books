using GraphQL.Types;
using GraphQL4Books.API.GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;

namespace GraphQL4Books.API.GraphQL
{
    public class GraphQL4BooksMutation : ObjectGraphType
    {
        public GraphQL4BooksMutation(ReviewRepository reviewRepository)
        {
            FieldAsync<ReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "review" }
                ),
                resolve: async context => {
                    var review = context.GetArgument<Review>("review");
                    return await context.TryAsyncResolve(async c => await reviewRepository.AddReviewAsync(review));
                }
            );
        }
    }
}
