namespace ThreeOrMoreGame;

/// <summary>
/// This is the player class which provides all the different characteristics of a player, this includes things such as
/// player name, ID and score. It is also responsible for storing the updated score 
/// </summary>
internal class Users
{
    
    // fields/variables 
    private int UserID;
    public int Userid
    {
        // The get method returns the value of the variable playerID.
        get { return UserID; } 
        //The set method assigns a value to the playerID variable.
        set { UserID = value; }
    }
    
    // fields/variables 
    private string UserName;
    public string username
    {
        // The get method returns the value of the variable playername.
        get { return UserName; } 
        //The set method assigns a value to the playername variable.
        set { UserName = value; }
    }
    
    // fields/variables 
    private int UserPoints;
    public int userpoints
    {
        // The get method returns the value of the variable playerscore.
        get { return UserPoints; }
        //The set method assigns a value to the playerscore variable.
        set { UserPoints = value; }
    }

    // This method holds the name, id and score of the registered players and they can be used throughout the programming
    
    public Users(int id, string name, int score)
    {
        UserID = id;
        UserName = name;
        UserPoints = score;
    }
    // responsible for containing the user points every round 
    public void PointUpdates(int score)
    {
        userpoints+= score;
    }
}