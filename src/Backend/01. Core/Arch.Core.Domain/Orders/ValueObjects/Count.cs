using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.ValueObjects;

public class Count : BaseValueObject<Count>
{
    public int Value { get; private set; }

    private Count(int value)
    {
        if (value < 0)
            throw new InvalidValueObjectStateException("Count cloud not be less than zero");
        Value = value;
    }


    public static Count FromInt(int count) => new Count(count);
    public static int ToInt(Count count) => count.Value;


    public static implicit operator Count(int value) => FromInt(value);
    public static explicit operator int(Count count) => count.Value;

    public Count Increase() => new Count(Value + 1);
    public Count Decrease() => new Count(Value - 1);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}