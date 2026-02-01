using Microsoft.OpenApi;

namespace DevIO.Api.Configurations;

public static class SwaggerConfiguration
{
    //Swashbuckle.AspNetCore
    //Swashbuckle.AspNetCore.Swagger

    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            // Informações da API
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api Tres Camadas",
                Version = "v1",
                Description = """
                Api de exemplo da arquitetura tres camadas.

                • Autenticação via JWT  
                """,
                Contact = new OpenApiContact
                {
                    Name = "Equipe",
                    Email = "contato@equipe.com.br"
                }
            });

            // Configuração de autenticação JWT
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Informe o token JWT no formato: Bearer {seu_token}",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            // Define Bearer scheme
            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer", // lowercase per RFC 7235
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme."
            });

            // Organiza controllers por nome
            options.TagActionsBy(api =>
            {
                if (api.GroupName != null)
                    return new[] { api.GroupName };

                if (api.ActionDescriptor.RouteValues.TryGetValue("controller", out var controller))
                    return new[] { controller };

                return new[] { "Outros" };
            });

            options.DocInclusionPredicate((_, _) => true);
        });
    }

    public static void UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            options.DocumentTitle = "Api Tres Camadas Doc";
            options.RoutePrefix = "swagger";
            options.DisplayRequestDuration();
        });
    }
}