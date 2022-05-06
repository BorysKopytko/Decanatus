using Decanatus.BLL.Services;
using Decanatus.BLL.Services.Implementations;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Data;
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

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

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

