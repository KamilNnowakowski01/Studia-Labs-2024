using Labs2024_Infrastructure;
using Labs2024_WebPages.ServicesClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Labs2024_WebPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                throw new ArgumentNullException("ApiSettings:BaseUrl", "API Base URL is not configured.");
            }

            // Configure HttpClient with BaseAddress
            builder.Services.AddHttpClient("Labs2024API", client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl); // Replace with your actual API base URL
            });


            builder.Services.AddSingleton<JwtService>();

            builder.Services.AddScoped<AuthenticationService>(provider =>
            {
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient("Labs2024API");
                var jwtService = provider.GetRequiredService<JwtService>();
                return new AuthenticationService(httpClient, jwtService);
            });

            builder.Services.AddScoped<ApiService>(provider =>
            {
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient("Labs2024API");
                var jwtService = provider.GetRequiredService<JwtService>();
                return new ApiService(httpClient, jwtService);
            });

            builder.Services.AddScoped<UserService>(provider =>
            {
                var apiService = provider.GetRequiredService<ApiService>();
                return new UserService(apiService);
            });

            builder.Services.AddScoped<ICarService, CarService>(provider =>
            {
                var apiService = provider.GetRequiredService<ApiService>();
                return new CarService(apiService);
            });

            builder.Services.AddScoped<IRentalService, RentalService>(provider =>
            {
                var apiService = provider.GetRequiredService<ApiService>();
                return new RentalService(apiService);
            });

            // Add session services
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });

            builder.Services.AddHttpContextAccessor(); // Add this if HttpContextAccessor is needed


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOrUserPolicy", policy => policy.RequireRole("Admin", "User"));
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
            });


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
            app.UseSession();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
