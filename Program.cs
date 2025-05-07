using System.Text.Json.Serialization;
using backTOT;
using backTOT.Data;
using backTOT.Interface;
using backTOT.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ILessonsService, LessonsService>();
builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentsService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<ICourseTeachersService, CourseTeachersService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<ILesson_notes, Lesson_NotesService>();
// Thêm Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// C?u hình DbContext v?i SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// tránh trùng lặp
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName); // Phân biệt dựa theo namespace
});


// CORS Policy
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
