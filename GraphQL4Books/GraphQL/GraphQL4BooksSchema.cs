using GraphQL;
using GraphQL.Types;

namespace GraphQL4Books.API.GraphQL
{
    public class GraphQL4BooksSchema : Schema
    {
        public GraphQL4BooksSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphQL4BooksQuery>();
        }
    }
}
