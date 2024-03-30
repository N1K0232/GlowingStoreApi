using System.Net.Mime;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace GlowingStoreApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
}