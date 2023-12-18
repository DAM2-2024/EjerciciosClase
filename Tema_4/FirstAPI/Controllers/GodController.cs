using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GodController : ControllerBase
{
    private readonly ILogger<GodController> _logger;
    private readonly IData<God> _data;

    public GodController(ILogger<GodController> logger, IData<God> dataService)
    {
        _logger = logger;
        _data=dataService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<God>> Get()
    {   
        return Ok( _data.GetALL());
    }

    [HttpGet("{id}")]
    public ActionResult<God> Get(int id)
    {
        God data= _data.GetById(id);

        if (data!=null)
            return Ok(data);

        return NotFound();
    }

    [HttpPost]
    public ActionResult<God> Post(God godAdd)
    {
        if (godAdd==null)
            return BadRequest("God is null");

        return _data.Add(godAdd);;
    }

    [HttpPut("{id}")]
    public ActionResult<God> Put(int id,[FromBody] God godModify)
    {
        if (godModify==null)
            return BadRequest("God is null");

        if (id!=godModify.Id)
            return BadRequest("Gods ids are not matching");

        return _data.Put(godModify);;
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (_data.Remove(id))
        {
            return Ok();
        }
        return NotFound();
    }
}
