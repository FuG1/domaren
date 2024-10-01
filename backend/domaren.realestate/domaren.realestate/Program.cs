using domaren.realestate.API.Auth;
using domaren.realestate.API.Mappings;
using domaren.realstate.Domain.DI;
using domaren.realstate.Infrastructure.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(x => x.AddProfile<RealestateMappingProfile>());
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => 
        opt.TokenValidationParameters = new TokenValidationParameters
        { 
            ValidateIssuer = true,
            ValidIssuer = RealestateAuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = RealestateAuthOptions.AUDIENCE,

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
app.MapControllers();
app.Run();
