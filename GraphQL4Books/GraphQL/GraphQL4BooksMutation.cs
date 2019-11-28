using GraphQL.Types;
using GraphQL4Books.API.GraphQL.Types;
using GraphQL4Books.BL;
using GraphQL4Books.DAL.Repos;
using System;

namespace GraphQL4Books.API.GraphQL
{
    public class GraphQL4BooksMutation : ObjectGraphType
    {
        public GraphQL4BooksMutation(ReviewRepository reviewRepository,
                                        BookRepository bookRepository,
                                        AuthorRepository authorRepository,
                                        UserRepository userRepository)
        {
            FieldAsync<ReviewType>(
                "postReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "review" }
                ),
                resolve: async context => {
                    var review = context.GetArgument<Review>("review");
                    return await context.TryAsyncResolve(async c => await reviewRepository.AddReviewAsync(review));
                }
            );

            FieldAsync<ReviewType>(
                "putReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "review" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "reviewId" }
                ),
                resolve: async context => {
                    var review = context.GetArgument<Review>("review");
                    var reviewId = context.GetArgument<Guid>("reviewId");

                    var oldReview = await reviewRepository.GetByIdAsync(reviewId);

                    return await context.TryAsyncResolve(async c => {
                        return await reviewRepository.UpdateReviewAsync(review, oldReview);
                    });
                }
            );

            FieldAsync<BookType>(
                "postBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }
                ),
                resolve: async context => {
                    var book = context.GetArgument<Book>("book");
                    return await context.TryAsyncResolve(async c => await bookRepository.AddBookAsync(book));
                }
            );

            FieldAsync<BookType>(
                "putBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "bookId" }
                ),
                resolve: async context => {
                    var book = context.GetArgument<Book>("book");
                    var bookId = context.GetArgument<Guid>("bookId");

                    var oldBook = await bookRepository.GetByIdAsync(bookId);

                    return await context.TryAsyncResolve(async c => {
                        return await bookRepository.UpdateBookAsync(book, oldBook);
                    });
                }
            );

            FieldAsync<AuthorType>(
                "postAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }
                ),
                resolve: async context => {
                    var author = context.GetArgument<Author>("author");
                    return await context.TryAsyncResolve(async c => await authorRepository.AddAuthorAsync(author));
                }
            );

            FieldAsync<AuthorType>(
                "putAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "authorId" }
                ),
                resolve: async context => {
                    var author = context.GetArgument<Author>("author");
                    var authorId = context.GetArgument<Guid>("authorId");

                    var oldAuthor = await authorRepository.GetByIdAsync(authorId);

                    return await context.TryAsyncResolve(async c => {
                        return await authorRepository.UpdateAuthorAsync(author, oldAuthor);
                    });
                }
            );

            FieldAsync<UserType>(
                "postUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: async context => {
                    var user = context.GetArgument<User>("user");
                    return await context.TryAsyncResolve(async c => await userRepository.AddUserAsync(user));
                }
            );

            FieldAsync<UserType>(
                "putUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }
                ),
                resolve: async context => {
                    var user = context.GetArgument<User>("user");
                    var userId = context.GetArgument<Guid>("userId");

                    var oldUser = await userRepository.GetByIdAsync(userId);

                    return await context.TryAsyncResolve(async c => {
                        return await userRepository.UpdateUserAsync(user, oldUser);
                    });
                }
            );
        }
    }
}
