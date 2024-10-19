using Microsoft.EntityFrameworkCore;
using System;
using Data;
using Task1SphinxCommercial.DAL.Interfaces;
using Task1SphinxCommercial.DAL.Repositories;


namespace Task1SphinxCommercial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SphinxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddScoped<IClientService, ClientService>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IClientProductRepository, ClientProductRepository>();
            // Register the DAL repositories

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
           // app.MapFallbackToPage("/Clients/AddingClients");
            app.MapRazorPages();

            app.Run();
        }
    }
}
