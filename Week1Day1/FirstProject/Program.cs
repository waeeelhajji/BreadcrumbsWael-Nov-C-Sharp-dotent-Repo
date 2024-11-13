//! See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;

Console.WriteLine("Welcome To C# Stack");
//? JS Console.log()

//! What is a statically typed language ?
//! you have to specify the type of the variables or function
//? Data Types
// Javascript
// var name = "Wael";
//!C# 
string name = "Wael";
int number = 7;
double dec = 3.14;
float flaotvalue = 1.2f;
bool isTrue = true;

//! Lists and Dictionaries
//? Array and List
//? Array are fixed Length
string[] groceryList = new string[4];
//? [null,null,null,null]
string[] groceryList2 = {"Carrots","Turkey","Bread","Milk"};
//~------------------------0---------1-------2--------3----
//? in C# , Square brackets are used for indexing and accessing elements in an array

groceryList2[2] = "Ham";
//~ ["Carrots","Turkey","Ham","Milk"]
groceryList[2] = "Ham By Wael";
// ~[null,null,Ham,null]
Console.WriteLine(groceryList2[2]);

//?Size of an Array
Console.WriteLine(groceryList.Length);

//! Lists are variables length
List<int> numberList= new List<int>();
//~JS numberList.push(5)
numberList.Add(5);
numberList.Add(4);
numberList.Add(8);
numberList.Add(9);
numberList.Add(14);
numberList.Add(28);
//? Remove Value
//~JS numberList.pop()
numberList.Remove(4);
//? Remove ate the location of index 3
numberList.RemoveAt(3);
//? First parameter is the index, seconde is the value.
// numberList.Insert(1,74);
Console.WriteLine(numberList.Count);


//? Conditions

int temperature = 68;
if(temperature >= 72)
{
    // This executes if the temperature is greater than or equal to 72
    Console.WriteLine("It's a beautiful day to go outside!");
} else if(temperature > 64) {
    // This executes only if the temperature was NOT greater than or equal to 72 and IS above 64
    Console.WriteLine("I think it should be fine to go outside today with a light jacket.");    
} else {
    // If neither of the above conditions are met, we run the else statement
    Console.WriteLine("Maybe I'll stay inside today.");
}

//? Loops 

foreach(int i in numberList)
{
    Console.WriteLine(i);
}

//! String vs Char
//? string contains multiple letter
string words = "Hello";

//? Char contains 1 letter
char singlChar = 'q';