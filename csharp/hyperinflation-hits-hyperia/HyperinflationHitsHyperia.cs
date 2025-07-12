public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier) { 
        try {
            long result = checked(@base * multiplier);
            return $"{result}";
        } 
        catch (OverflowException) {
            return "*** Too Big ***";
        } 
    }

    public static string DisplayGDP(float @base, float multiplier) =>
        (float.IsInfinity(@base * multiplier) || float.IsNaN(@base * multiplier))
        ? "*** Too Big ***"
        : $"{@base *multiplier}";

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try {
            decimal result = checked(salaryBase * multiplier);
            return $"{result}";
        } 
        catch (OverflowException) {
            return "*** Much Too Big ***";
        } 
    }
}
