using System.Text;
using System.Text.Json.Serialization;
using backTOT;
using backTOT.Data;
using backTOT.Interface;
using backTOT.Middleware;
using backTOT.Services;
using backTOT.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Rate Limiter
builder.Services.AddRateLimiter(RateLimiterConfig.Configure);
// Add Controllers & JSON Options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// - 2. AutoMapper -
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// - 3. DbContext -
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IPermissionCache, PermissionCache>();

// - 4. CORS -
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// - 5. Services -
// Scoped services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ILessonsService, LessonsService>();
builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentsService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<ICourseTeachersService, CourseTeachersService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<ILesson_notes, Lesson_NotesService>();
builder.Services.AddScoped<ISectionsService, SectionsService>();
builder.Services.AddScoped<ICatalogsService, CatalogsService>();
builder.Services.AddScoped<ITopicsService, TopicsService>();
builder.Services.AddScoped<IVocabularysService, VocabularysService>();
builder.Services.AddScoped<IUserTopicsService, UserTopicsService>();
builder.Services.AddScoped<IUserVocabularysService, UserVocabularysService>();
builder.Services.AddScoped<IUsersLessonService, UsersLessonService>();
builder.Services.AddScoped<IScheduleServices, ScheduleService>();
builder.Services.AddScoped<LeverService>();


builder.Services.AddSingleton<IAuthorizationPolicyProvider, DynamicPermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();

builder.Services.AddAuthorization(options =>
{
    // Policy public cho anonymous
    options.AddPolicy("AllowAnonymousView", policy =>
    {
        policy.RequireAssertion(_ => true);
    });
});



// - 6. Authentication JWT -
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RoleClaimType = "role",
            NameClaimType = "name",
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
        {
            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    status = 403,
                    message = "Bạn không có quyền truy cập tài nguyên này"
                });
                return context.Response.WriteAsync(result);
            },
            OnChallenge = context =>
            {
                context.HandleResponse(); // Ngăn middleware tự động trả lỗi mặc định
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    status = 401,
                    message = "Token không hợp lệ hoặc đã hết hạn"
                });
                return context.Response.WriteAsync(result);
            }
        };
    });

// - 8. Swagger -
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token theo dạng: Bearer {your JWT token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

// - 9. Logging -
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// - 10. Build app -
var app = builder.Build();
app.UseRateLimiter();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();
// Middleware Audit Log
app.UseMiddleware<AuditLogMiddleware>();
app.MapControllers();

app.Run();
