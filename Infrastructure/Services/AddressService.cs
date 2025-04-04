using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService(DataContext context) : IAddressService
{
    public async Task<Response<List<Address>>> GetAllAddressesAsync()
    {
        var addresses = await context.Addresses.ToListAsync();
        return new Response<List<Address>>(addresses);
    }

    public async Task<Response<Address>> GetAddressByIdAsync(int addressId)
    {
        var address = await context.Addresses.FindAsync(addressId);
        
        return address == null 
            ? new Response<Address>(HttpStatusCode.BadRequest, "Address not found") 
            : new Response<Address>(address);
    }

    public async Task<Response<Address>> AddAddressAsync(Address address)
    {
        await context.Addresses.AddAsync(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Address>(HttpStatusCode.BadRequest, "Address not created") 
            : new Response<Address>(address);
    }

    public async Task<Response<Address>> UpdateAddressAsync(Address address)
    {
        context.Addresses.Update(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Address>(HttpStatusCode.BadRequest, "Address not updated") 
            : new Response<Address>(address);
    }

    public async Task<Response<string>> DeleteAddressAsync(int addressId)
    {
        var address = await context.Addresses.FindAsync(addressId);

        if (address == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Address not found");
        }

        context.Remove(address);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Address not deleted") 
            : new Response<string>("Address deleted successfully");
    }
}