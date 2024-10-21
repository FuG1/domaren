using domaren.realestate.API.Auth;
using domaren.realestate.API.Mappings;
using domaren.realestate.API.Middleware;
using domaren.realstate.Domain.DI;
using domaren.realstate.Infrastructure.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => 
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddAutoMapper(x => x.AddProfile<RealestateMappingProfile>());
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => 
        opt.TokenValidationParameters = new TokenValidationParameters
        { 
            ValidateIssuer = true,
            ValidIssuer = RealestateAuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = RealestateAuthOptions.AUDIENCE,
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = true,
            IssuerSigningKey = RealestateAuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        });

builder.Services
    .AddBllModules()
    .AddDalModules(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<BusinessExceptionHandlerMiddleware>();
app.MapControllers();
app.Run();
