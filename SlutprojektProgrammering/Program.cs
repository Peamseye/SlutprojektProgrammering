﻿using System;
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

    //Bestämmer värdet på varje frukt beroende på svaret av "fruit"
    if (StoreOption == "a"){price = 50;}

    if (StoreOption == "b"){ price = 110;}

    if (StoreOption == "c"){price = 400;}



    Console.WriteLine("How many do you want to purchase?");

    string input = Console.ReadLine();



//Bestämmer mängden frukter som ska köpas av användaren. 
    bool success = int.TryParse(input, out amount);

    //Startar en loop så länge användaren inte skriver in en siffra
    while (success != true)
    {
        Console.Clear();
        Console.WriteLine("How many do you want to purchase?");
        input = Console.ReadLine();


        success = int.TryParse(input, out amount);
    }



    //Kollar om användaren har tillräckligt stor summa att köpa en mängd frukt. Om den inte har råd, startas loopen om. Om den har råd, subtraheras värdet från totala summan pengar.
    if (currency < amount * price)
    {
        Console.WriteLine("Sorry, you cannot afford to buy this.");
        amount = 0;
    }
    else
    {
        currency = currency - amount * price;
    }


    //Kollar om användaren har några pengar kvar. Om den har pengar, säger programmet till användaren mängden frukt, samt den totala summan som återstår.
    if (currency < 0)
    {
        Console.WriteLine("Sorry, you cannot afford to buy any more products.");
    }
    else
    {
        Console.WriteLine($"- Purchased {amount} items");
        Console.WriteLine($"You have {currency}$ left");


        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Do you want to purchase more?");
        Console.WriteLine("");
        Console.WriteLine("a = yes                 b = no");
    }

    string answer = Console.ReadLine();
    answer = answer.ToLower();

    //Startar en loop som fortsätter så länge användaren inte skriver in a eller b. Loopen fortsätter så länge programmets loop är aktiv, och stannar om användaren väljer att avsluta programmet.
    while (answer != "a" && answer != "b" && game == true)
    {

        Console.Clear();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Do you want to purchase more?");
        Console.WriteLine("");
        Console.WriteLine("a = yes                 b = no");

        answer = Console.ReadLine();
    }

    //Bestämmer om användaren vill återställa loopen och köpa fler frukter, eller om loopen ska avslutas och programmet ska stängas.
    if (answer == "a")
    {
        Console.Clear();
        game = true;
    }

    if (answer == "b")
    {
        Console.WriteLine("You leave the store.");
        Console.WriteLine("Press [ENTER] To Exit.");
        game = false;
    }

}

//Avslutar loopen och stänger ner konsolen.
if (game == false)
{
    Console.ReadLine();
}