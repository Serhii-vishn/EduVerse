var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppConfig>(configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ITokenRepository, TokenRepository>();

builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddTransient<IGradeRepository, GradeRepository>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IParentRepository, ParentRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<IStudentService, StudentService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EduVerseConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("EduVerse")
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 7;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"] ?? throw new Exception("JWT Key is not configured")))
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

CreateDbIfNotExists(app);

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while creating the DB.");
        }
    }
}