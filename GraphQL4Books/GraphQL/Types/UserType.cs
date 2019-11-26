using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(ReviewRepository reviewRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(t => t.Name).Description("The name of the user");
            Field(t => t.Email);
            Field<ListGraphType<ReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var reviews = reviewRepository.GetForUser(context.Source.Id);
                    return reviews;
                }
            );
        }
    }
}