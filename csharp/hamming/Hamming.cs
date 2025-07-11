public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) {
            throw new ArgumentException();
        } 

        int distance = 0;
        for (int n = 0; n < firstStrand.Length; n++) {
            if (firstStrand[n] != secondStrand[n]) {
                distance++;
            } 
        } 
        return distance;
    }
}
