using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers;

[ApiController]
[Route("[controller]")]
public class LevenshteinDistanceController : ControllerBase
{
    private readonly ILogger<LevenshteinDistanceController> _logger;

    public LevenshteinDistanceController(ILogger<LevenshteinDistanceController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<int> Get()
    {
        return Ok(5);
    }

    [HttpPost]
    public ActionResult<int> Check(FileCompare fileCompare)
    {
        try
        {
            if (fileCompare == null)
            {
                return BadRequest("Body element is null, check your model for error");
            }

            if (string.IsNullOrEmpty(fileCompare.ContentFileOrigin))
            {
                return BadRequest("ContentFileOrigin is null or empty");
            }

            if (string.IsNullOrEmpty(fileCompare.ContentFileOther))
            {
                return BadRequest("ContentFileOther is null or empty");
            }
            int result = LevenshteinDistance.Compute(fileCompare.ContentFileOrigin, fileCompare.ContentFileOther);
            result = result >= 100 ? 0 : (100 - result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
            return BadRequest(ex);
        }
    }
}
