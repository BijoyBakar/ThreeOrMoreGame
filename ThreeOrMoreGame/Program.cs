// See https://aka.ms/new-console-template for more information

using ThreeOrMoreGame;
// this class is responsible to displaying the main menu to the user, the users are then able to select their options.
// All the other methods and classes are called here.

// the while loop keeps the menu on loop so that it is displayed to the user at the end of the game.
// it also enables them to play again or exit out of the game 
while (true)
{
    
    string logo =
        @" 
▀▀█▀▀ █──█ █▀▀█ █▀▀ █▀▀ 　 ░█▀▀▀█ █▀▀█ 　 ░█▀▄▀█ █▀▀█ █▀▀█ █▀▀ 
─░█── █▀▀█ █▄▄▀ █▀▀ █▀▀ 　 ░█──░█ █▄▄▀ 　 ░█░█░█ █──█ █▄▄▀ █▀▀ 
─░█── ▀──▀ ▀─▀▀ ▀▀▀ ▀▀▀ 　 ░█▄▄▄█ ▀─▀▀ 　 ░█──░█ ▀▀▀▀ ▀─▀▀ ▀▀▀  
🄵🄸🅁🅂🅃 🅃🄾 50 🅆🄸🄽🅂";
    Console.WriteLine(logo);
    // menu options are displayed
    string optionmenu = @"
╭――――――――――――――――――――――╮                
│ 1) Play Game         │
│ 2) Game Rules        │
│ 3) Exit              │
╰――――――――――――――――――――――╯
";
    Console.Write(optionmenu);
    
    int option = Convert.ToInt32(Console.ReadLine());
    // if option 1 is picked then the user is sent to the play game part of the game 
    if (option == 1)
    {
        List<Users> playerList = Game.PlayerList();
        // the while make sures the game ends when the user reaches 50 points or more 
        int score = 0;
        while (score<=50)
        {
            // For the number of players in the list, the users will be told to press enter to roll their dice 
            // the total score for the user will also be shown at the end of every round 
            foreach (var player in playerList)
            {
                Console.WriteLine("Please press enter for " + player.username);
                Console.Read();
                Game.Scoreing(Game.Roll_Dice(),0,player);
                Console.WriteLine(player.username + " has " + player.userpoints+" total points ");
                // the winning point is incremented depending on the users score that round. 
                int winningpoint = player.userpoints;
                score = winningpoint;
                // if the user reaches 50 then a message is presented to the players to let them know who the winner is 
                if (winningpoint >= 50)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("The Winner is "+player.username);
                    Console.WriteLine(" ");
                    Console.WriteLine("Leaderboard");
                    // a leaderboard with all the players and the score is presented 
                    foreach (var VARIABLE in playerList)
                    {
            
                        Console.WriteLine(VARIABLE.Userid + " | " + VARIABLE.username + " | " + VARIABLE.userpoints);
                        Console.WriteLine("------------------------------");

                    }
                    break;

                }
                Console.WriteLine(" ");
            }
            
        }

        
    }
    // if the user picks option 2 then the are given the game rules and how the scoring works. This allows new users to learn about the game.
    if (option==2)
    { 
        string rules = @"
╭―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――╮ 
│ DIRECTION FOR PLAY                                                                            │
│ Players take turns rolling five dice and score for three-of-a-kind or better. If a player only│
│ has two-of-a-kind, they may re-throw the remaining dice in an attempt to improve the remaining│
│ dice values. If no matching numbers are rolled after two rolls, the player scores 0.          │     
╰―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――╯                                                                                   
╭――――――――――――――――――――――――――――――――╮             
│ SCORING                        │                                                              
│ • 3-of-a-kind: 3 points        │
│ • 4-of-a-kind: 6 points        │
│ • 5-of-a-kind: 12 points       │ 
│ • First to 50 points wins      │                                                                
╰――――――――――――――――――――――――――――――――╯
";
        Console.WriteLine(rules);
    }
    // if the user picks 3 then the game will finish and they will need to re run the program to play again. 
    else if (option == 3)
    {
        System.Environment.Exit(0);
    }

}


