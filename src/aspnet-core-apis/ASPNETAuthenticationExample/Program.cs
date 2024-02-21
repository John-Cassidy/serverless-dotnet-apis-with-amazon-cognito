using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// read configurations
//string[] allowedDomains = builder.Configuration["AppSettings:AllowedOrigions"].Split(",");
string cognitoAppClientId = builder.Configuration["AppSettings:Cognito:AppClientId"].ToString();
string cognitoUserPoolId = builder.Configuration["AppSettings:Cognito:UserPoolId"].ToString();
string cognitoAWSRegion = builder.Configuration["AppSettings:Cognito:AWSRegion"].ToString();

string validIssuer = $"https://cognito-idp.{cognitoAWSRegion}.amazonaws.com/{cognitoUserPoolId}";
string validAudience = cognitoAppClientId;

builder.Services.AddControllers();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

// Configure CORS
builder.Services.AddCors(item => {
    item.AddPolicy("CORSPolicy", builder => {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Register authentication schemes, and specify the default authentication scheme
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
        options.Authority = validIssuer;
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateLifetime = true,
            ValidAudience = validAudience,
            ValidateAudience = true,
        };
    });


var app = builder.Build();

app.UsePathBase("/aspnet/authentication-example");
app.UseRouting();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthentication(); // responsible for constructing AuthenticationTicket objects representing the user's identity
app.UseAuthorization();

app.MapControllers();

app.Run();
