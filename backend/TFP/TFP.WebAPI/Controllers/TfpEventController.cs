using Microsoft.AspNetCore.Mvc;
using TFP.Core.Inrerfaces;
using TFP.Models.ViewModels;

namespace TFP.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TfpEventController : Controller
    {
        private readonly ITfpEventService tfpEventInterface;

        public TfpEventController(ITfpEventService tfpEventInterface)
        {
            this.tfpEventInterface = tfpEventInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var events = tfpEventInterface.GetEvents();

            return Ok(events);
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody]TfpEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            tfpEventInterface.CreateEvent(model);

            return Ok();

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
