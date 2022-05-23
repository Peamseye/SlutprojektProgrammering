using System;
using System.Collections.Generic;

//-Typkonvertering (Klar)
//-Array / Lista (Klar)
//-Random generator (Klar)

//-While loopar (starta om spelet / vinna spelet när passet är köpt).
//-If-satser
//-Metod
//-Flera loopar (Spelet i sig + utmaning)
//-Algoritm
//-Gamestate

//
int currency = 200;
//Startvaluta ($)

//
int amount = 0;
//Mängden produkter i affären (Startar på 0).

//
int price = 0;
//Värdet på produkterna spelaren har valt att köpa (Startar på 0).


//
List<string> names = new List<string>() {"Ben", "Peter", "Walter", "Harry", "Joey"};
Random generator = new Random();
int name = generator.Next(names.Count);
//Slumpar vilken person som du får prata med.

string area = "start";
//GameState som bestämmer vart spelaren är.

//
bool game = true;
//Programmets loop. Fortsätter loopas tills spelaren köper ett pass, a.k.a när den blir satt till false.
while (game == true)
{

    //
    if (area == "start"){
        Console.WriteLine("You need to buy a pass to exit the city.");
        Console.WriteLine("However, you do not have enough money right now.");
        Console.WriteLine($"You only have {currency} dollars, so you need to work for more.");

        Console.WriteLine();
        Console.WriteLine("Luckily, you know some people who could pay you for some work.");

        Console.ReadLine();
        Console.Clear();

        area = "missions";
    }
    //Startrummet, ger en enkel introduktion till spelarens mål; att köpa ett pass för att lämna staden.

    //
    if (area == "missions" && currency < 400){
        //
        Console.WriteLine("Please choose a destination.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("a = Work (Gain $)     b = Store (Spend $)");

        string answerMission = Console.ReadLine();
        answerMission = answerMission.ToLower();
        //Bestäm input från spelaren, allting förutom a eller b ignoreras, allt konverteras till lowercase.

        if (answerMission == "a"){ Console.Clear(); area = "work"; }
        //Flytta spelaren till uppdragsmenyn

        if (answerMission == "b"){ Console.Clear(); area = "store"; }
        //Flytta spelaren till butiken
    }
    //Menyn som bestämmer spelarens val till antingen ett uppdrag eller till affären. 

    if (area == "missions" && currency >= 400){
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("You can now afford a pass!");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Please choose a destination.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("a = Work [LOCKED!]     b = Store [BUY PASS!]"); 

        string answerMissionP = Console.ReadLine();
        answerMissionP = answerMissionP.ToLower();
        
            //
        if (answerMissionP == "a"){
            Console.Clear();
            Console.WriteLine("You can afford a pass!");
            Console.WriteLine("Now go to the store and get out!");
            Console.ReadLine();

            area = "store";
            //Ge spelaren direktiv, och skicka dem senare till butiken
        }

        if (answerMissionP == "b"){ area = "store"; }
        //Förflytta spelaren till butiken
    }
    //Speciellt till när spelaren har samlat upp 400$, då spelet säger till spelaren att gå till butiken och köpa passet för att vinna.

    if (area == "work"){
    //Gamestate till uppdragsmenyn. Här slumpas spelaren en dialog och ett uppdrag, som belönas med pengar om man lyckas.
        Console.WriteLine();
    }
    

    if (area == "store"){
    //Gamestate till butiken. Här kan spelaren köpa tre olika varor som kan ge boosts till spelaren för att göra uppdragen snabbare, eller låta spelaren köpa passet för att vinna.
        
        //
        string StoreOption = Console.ReadLine();
        StoreOption = StoreOption.ToLower();
        //StoreOption = Första svaret på frågan

    while (StoreOption != "a" && StoreOption != "b" && StoreOption != "c")
    //Tvingar användaren att välja mellan a, b eller c.
    {
        Console.Clear();

        Console.WriteLine("Welcome to my store!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"You have {currency}$.");
        Console.WriteLine("");
        Console.WriteLine("What do you want to purchase?");
        Console.WriteLine("");
        Console.WriteLine("a = Rock (10$)     b = Bread (50$)     c = Pass (400$)");

        StoreOption = Console.ReadLine();
    }
    //
    if (StoreOption == "a"){price = 10; Console.WriteLine("(Rocks don't do anything particular, they are rocks after all."); 
    Console.ReadLine();
    }

    if (StoreOption == "b"){ price = 50; Console.WriteLine("Increases the money you gain from missions"); 
    Console.ReadLine();
    }
    //Bestämmer värdet på varje produkt beroende på svaret av "StoreOption"

    //
    if (StoreOption == "c" && currency < 400){Console.WriteLine("Allows you to get out of the city");
    Console.WriteLine("Sorry, but you cannot afford this. Please come back with more funds if you want to purchase it.");
    Console.WriteLine("You leave the store.");
    area = "missions";
    }
   
    if (StoreOption == "c" && currency >= 400){price = 400; Console.WriteLine("Allows you to get out of the city"); 
    area = "finalpurchase";
    }
    //Kollar om spelaren har råd för att köpa passet. Om ej, skickas de tillbaka till uppdragsmenyn. Om de kan, så skickas de automatiskt till slutet.

    Console.WriteLine("How many do you want to purchase?");

    //
    string input = Console.ReadLine();

    bool success = int.TryParse(input, out amount);
    //Bestämmer mängden frukter som ska köpas av användaren. 

    while (success != true)
    //Startar en typkonverterande loop så länge användaren inte skriver in en siffra.
    {
        Console.Clear();
        Console.WriteLine("How many do you want to purchase?");
        input = Console.ReadLine();


        success = int.TryParse(input, out amount);
    }



    if (currency < amount * price)
    //Kollar om användaren har tillräckligt stor summa att köpa produkterna. Om den inte har råd, startas loopen om. Om den har råd, subtraheras värdet från totala summan pengar.
    {
        Console.WriteLine("Sorry, you cannot afford to buy this.");
        amount = 0;
        //Sker om spelaren inte har tillräckligt med pengar. Återställer mängden produkter till 0.
    }
    else
    {
        currency = currency - amount * price;
        //Subtraherar priset av alla produkter från spelarens totala summa.
    }


    if (currency < 0)
    //Kollar om användaren har några pengar kvar. Om den har pengar, säger programmet till användaren mängden produkter, samt den totala summan som återstår.
    {
        Console.WriteLine("Sorry, you cannot afford to buy any more products.");
        area = "missions";
        //Spelaren har slut på pengar, och skickas tillbaka till uppdragsmenyn.
    }
    else
    {
        Console.WriteLine($"- Purchased {amount} items");
        Console.WriteLine($"You have {currency}$ left");
        //Visar spelaren hur mycket pengar de har kvar.


        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Do you want to purchase more?");
        Console.WriteLine("");
        Console.WriteLine("a = yes                 b = no");
    }
    if (area == "finalpurchase"){
        //Gamestate till när spelaren har valt att köpa passet. Avslutar spelet efter dialogen är passerad.

        Console.Clear();

        Console.WriteLine("Purchased the pass!");
        Console.WriteLine();
        Console.WriteLine("You leave the store immediately and rush out to the border.");
        Console.WriteLine("You show the pass to the ticket booth, and they let you leave.");
        
        game = false;
    }

    string answer = Console.ReadLine();
    answer = answer.ToLower();

    while (answer != "a" && answer != "b" && game == true)
    //Startar en loop som fortsätter så länge användaren inte skriver in a eller b. Loopen fortsätter så länge programmets loop är aktiv, och stannar om användaren väljer att avsluta programmet.
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

    if (answer == "a")
    //Bestämmer om användaren vill återställa loopen och köpa fler produkter, eller om loopen ska avslutas och spelaren skickas tillbaka till uppdragsmenyn.
    {
        Console.Clear();
        game = true;
    }

    if (answer == "b")
    {
        Console.WriteLine("You leave the store.");
        Console.WriteLine("Press [ENTER] To Exit.");
        Console.Clear();
        area = "missions";
    }
}
    }

if (game == false)
//Avslutar loopen och stänger ner konsolen då spelaren har köpt passet.
{
    Console.ReadLine();
}