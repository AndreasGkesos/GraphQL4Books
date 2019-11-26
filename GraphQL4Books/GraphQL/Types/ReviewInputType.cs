using GraphQL.Types;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class ReviewInputType : InputObjectGraphType
    {
        public ReviewInputType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("body");
            Field<NonNullGraphType<IdGraphType>>("bookId");
            Field<NonNullGraphType<IdGraphType>>("userId");
        }
    }
}
