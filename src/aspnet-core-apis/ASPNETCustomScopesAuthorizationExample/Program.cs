using ASPNETCustomScopesAuthorizationExample.CognitoHelpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// add authorization policy
builder.Services.AddAuthorization(options => {
    options.AddPolicy("ReadPhotos", policy => policy.Requirements.Add(new CognitoScopeAuthorizationRequirement(new[] { "com.example.photos/basic", "com.example.photos/read" })));
    options.AddPolicy("WritePhotos", policy => policy.Requirements.Add(new CognitoScopeAuthorizationRequirement(new[] { "com.example.photos/basic", "com.example.photos/write" })));
});

// read configurations
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
            AudienceValidator = (audiences, securityToken, validationParameters) => {
                var castedToken = securityToken as JwtSecurityToken;
                var clientId = castedToken?.Payload["client_id"]?.ToString();
                return validAudience.Equals(clientId);
            },
            RoleClaimType = "cognito:groups"
        };
    });

// add a singleton of our cognito authorization handler
builder.Services.AddSingleton<IAuthorizationHandler, CognitoScopeAuthorizationHandler>();

var app = builder.Build();

app.UsePathBase("/aspnet/custom-scopes-authorization-example");
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthentication(); // responsible for constructing AuthenticationTicket objects representing the user's identity
app.UseAuthorization();

app.MapControllers();

app.Run();
