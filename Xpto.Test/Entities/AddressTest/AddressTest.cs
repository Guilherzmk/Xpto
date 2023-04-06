using Xpto.Core.Shared.Entities.Address;
using Xpto.Services.Customers;
using Xpto.Services.Entitites;

namespace Xpto.Test.Entities.AddressTest;

[TestClass]
public class AddressTest: Dependency
{
    private readonly IAddressRepository _addressRepository;

    [TestMethod]
    public void Delete()
    { 
        var result = addressService.Delete(35);
    }

    [TestMethod]

    public void Get()
    {
        var result = addressService.Get(82);
    }






}