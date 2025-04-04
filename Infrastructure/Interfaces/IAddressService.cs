using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IAddressService
{
    Task<Response<List<Address>>> GetAllAddressesAsync();
    Task<Response<Address>> GetAddressByIdAsync(int addressId);
    Task<Response<Address>> AddAddressAsync(Address address);
    Task<Response<Address>> UpdateAddressAsync(Address address);
    Task<Response<string>> DeleteAddressAsync(int addressId);
}