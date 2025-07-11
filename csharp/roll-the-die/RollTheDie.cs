public class Player
{
    public int RollDie()
    {
        Random random = new Random();
        //will gernate a number between 1-18 :o
        return random.Next(1,19);
    }

    public double GenerateSpellStrength()
    {
        Random random = new Random();
        //will generate number between 0-99
        int rinty = random.Next(0, 100);
        //will generate float between 0.0 and 1.0
        float rfloaty = random.NextSingle();

        //combine the two :)
        return rinty+rfloaty;
    }
}
