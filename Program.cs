
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VieWingsAPI.Repository;
using VieWingsAPI.Repository.RepositoryDetail;
using VieWingsAPI.Service;
using VieWingsAPI.Service.ServiceDetail;
using Microsoft.EntityFrameworkCore;
using VieWingsAPI.Repositories;

namespace VieWingsAPI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            //Connection db
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDb")));

            builder.Services.AddRazorPages();
            builder.Services.AddScoped< RoleDAO>();
            builder.Services.AddScoped< UserDAO>();
            builder.Services.AddScoped<ProfileDAO>();
            builder.Services.AddScoped< PostDAO>();
            builder.Services.AddScoped< EmotionDAO>();
            builder.Services.AddScoped< RequestFriendDAO>();
            builder.Services.AddScoped< CommentDAO>();
            builder.Services.AddScoped< UserService>();
            builder.Services.AddScoped< ProfileService>();
            builder.Services.AddScoped<CommentService>();
            builder.Services.AddScoped< PostService>();
            builder.Services.AddScoped<Validation>();
            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });
            // Khóa bí mật cho token
            var key = "dinhtiendat20122002chuvanandongkinhlangsonvietnam";

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });
            
            var app = builder.Build();
            
           // builder.Services.AddScoped<IEmotionService, EmotionService>();
           // builder.Services.AddScoped<IRequestFriendService, RequestFriendService>();
           // builder.Services.AddScoped<ICommentService, CommentService>();

           // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
                
            app.UseHttpsRedirection();
            
            
            app.UseCors("AllowSpecificOrigins");

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

           

            app.MapControllers();

            app.Run();
        }
    }

}
