﻿using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL4Books.API.GraphQL;
using GraphQL4Books.DAL;
using GraphQL4Books.DAL.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL4Books
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
                                        options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddScoped<BookRepository>();
            services.AddScoped<ReviewRepository>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<UserRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<GraphQL4BooksSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseGraphQL<GraphQL4BooksSchema>();
            app.UseGraphiQl();
            app.UseHttpsRedirection();
        }
    }
}