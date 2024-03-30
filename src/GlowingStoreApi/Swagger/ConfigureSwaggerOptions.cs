using Asp.Versioning.ApiExplorer;
using GlowingStoreApi.BusinessLayer.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GlowingStoreApi.Swagger;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;
    private readonly AppSettings appSettings;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider,
        IOptions<AppSettings> appSettingsOptions)
    {
        this.provider = provider;
        appSettings = appSettingsOptions.Value;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = appSettings.ApplicationName,
            Version = description.ApiVersion.ToString(),
            Description = appSettings.ApplicationDescription
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}