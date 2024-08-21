using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;

namespace Bug.RazorPages.MVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                var libraryPath = Path.GetFullPath(
                    Path.Combine(builder.Environment.ContentRootPath, "..", "Bug.RazorPages.RazorClassLibrary"));

                options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
            });
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=RazorClassLibrary}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
