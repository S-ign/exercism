public static class PhoneNumber
{
    private const string newYork = "212";
    private const string fake = "555";

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] array = phoneNumber.Split("-");
        return (newYork == array[0], fake == array[1], array[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
