var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Middleware to redirect www.xrm-360.com ? xrm-360.com
    app.Use(async (context, next) =>
    {
        var host = context.Request.Host.Host;

        if (host.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
        {
            var newHost = host.Substring(4); // remove "www."
            var newUrl = $"https://{newHost}{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";

            context.Response.Redirect(newUrl, permanent: true);
            return;
        }

        await next();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "localized",
        pattern: "{controller=Home}/{lang=en}/{action=Index}/{id?}");
});


app.Run();
