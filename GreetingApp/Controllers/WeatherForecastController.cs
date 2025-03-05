using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace HelloGreetingApp.Controllers
{
    /// <summary>
    /// Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        /// <summary>
        /// Get method to get the greeting message
        /// </summary>
        /// <returns>"Hello world"</returns>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Hello to greeting App API endpoint";
            responseModel.Success = true;
            responseModel.Data = "Hello world";
            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request received successfully";
            responseModel.Data = $"Key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(responseModel);
        }

        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request updated successfully";
            responseModel.Data = $"Updated Key: {requestModel.key}, Updated Value: {requestModel.value}";
            return Ok(responseModel);
        }

        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request partially updated successfully";
            responseModel.Data = $"Patched Key: {requestModel.key}, Patched Value: {requestModel.value}";
            return Ok(responseModel);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string key)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request deleted successfully";
            responseModel.Data = $"Deleted Key: {key}";
            return Ok(responseModel);
        }
    }
}
