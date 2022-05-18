namespace ThreeOrMoreGame;

/// <summary>
/// This class contains the abstraction of a dice and is is entirely designed to generate a random value between 1 and 6
/// for the user so that the dice rolling process can be realistic. 
/// </summary>
internal class Dice
{
    // number of dice faces has been set 
    // This will enable access to the other die properties from other classes
    private int DiceSides = 6;
    public int DieSide
    {
        get { return DiceSides; }
    }
    // generates a random number between 1 and the set number of dice faces and return its 
    public int rollDie()
    {
        Random rnd = new Random();
        int number  = rnd.Next(1, DieSide);
        return number;
    }
}