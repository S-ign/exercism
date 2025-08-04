public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public override int GetHashCode() => HashCode.Combine(amount, currency);
    public static bool operator !=(CurrencyAmount a, CurrencyAmount b) => !(a==b);

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public override bool Equals(object? obj) =>
        obj is not CurrencyAmount other
        ? false
        : amount == other.amount && currency == other.currency;

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount a, CurrencyAmount b) {
        if (a.currency != b.currency) throw new ArgumentException("Must be the same currency");
        return a.amount == b.amount && a.currency == b.currency;
    }

    // TODO: implement comparison operators
    public static bool operator <(CurrencyAmount a, CurrencyAmount b) {
        if (a.currency != b.currency) throw new ArgumentException("Must be the same currency");
        return a.amount < b.amount;
    }
    
    public static bool operator >(CurrencyAmount a, CurrencyAmount b) {
        if (a.currency != b.currency) throw new ArgumentException("Must be the same currency");
        return a.amount > b.amount;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b){
        if (a.currency != b.currency) throw new ArgumentException("Must be the same currency");
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b){
        if (a.currency != b.currency) throw new ArgumentException("Must be the same currency");
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount a) =>
        new CurrencyAmount(factor * a.amount, a.currency);

    public static CurrencyAmount operator *(CurrencyAmount a, decimal factor) =>
        new CurrencyAmount(a.amount * factor, a.currency);

    public static CurrencyAmount operator /(decimal divisor, CurrencyAmount a) {
        if (divisor == 0) throw new ArgumentException();
        return new CurrencyAmount(divisor / a.amount, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor) {
        if (divisor == 0) throw new ArgumentException();
        return new CurrencyAmount(a.amount / divisor, a.currency);
    }

    // TODO: implement type conversion operators
    public static implicit operator decimal(CurrencyAmount a) => a.amount;
    public static explicit operator double(CurrencyAmount a) => (double)a.amount;
}
