namespace WebApi.Services
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using WebApi.Contract;
    using WebApi.Dtos;
    using WebApi.Repositories;

    /// <summary>
    /// Defines the <see cref="ExtensionService" />.
    /// </summary>
    public static class ExtensionService
    {
        /// <summary>
        /// The ConfigureDependencies.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<UserDto, RegisterDto>, UserRepository>();
            services.AddScoped<ILoginRepository<UserDto>, LoginRepository>();
            services.AddScoped<IGenericRepository<RolTaskDto, RolTaskDto>, RolTaskRepository>();
            services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
            services.AddSingleton<TokenService>();
        }

        /// <summary>
        /// The ConfigureJwt.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwSettings");
            string secretKey = jwtSettings.GetValue<string>("SecretKey");
            int minutesToExpiration = jwtSettings.GetValue<int>("MinutesToExpiration");
            string issuer = jwtSettings.GetValue<string>("Issuer");
            string audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(minutesToExpiration)
                };
            });
        }

        /// <summary>
        /// The ConfigureCors.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
        }
    }
}
