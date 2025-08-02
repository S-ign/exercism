public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static bool HandleErrorWithOutParam(string input, out int result) => int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject) {
        try {
            throw new Exception("we broke it");
        }
        catch (Exception) {
            disposableObject.Dispose();
            throw;
        }
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int num;
        return int.TryParse(input,out num)
            ? num
            : null;
    }
}
