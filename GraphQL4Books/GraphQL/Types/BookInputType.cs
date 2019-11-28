using GraphQL.Types;

namespace GraphQL4Books.API.GraphQL.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "bookInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("description");
            Field<NonNullGraphType<IdGraphType>>("authorId");
        }
    }
}
