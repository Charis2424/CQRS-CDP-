using CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers;
using CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRS_CDP_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });
            // Add services to the container.
            builder.Services.AddControllers();
            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

            builder.Services.AddScoped<IRequestHandler<GetCandidateByIdQuery, Candidate>, GetCandidateByIdQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateCandidateCommand, int>, CreateCandidateCommandHandler>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("localhost")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}