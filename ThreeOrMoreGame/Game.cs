namespace ThreeOrMoreGame;


    
    internal class Game
    {
        
        
        
        /// <summary>
        /// this method is responsible for returning a list of integers that are displayed once the user rolls the dice
        /// </summary>
        /// <returns>Dice_results</returns>
        public static List<int> Roll_Dice()
        {
            // list containing all the new values for the dices that have been rolled by the user 
            List<int> Dice_results = new List<int>();
            // creating multiple dice objects from the class dice and assigning different integers 
            Dice Dice_1 = new Dice();
            Dice Dice_2 = new Dice();
            Dice Dice_3 = new Dice();
            Dice Dice_4 = new Dice();
            Dice Dice_5 = new Dice();
            
            List<Dice> ListOfDice = new List<Dice>(5) 
            {   Dice_1, 
                Dice_2, 
                Dice_3, 
                Dice_4, 
                Dice_5   };
            // counts the number of dice rolled. It is displayed after every dice to let the user know which dice rolled which value
            int counter = 0;
            // The 5 dice are rolled and are printed out in order the results are then added to the lists and printed out.
            foreach (var roll in ListOfDice)
            {
                counter++;
                int Dicesides = roll.rollDie();
                Dice_results.Add(Dicesides);
                Console.WriteLine("Dice "+counter+": "+ Dicesides);
            }
            return Dice_results;
        }
        
        
        
        ///method is responsible for containing the number of players the user has inputted. 
        public static List<Users> PlayerList()
        {
            // this stores the number of players
            int NumPlayers = 0;
            // contains the player details 
            List<Users> ListPlayers = new List<Users>();

            while (true)
            {
                // user is told to enter the number of players
                Console.WriteLine("Please enter the number of players");
                NumPlayers = Convert.ToInt32(Console.ReadLine());
                break;
            }

            // for loops iterates through the number of players and asks them their username 
            for (int x = 0; x < NumPlayers; x++)
            {
                // the player ID is incremented by every player. a number greater than the last player is assigned to the new player
                int playerID = x + 1;
                // users are told to enter their name depending on their player number they are 
                Console.Write("Please enter the name of player " + playerID + ": ");
                string playerName = Console.ReadLine();
                // The adds the player ID, player name and the starting score of 0
                ListPlayers.Add(new Users(playerID, playerName, 0));
            }
            
            // a starting leader board is displayed with all the player id, name and starting score
            foreach (var VARIABLE in ListPlayers)
            {
            
                Console.WriteLine(VARIABLE.Userid + " | " + VARIABLE.username + " | " + VARIABLE.userpoints);
                Console.WriteLine("------------------------------");

            }
            
            return ListPlayers;
        }
        
        
        
        /// <summary>
        /// this method is used for re-rolling the dice when the user gets 2 of a kind, this mainly uses the same functionality
        /// the normal rolling dice method uses 
        /// </summary>
        /// <param name="repeatedTwice"></param>
        /// <returns>Re_roll_results</returns>
        private static List<int> Reroll(int Value_repeated)
        {
            // counts the number of dice rolled. It is displayed after every dice to let the user know which dice rolled which value
            int counter = 0;
            // list containing all the new values for the dices that have been rolled by the user 
            List<int> Re_roll_results = new List<int>();
            // creating multiple dice objects from the class dice and assigning different integers 
            Dice Dice_1 = new Dice();
            Dice Dice_2 = new Dice();
            Dice Dice_3 = new Dice();
            Dice Dice_4 = new Dice();
            Dice Dice_5 = new Dice();

            List<Dice> diceList = new List<Dice>(5)
            {
                Dice_1, 
                Dice_2, 
                Dice_3, 
                Dice_4, 
                Dice_5
            };
            int dicecount = diceList.Count;
            // The 5 dice are re-rolled again and are printed out in order the results are then added to the lists and printed out.
            for (int x = 0; x < dicecount; x++)
            {
                if (x == 0 || x == 1)
                {
                    // the repeated numbers are also stored in dice 1 and 2, however, this is not printed out 
                    // to make it easier for the user to understand the re rolling of 3 dice 
                    // This means that if the same number which is in dice 1 and 2 appears within dice 3,4 and 5 the scores will 
                    // be incremented 
                    int dieface = Value_repeated;
                    Re_roll_results.Add(dieface);
                }
                else
                {
                    // the numbers that are re rolled are stored and printed out 
                    int dieface = diceList[x].rollDie();
                    Re_roll_results.Add(dieface);
                    Console.WriteLine("Dice: " + (counter + 1) + " " + dieface + " ");
                    counter++;
                }
            }
            return Re_roll_results;
        }
        
        
        
        
        /// <summary>
        /// This method is responsible for checking how many of the same numbers more than once. It then assigns the new score
        /// depending on how many of the same number the user has rolled. Update score is then used to update the score.
        /// </summary>
        /// <param name="dieValues"></param>
        /// <param name="counter"></param>
        /// <param name="users"></param>
        /// <returns>score</returns>

        public static int Scoreing(List<int> DiceVal, int counter, Users users)
        {
            int score = 0;
            // a dictionary is created which takes a key data type and a value data type and the number of items it can hold is 6
            Dictionary<int,int> Dice_roll = new Dictionary<int,int>(6)
            {{1,0}, {2,0}, {3,0}, {4,0}, {5,0}, {6,0}};
            
            
            // it is then incremented by 1 
            foreach (int x in DiceVal)
            {
                Dice_roll[x]++;
            }
            
            
            // returns the maximum values 
            int MaxOccur = Dice_roll.Values.Max();
            // if the max value is 5 then the score is incremented by 12 
            if (MaxOccur == 5)
            {
                score = 12;
                users.PointUpdates(12);
                Console.WriteLine("You got "+score+" points this round");
            }
            // if the max value is 4 then the score is incremented by 6 
            else if (MaxOccur == 4)
            {
                score = 6;
                users.PointUpdates(6);
                Console.WriteLine("You got "+score+" points this round");
            }
            // if the max value is 3 then the score is incremented by 3 
            else if (MaxOccur == 3)
            {
                score = 3;
                users.PointUpdates(3);
                Console.WriteLine("You got "+score+" points this round");
                
            }
            // if the max value is 1 then the score is incremented by 0 
            else if (MaxOccur ==1)
            {
                score = 0;
                users.PointUpdates(0);
                Console.WriteLine("You got "+score+" points this round");

            }
            // if the max value is 2 then the number which appears 2 times is identified
            else if (MaxOccur == 2)
            {
                // prevents it from re-rolling multiple times. only lets the re-rolling happen once
                if (counter < 1)
                {
                    // attains the key of the value with maximum 
                    int ValueRepeated = 0;
                    // iterates through 
                    foreach (var x in Dice_roll)
                    {
                        //Gets the value in the key/value pair
                        if (x.Value == 2)
                        {
                            // it is then stored in the repeated value 
                            ValueRepeated = x.Key;
                        }

                    }
                    // the repeated value is then displayed and the user is told to re roll.
                    Console.WriteLine(ValueRepeated + " is rolled 2 times.");
                    Console.WriteLine("Please press enter to re-roll the remaining dice");
                    Console.Read();
                    counter++;
                    // the dices are then re rolled except the number which appears 2 times.This value is kept the same
                    // and then the dice values go through the get score method again to attain the new score for the user
                    List<int> NewValues = Reroll(ValueRepeated);
                    Scoreing(NewValues,counter,users);


                }
            }


            return score;
        }
        
    }
  