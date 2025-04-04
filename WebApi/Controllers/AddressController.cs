using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AddressController(IAddressService service)
{
    [HttpGet]
    public async Task<Response<List<Address>>> GetAllAddressesAsync()
    {
        return await service.GetAllAddressesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Address>> GetAddressByIdAsync(int id)
    {
        return await service.GetAddressByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<Address>> AddAddressAsync(Address address)
    {
        return await service.AddAddressAsync(address);
    }

    [HttpPut]
    public async Task<Response<Address>> UpdateAddressAsync(Address address)
    {
        return await service.UpdateAddressAsync(address);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAddressAsync(int id)
    {
        return await service.DeleteAddressAsync(id);
    }
}