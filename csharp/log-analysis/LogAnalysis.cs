// Note about Method extension:
// The first parameter passed in the method isn't a normal argument.
// It’s just how you tell C# that you’re extending the string type. The actual "first"
// Argument, is after that, the second parameter.
//
// SubstringAfter(this string theStringThatsCallingThisMethod, string actualFirstArgumentString)
// "The String Thats Calling This Method".SubstringAfter(actualFirstArgumentString)
// 👌

public static class LogAnalysis 
{
    // TODO: define the hidden needed method extension
    public static string SubstringBefore(this string str, string del) {
        return str.Split(del)[0];
    } 
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string del) {
        return str.Split(del)[1];
    } 

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string left, string right) {
        return str.SubstringAfter(left).SubstringBefore(right);
    } 
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str) {
        return str.SubstringAfter(":").Trim();
    } 

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str) {
        return str.SubstringBefore(":").SubstringBetween("[", "]");
    } 
}
