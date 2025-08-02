public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();
    public static bool HandleErrorWithOutParam(string input, out int result) => int.TryParse(input, out result);
    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject) => disposableObject.Dispose();

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int? n = null;
        return n;
    }
}
