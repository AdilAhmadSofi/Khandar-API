using Khandar.Application.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Utils;

public sealed class ExtendedProblemDetails : ProblemDetails
{
    public List<APIError> Errors { get; set; } = new List<APIError>();
}
