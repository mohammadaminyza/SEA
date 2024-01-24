using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.ValueObjects;

public class Address : BaseValueObject<Address>
{
    public string Street { get; private set; }
    public string Plaque { get; private set; }

    public Address(string street, string plaque)
    {
        // Logic Address

        Street = street;
        Plaque = plaque;
    }

    public static Address FromString(string address)
    {
        var (street, plaque) = (address.Split(",")[0], address.Split(",")[1]);
        return new Address(street, plaque);
    }

    public static int ToInt(Count count) => count.Value;


    public static implicit operator Address(string address) => FromString(address);
    public static implicit operator Address((string street, string plaque) address) => new Address(address.street, address.plaque);
    public static explicit operator (string, string)(Address address) => (address.Street, address.Plaque);


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Plaque;
    }
}