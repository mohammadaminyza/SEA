using Zamin.Core.Domain.ValueObjects;

namespace Arch.Core.Domain.Orders.ValueObjects;

public class Tax : BaseValueObject<Tax>
{
    public decimal TaxAmount { get; private set; }
    public decimal TaxRate { get; private set; }

    private Tax(decimal taxAmount, decimal taxRate)
    {
        ValidateTaxAmount(taxAmount);
        ValidateTaxRate(taxRate);

        TaxAmount = taxAmount;
        TaxRate = taxRate;
    }

    public static Tax Create(decimal taxAmount, decimal taxRate) => new Tax(taxAmount, taxRate);

    public static implicit operator Tax((decimal taxAmount, decimal taxRate) tax) => new Tax(tax.taxAmount, tax.taxRate);
    public static explicit operator (decimal, decimal)(Tax tax) => (tax.TaxAmount, tax.TaxRate);


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return TaxAmount;
        yield return TaxRate;
    }

    private void ValidateTaxAmount(decimal taxAmount)
    {
        if (taxAmount < 0)
            throw new ArgumentException("Tax amount cannot be negative.", nameof(taxAmount));
    }

    private void ValidateTaxRate(decimal taxRate)
    {
        if (taxRate < 0 || taxRate > 100)
            throw new ArgumentException("Tax rate must be between 0 and 100.", nameof(taxRate));
    }

    public string FormatForDisplay()
    {
        return $"{TaxAmount:C} at {TaxRate}%";
    }

    public Tax AdjustTaxAmount(decimal adjustment)
    {
        var adjustedAmount = TaxAmount + adjustment;
        return new Tax(adjustedAmount, TaxRate);
    }

    // Overrides for Equals, GetHashCode, and ToString
    public override bool Equals(object obj)
    {
        return obj is Tax tax && base.Equals(tax);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TaxAmount, TaxRate);
    }

    public override string ToString()
    {
        return FormatForDisplay();
    }

}