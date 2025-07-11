class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() {
        return 40;
    } 

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int r) {
        return ExpectedMinutesInOven()-r; 
    } 

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int p) {
        return p*2;
    } 

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int a, int b) {
        return PreparationTimeInMinutes(a)+b;
    } 
}
