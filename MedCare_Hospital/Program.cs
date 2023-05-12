using MedCare_Hospital.Data;
using MedCare_Hospital.DataStructure;
using MedCare_Hospital.Services;
using MedCare_Hospital.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyHospital.Services.IServices;
using MyHospital.Services;
using MyHospital_MVC.Services.IServices;
using MyHospital_MVC.Services;
using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital.DataAccess.Repositories;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.DataAccess.Repositories;
using MyHospital.DataAccess.Repositories.MyHospital_MVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

//Repository configurations
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHealthcareProviderRepository, HealthcareProviderRepository>();
builder.Services.AddScoped<IPatientHealthcareProviderRepository, PatientHealthcareProviderRepository>();

//Service configurations
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthcareProviderService, HealthcareProviderService>();
builder.Services.AddScoped<IPatientHealthcareProviderService, PatientHealthcareProviderService>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.Run();
