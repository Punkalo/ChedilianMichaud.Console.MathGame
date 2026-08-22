using System;

string? input = "-1";
int difficulty = -1;
int score = 0;
int answer = -1210;
bool validInput = false;
int number = 1;
var rand = new Random();
int attempt = -1;
int lives = 3;
int questions = 0;
int questionAsked = 0;
List<QuestionRecord> questionsList = new List<QuestionRecord>();


MainMenu();

while (input != "end")
{
    while (!validInput)
    { 
        
        input = Console.ReadLine();

         
    // In this case "Number" acts as a difficulty value.
        if (int.TryParse(input, out number) && difficulty == -1)
        {
            if(number >= 1 && number <= 5)
            {
           Console.WriteLine("Please repeat your selection to confirm.");
           //If a valid input has been entered, the game will start and the player will be prompted.
            GameStart();
            }

            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 5.");
                Console.ReadLine();
                Console.Clear();
                MainMenu();
                GameStart();
            }   
        }
    }
    
    input = Console.ReadLine();
    if (int.TryParse(input, out attempt))
    {   questionAsked++;
        questions++;
        if(answer == attempt)
        {   
            score ++;
            Console.WriteLine($"Current Score: {score}\n");
            
            playGame(difficulty);
        }
        //Only if the initial 5 questons is completed, the player will lose a life if the answer is wrong.
        //If the answer is wrong, the player loses a life and the correct answer is displayed.

        else if( answer != attempt && questionAsked > 5 && lives >= 0)
        {  
             lives --;
            Console.WriteLine($"Sorry! The answer was: {answer}\n");
            Console.WriteLine($"Lives: {lives}");
            Console.WriteLine($"Current Score: {score}\n");
            if(lives >= 0)
           { playGame(difficulty);}
            
        }
        else if(answer != attempt && questionAsked <= 5)
        {
            Console.WriteLine($"Sorry! The answer was: {answer}\n");
            Console.WriteLine($"Current Score: {score}");
            playGame(difficulty);

        }

        
    }
    if(questionAsked < 5)
    {
        Console.WriteLine($"Question: {questionAsked}/5");
    }
    else if(questionAsked >= 5)
    {   
        Console.WriteLine($"-Survival Mode- {lives} Lives Remaining");
    }
    else if(input == "end")
    {
        Console.WriteLine($"Game Ended! \nFinal Score: {score}");
        break;
    }
//If the player runs out of lives, the game will end and display a game over message.

    if(lives < 0)
    {
       Console.Clear();
    Console.WriteLine("Sorry, out of lives! \n Game Over!");
    Console.ReadLine();
    MainMenu();
    GameStart();
    }
    




}









void playGame(int MathMode)
{
    switch (MathMode)
    {
        case 1:
        
        Console.WriteLine($"Question: {questionAsked}");
            PerofmCalculationAdd();
            break;
        case 2:
        Console.WriteLine($"Question: {questionAsked}");
        PerofmCalculationSubtract();
            break;
        case 3:
        Console.WriteLine($"Question: {questionAsked}");
            PerofmCalculationMulti();
            break;
        case 4:
        Console.WriteLine($"Question: {questionAsked}");
            PerofmCalculationDivide();
            break;
        default:
            Console.WriteLine("Invalid difficulty");
            break;
    }
    


}

// Function to record the game data into a list of QuestionRecord objects.
void RecordGame(string Question, int QuestionNumber, int Answer, int UserAnswer)
    {
        var Record = new QuestionRecord(Question, QuestionNumber, Answer, UserAnswer);
        questionsList.Add(Record);
    }


//Funtions for each of the math operations.
 int PerofmCalculationAdd()
{   
    int x = rand.Next(1, 100);
    int y = rand.Next(1, 100);
    Console.WriteLine($"What is {x} + {y}?");
    answer = x + y;
    RecordGame($"What is {x} + {y}?", questions, answer, attempt);
    return (int)answer;
    
}
 int PerofmCalculationSubtract()
{  
    int x = rand.Next(1, 100);
    int y = rand.Next(1, 100);
    Console.WriteLine($"What is {x} - {y}?");
    answer = x - y;
    RecordGame($"What is {x} - {y}?", questions, answer, attempt);
    return (int)answer; 
}
int PerofmCalculationMulti()
{
    int x = rand.Next(1, 100);
    int y = rand.Next(1, 100);
    Console.WriteLine($"What is {x} * {y}?");
    answer = x * y;
    RecordGame($"What is {x} * {y}?", questions, answer, attempt);
    return (int)answer;
}
int PerofmCalculationDivide()
{
    int x = rand.Next(1, 100);
    int y = rand.Next(1, 10);
    
    answer = x / y;
    if (x%y != 0)
    {
      PerofmCalculationDivide();
    }
    else
    {
        
        Console.WriteLine($"What is {x} / {y}?");
    }

    

    RecordGame($"What is {x} / {y}?", questions, answer, attempt);
    return (int)answer;
}


// Function to print the game records after the player has completed the game.
void PrintGameRecords()
{
    Console.WriteLine("Game Records:");
    if (questionsList.Count == 0)
    {
        Console.WriteLine("No game records found.");
        Console.ReadLine();
        MainMenu();
        GameStart();
        
    }
    else
    {
        Console.WriteLine($"Total Questions Answered: {questionsList.Count}");
        Console.WriteLine($"Final Score: {score}\n");
        
        foreach (var record in questionsList)
    {
        Console.WriteLine($"Question {record.QuestionNumber}: {record.Question +1} \n| Correct Answer: {record.Answer} \n| User Answer: {record.UserAnswer}\n");
    }

    Console.ReadLine();
    MainMenu();
    GameStart();
    }

    
}


// Funtion to restart the game after the player has lost all their lives.
void GameStart()
{
    input = Console.ReadLine();
    if(int.TryParse(input, out difficulty))
    {

     switch (difficulty)
                {
                case 1: 
                Console.Clear();
                Console.WriteLine("Add Mode\n");
                validInput = true;
                playGame(difficulty);
                break;

                case 2:
                Console.Clear();
                Console.WriteLine("Subtract Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;

                case 3:

                Console.Clear();
                Console.WriteLine("Multiply Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;

                case 4:
                Console.Clear();
                Console.WriteLine("Divide Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;
                case 5:
                Console.Clear();
                PrintGameRecords();
                break;

                default:
                Console.WriteLine("Invalid difficulty");
                Console.WriteLine(difficulty);
                break;
                }

}
else
{
    Console.WriteLine("Invalid input, please enter a number between 1 and 5.");
    Console.ReadLine();
    MainMenu();
    GameStart();
    Console.Clear();
}

}
void MainMenu()
{ 
    Console.WriteLine("Main Menu");
    Console.WriteLine($@"
    1. Add
    2. Subtract
    3. Multiply
    4. Divide
    5. Game Records
    End. End Game


    ");
    lives = 3;
    score = 0;
    attempt = -1;
    validInput = false;
    difficulty = -1;
    questionAsked = 0;
}
public class QuestionRecord
{
    public string Question { get; set; }
    public int QuestionNumber { get; set; }
    public int Answer { get; set; }
    public int UserAnswer { get; set; }

    public QuestionRecord(string question, int questionNumber, int answer, int userAnswer)
    {
        Question = question;
        QuestionNumber = questionNumber;
        Answer = answer;
        UserAnswer = userAnswer;
    }
}
