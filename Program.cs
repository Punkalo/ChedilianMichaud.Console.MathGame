using System;
using System.Timers;

System.Timers.Timer aTimer = new System.Timers.Timer(1);
string? input = "-1";
int difficulty = -1;
//int num1;
//int num2;
int score = 0;
float answer = -1210;
bool validInput = false;
int number = 1;
var rand = new Random();
double attempt;
int lives = 3;




    Console.WriteLine("Please select a difficulty.");
    Console.WriteLine($@"
    1. Easy   [Addition and subtraction, answers to the whole]
    2. Medium [Multiplication and division, answers rounded to the 2nd decimal]
    3. Hard   [Addition, multiplication, and division of 3 values.]

    
    ");
while (lives >= 0 || input == "end")
{
    while (!validInput)
    { 
        
        input = Console.ReadLine();

         
    // In this case "Number" acts as a difficulty value.
        if (int.TryParse(input, out number) && difficulty == -1)
        {
            if(number >= 1 && number <= 3)
            {
           Console.WriteLine("Generating game...");
           difficulty = number;
           //Sets valid input to true and sets difficulty
            switch (difficulty)
                {
                case 1: 
                Console.Clear();
                Console.WriteLine("Easy Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;

                case 2:
                Console.Clear();
                Console.WriteLine("Medium Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;

                case 3:

                Console.Clear();
                Console.WriteLine("Hard Mode\n");
                 validInput = true;
                playGame(difficulty);
                break;

                default:
                Console.WriteLine("Invalid difficulty");
                break;
                }

            }   
        }
    }
    
    input = Console.ReadLine();
    if (double.TryParse(input, out attempt))
    {
        if(answer == attempt)
        {   
            score ++;
            Console.WriteLine($"Current Score: {score}\n");
            
            playGame(difficulty);
        }
        else
        {  
             lives --;
            Console.WriteLine($"Sorry! The answer was: {answer}\n");
            Console.WriteLine($"Lives: {lives}");
            Console.WriteLine($"Current Score: {score}");
            if(lives >= 0)
           { playGame(difficulty);}
            
        }
    }
}

Console.Clear();
Console.WriteLine("Sorry, out of lives! \n Game Over!");

void playGame(int difficultySetting)
{
    switch (difficultySetting)
    {
        case 1:
        PerofmCalculationEasy();
        break;
        case 2:
        PerofmCalculationMedium();
        break;
        default:
        break;
        case 3:
        PerofmCalculationHard();
        break;
    }
}
 int PerofmCalculationEasy()
{   
    int x = rand.Next(2,5);
    int y = rand.Next(2, 5);

    answer =  x + y;

    Console.WriteLine($"What is... {x} + {y}..?");
    return (int)answer;
}



float PerofmCalculationMedium()
{
    float x = rand.Next(-10,10);
    float y = rand.Next(-10, 10);
    
    int MultOrDiv = rand.Next(0,1);

    if (MultOrDiv > 0)
    {
        answer = MathF.Round(x * y, 2);
        Console.WriteLine($"What is... {x} * {y}..?");
    }
    else
    {
        answer = MathF.Round(x / y, 2);
        Console.WriteLine($"What is... {x} / {y}..?");
    }

    

    return answer;
}


float PerofmCalculationHard()
{
    float x = rand.Next(-10,10);
    float y = rand.Next(-10, 10);
    float z = rand.Next(-10,10);
    
    int MultOrDivorAdd = rand.Next(1,3);

    Console.Write($"What is...{x} ");
    
        switch (MultOrDivorAdd)
        {
            case 1:
            Console.Write($"+ {y}");
            answer = x + y;
            break;
            case 2:
            Console.Write($"* {y}");
            answer = x * y;
            break;
            case 3:
            Console.Write($"/ {y}");
            answer = x / y;
            break;
        }
     
    MultOrDivorAdd = rand.Next(1,3);
     switch (MultOrDivorAdd)
        {
            case 1:
            Console.WriteLine($" + {z}?");
            answer = answer + z;
            break;
            case 2:
            Console.WriteLine($" * {z}?");
            answer = answer * z;
            break;
            case 3:
            Console.WriteLine($" / {z}?");
            answer = answer / z;
            break;
        }
        
    return answer;
}

