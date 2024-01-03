using TP_SlackMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter un DBContext
builder.Services.AddDbContext<DbSlackContext>();

// Ajouter la configuration CORS pour autoriser les requêtes du front-end Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Ajouter des services pour les contrôleurs (sans vues)
builder.Services.AddControllers();

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    // Configurer la gestion des erreurs pour l'environnement de production
    app.UseExceptionHandler("/Error");  // Mettez à jour selon votre gestion des erreurs d'API
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Activer CORS
app.UseCors("AllowAngularApp");

app.UseAuthorization();

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/
app.MapControllers();

app.Run();
