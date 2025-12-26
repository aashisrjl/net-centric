// // See https://aka.ms/new-console-template for more information
// //switch 
// int i=0;
// while(i<=10){
// Console.WriteLine("\n Enter your name:");
// string input = Console.ReadLine();
// switch (input)
// {
//     case "kushal":
//         Console.WriteLine("you are kusal.");
//         break;
//     case "kedar":
//         Console.WriteLine("You are a older than us.");
//         break;
//     case "rojan":
//         Console.WriteLine("You are father of dogs and fat.");
//         break;
//     default:
//         Console.WriteLine("You are a senior citizen.");
//         break;
// }
// i++;
// Console.WriteLine("Do you want to continue? (yes/no)");
// string continueInput = Console.ReadLine();
// if (continueInput.ToLower() = "no")
// {
//     break;

// }
// }


//LING-------------------------------------------
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbers = from number in numbers
                    where number % 2 == 0
                    select number;

//lamda
// var evenNumbers = numbers.Where(number => number % 2 == 0);

// Console.WriteLine(evenNumbers);

foreach (var number in evenNumbers){
    Console.WriteLine(number);
}

// for(int i=0;i<evenNumbers.;i++){
//         Console.WriteLine(evenNumbers[i]);
// }