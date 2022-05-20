using Decanatus.BLL.Classes;
using Decanatus.BLL.Services;
using Decanatus.BLL.Services.Implementations;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Decanatus.DAL.Repositories.Realizations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, a => a.MigrationsAssembly("Decanatus.Web")));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddTransient<IAudienceRepository, AudienceRepository>();
    builder.Services.AddTransient<IFacultyRepository, FacultyRepository>();
    builder.Services.AddTransient<IGradeRepository, GradeRepository>();
    builder.Services.AddTransient<IGroupRepository, GroupRepository>();
    builder.Services.AddTransient<ILecturerRepository, LecturerRepository>();
    builder.Services.AddTransient<ILessonRepository, LessonRepository>();
    builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
    builder.Services.AddTransient<ISpecialityRepository, SpecialityRepository>();
    builder.Services.AddTransient<IStudentRepository, StudentRepository>();
    builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
    builder.Services.AddTransient<ILessonNumberRepository, LessonNumberRepository>();
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

    builder.Services.AddScoped<IScheduleService, ScheduleService>();
    builder.Services.AddScoped<IGradeService, GradeService>();
    builder.Services.AddScoped<IHomeService, HomeService>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddRoles<ApplicationRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

    builder.Services.AddMvc();

    builder.Services.AddControllersWithViews();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;
    });

    builder.Services.ConfigureApplicationCookie(options =>
    {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.SlidingExpiration = true;
    });

    var app = builder.Build();
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        await SeedRoleAndUser.Initialize(roleManager, userManager);
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();



    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

