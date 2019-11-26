using GraphQL.Types;
using GraphQL4Books.API.GraphQL.Types;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL
{
    public class GraphQL4BooksQuery : ObjectGraphType
    {
        public GraphQL4BooksQuery(
            BookRepository bookRepository,
            UserRepository userRepository,
            ReviewRepository reviewRepository,
            AuthorRepository authorRepository)
        {
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => bookRepository.GetAll()
            );

            //FieldAsync<ListGraphType<BookType>>(
            //    "books",
            //    resolve: async context => await bookRepository.GetAll()
            //);

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return bookRepository.GetById(id);
                }
            );

            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => userRepository.GetAll()
            );

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return userRepository.GetById(id);
                }
            );

            Field<ListGraphType<ReviewType>>(
                "reviews",
                resolve: context => reviewRepository.GetAll()
            );

            Field<ReviewType>(
                "review",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return reviewRepository.GetById(id);
                }
            );

            Field<ListGraphType<AuthorType>>(
                "authors",
                resolve: context => authorRepository.GetAll()
            );

            Field<AuthorType>(
                "author",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return authorRepository.GetById(id);
                }
            );
        }
    }
}
