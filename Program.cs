using PatientManagementSystem.Repository;
using PatientManagementSystem.Service;

namespace PatientManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //1- Add connection string
            var connectionString = builder.Configuration.GetConnectionString("ConnectionStringMVC");
            builder.Services.AddSingleton(connectionString);

            //2- Register service and repository
            builder.Services.AddScoped<IPatientRepository, PatientRepositoryImplementation>();
            builder.Services.AddScoped<IPatientService, PatientServiceImplementation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
                pattern: "{controller=Patient}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
