using CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CandidateCH;
using CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CertificateCH;
using CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers.CandidateQR;
using CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers.CertificateQH;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CandidateCR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CandidateQR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR;
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
            builder.Services.AddScoped<IRequestHandler<UpdateCandidateCommand, int>, UpdateCandidateCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteCandidateCommand, int>, DeleteCandidateCommandHandler>();            
            
            builder.Services.AddScoped<IRequestHandler<GetCertificateByIdQuery, Certificate>, GetCertificateByIdQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateCertificateCommand, int>, CreateCertificateCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<UpdateCertificateCommand, int>, UpdateCertificateCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteCertificateCommand, int>, DeleteCertificateCommandHandler>();
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