using GraphQL.Types;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "authorInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("bio");
            Field<StringGraphType>("email");
        }
    }
}
