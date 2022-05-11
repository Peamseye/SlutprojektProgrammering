using System;
using System.Numerics;

//-Typkonvertering
//-While loopar (starta om spelet / vinna spelet när passet är köpt).
//-If-satser
//-Array / Lista
//-Random generator
//-Metod
//-Flera loopar (Spelet i sig + utmaning)
//-Algoritm


int currency = 200;
//Startvaluta

int amount = 0;
//Mängden produkter i affären

int price = 0;
//Värdet på produkterna spelaren har valt att köpa

bool game = true;

//Programmets loop. Fortsätter loopas tills spelaren köper ett pass.
while (game == true)
{

//Fruit = Första svaret på frågan
    string StoreOption = Console.ReadLine();
    StoreOption = StoreOption.ToLower();

    //Tvingar användaren att välja mellan a, b eller c.
    while (StoreOption != "a" && StoreOption != "b" && StoreOption != "c")
    {
        Console.Clear();

        Console.WriteLine($"You have {currency}$.");
        Console.WriteLine("");
        Console.WriteLine("What do you want to purchase?");
        Console.WriteLine("");
        Console.WriteLine("a = Steroids (50$)     b = Gloves (100$)     c = Pass (400$)");

        StoreOption = Console.ReadLine();
    }


}

Console.WriteLine();