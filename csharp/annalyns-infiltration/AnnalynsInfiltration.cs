static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        if (archerIsAwake) {
            return false;
        } 
        return prisonerIsAwake;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        //if both gaurds are up theres no chance
        if (archerIsAwake && knightIsAwake) {
            return false;
        }
        //if only the archer is awake theres no chance
        if (archerIsAwake) {
            return false;
        } 
        //prisoner needs the dog to get passed the knight
        if (knightIsAwake && petDogIsPresent == false) {
            return false;
        } 
        return prisonerIsAwake || petDogIsPresent;
    }
}
