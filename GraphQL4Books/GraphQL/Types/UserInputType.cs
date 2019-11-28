using GraphQL.Types;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("email");
        }
    }
}
