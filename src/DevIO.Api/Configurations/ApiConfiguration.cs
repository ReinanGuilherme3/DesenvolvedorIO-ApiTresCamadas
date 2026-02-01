namespace DevIO.Api.Configurations;

public static class ApiConfiguration
{
    public static void AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.MapOpenApi();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
