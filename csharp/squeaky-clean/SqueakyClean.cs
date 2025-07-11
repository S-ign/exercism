public static class Identifier
{
    // à-ḃç
    // yes, i had to paste this here and go through the loop in my head one at a time to figure
    // out why it wasn't working 😅
    public static string KebabToCamel(string s) {
        string c = "";
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '-') {
                c += char.ToUpper(s[i+1]);
                //we have to incrament i an additional time here because we've
                //altered a index ahead of where we currently are :o
                i++;
            } else {
                c += s[i];
            }
        } 
        return c;
    } 

    // α - ω
    public static bool IsGreekLetter(char c) => (c >= '\u03B1' && c <= '\u03C9');

    public static string RemoveNonLetters(string s) {
        //subscribe today :D
        string onlyChars = "";
        for (int i = 0; i < s.Length; i++) {
            //is this readable??? 😓
            if ((char.IsLetter(s[i]) || s[i] == '_') && !IsGreekLetter(s[i])) {
               onlyChars += s[i];
            } 
        } 
        return onlyChars;
    } 

    public static string Clean(string identifier)
    {
        string clean = identifier.Replace(" ", "_");
        clean = clean.Replace("\0", "CTRL");
        clean = KebabToCamel(clean);
        clean = RemoveNonLetters(clean);
        return clean;
    }
}
