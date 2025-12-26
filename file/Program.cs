// See https://aka.ms/new-console-template for more information'
using System;
using System.IO;
string writeText = "kusal bhatta ";
File.WriteAllText("text.txt",writeText);

string readText = File.ReadAllText("text.txt");
Console.WriteLine(readText);
