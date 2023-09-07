using Application.Features.Farmers.Commands.CreateFarmer;
using Application.Features.Farmers.Commands.UpdateFarmer;
using Application.Features.Farmers.Dtos;
using Application.Features.Farmers.Models;
using Application.Features.Farmers.Queries.GetFarmerList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class FarmerController : BaseController
    {
        [HttpPost("CreateFarmer")]
        public async Task<IActionResult> CreateFarmer(CreateFarmerCommand command)
        {
            CreatedFarmerDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("GetListOfProductsBasedOnCountry")]
        public async Task<IActionResult> GetListOfProductsBasedOnCountry(GetListFarmerQuery query)
        {
            FarmerListModel result = await Mediator.Send(query);
            return Ok(result);  
        }
        [HttpPost("UpdateFarmerInformation")]
        public async Task<IActionResult> UpdateFarmerInformation(UpdateFarmerCommand command)
        {
            UpdatedFarmerDto result = await Mediator.Send(command);
            return Ok(result);  
        }
        
    }
}
