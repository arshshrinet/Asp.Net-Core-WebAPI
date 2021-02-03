using Devices.Model;
using Devices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Devices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
            private readonly DeviceService _deviceService;

            public DeviceController(DeviceService deviceService)
            {
                _deviceService = deviceService;
            }

            [HttpGet]
            public ActionResult<List<ElectricalDevices>> Get() 
            {
                try 
                {
                  return Ok( _deviceService.Get()); 
                }
                catch(Exception ex)
                {
                    return StatusCode(500, "Internal Server Error");
                }
                 
            }

            [HttpGet("{id:length(24)}", Name = "GetDevices")]
        //public Task<HttpResponseMessage> Get(string id)
            public ActionResult<ElectricalDevices> Get(string id)
            {
                var devices = _deviceService.Get(id);

                if (devices == null)
                {
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
                 return NotFound();
                }
                //return Request.CreateResponse(HttpStatusCode.ok, devices);
                 return devices;
            }

            [HttpPost]
            public ActionResult<ElectricalDevices> Create(ElectricalDevices devices)
            {
                _deviceService.Create(devices);
                return CreatedAtRoute("GetDevices", new { id = devices.Id.ToString() }, devices);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, ElectricalDevices devicesIn)
            {
                var devices = _deviceService.Get(id);

                if (devices == null)
                {
                    return NotFound();
                }

                _deviceService.Update(id, devicesIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var devices = _deviceService.Get(id);

                if (devices == null)
                {
                    return NotFound();
                }

                _deviceService.Remove(devices.Id);

                return NoContent();
            }
        
    }
}
