using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Common.ValueObjects;

public class Price : BaseValueObject<Price>
{
    public long Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}