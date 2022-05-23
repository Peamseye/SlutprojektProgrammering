using System;
using System.Collections.Generic;

//
int currency = 100;
//Startvaluta ($)

//
int amount = 0;
//Mängden produkter i affären (Startar på 0).

//
int price = 0;
//Värdet på produkterna spelaren har valt att köpa (Startar på 0).


//
List<string> names = new List<string>() {"Ben", "Peter", "Walter", "Harry"};
Random generator = new Random();
int n = generator.Next(names.Count);
string name = names[n];
//Slumpar vilken person som du får prata med.

//
string area = "start";
//GameState som bestämmer vart spelaren är.

//
bool game = true;
//Programmets loop. Fortsätter loopas tills spelaren köper ett pass, a.k.a när den blir satt till false.
while (game == true)
{

    //
    if (area == "start"){
        Console.WriteLine();
        Console.WriteLine();
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
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Please choose a destination.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("a = WORK (Gain $)     b = STORE (Spend $)");

        string answerMission = Console.ReadLine();
        answerMission = answerMission.ToLower();
        //Bestäm input från spelaren, allting förutom a eller b ignoreras, allt konverteras till lowercase.

        //
        if (answerMission == "a"){ Console.Clear(); area = "work"; }
        //Flytta spelaren till uppdragsmenyn

        //
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
        Console.WriteLine("a = WORK [LOCKED!]     b = STORE [BUY PASS!]"); 

        string answerMissionP = Console.ReadLine();
        answerMissionP = answerMissionP.ToLower();
        
            //
        if (answerMissionP == "a"){
            Console.Clear();
            Console.WriteLine("You can afford a pass!");
            Console.WriteLine("Now go to the store and get out of the city!");
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
        Console.WriteLine("-WORK-");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("You have a couple of people that want your services. They will pay you if you finish your job.");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Do you wish to accept a job now?");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("a = YES     b = NO"); 

        string answerWork = Console.ReadLine();
        answerWork = answerWork.ToLower();

        if (answerWork == "a"){
        //Leder spelaren till de olika utmaningarna.
            Console.Clear();

            Console.WriteLine("Mission accepted.");
            Console.WriteLine($"You will finish {name}'s mission. Go talk to him.");
            Console.ReadLine();
            
            area = "game";
        }

        if (answerWork == "b"){
        //Leder spelaren tillbaka till uppdragsmenyn.

            Console.WriteLine("Come back anytime you need some work!");
            Console.ReadLine();
            
            area = "missions";
        }
    }

    if (area == "game"){

        if (name == "Ben"){
        //Bens uppdrag
        
        Random rewB = new Random();
        int rewardB = rewB.Next(5, 50);

        currency = currency + rewardB;
        Console.WriteLine($"Your work from Ben rewarded you with {rewardB}$!");
        Console.ReadLine();
        area = "missions";
        }

        if (name == "Peter"){
        //Peters uppdrag
        
        Random rewP = new Random();
        int rewardP = rewP.Next(30, 60);

        currency = currency + rewardP;
        Console.WriteLine($"Your work from Peter rewarded you with {rewardP}$!");
        Console.ReadLine();
        area = "missions";
        }

        if (name == "Walter"){
        //Walters uppdrag
        
        Random rewW = new Random();
        int rewardW = rewW.Next(10, 20);

        currency = currency + rewardW;
        Console.WriteLine($"Your work from Walter rewarded you with {rewardW}$!");
        Console.ReadLine();
        area = "missions";
        }

        if (name == "Harry"){
        //Harrys uppdrag

        Random rewH = new Random();
        int rewardH = rewH.Next(20, 50);
                
        currency = currency + rewardH;    
        Console.WriteLine($"Your work from Harry rewarded you with {rewardH}$!");
        Console.ReadLine();
        area = "missions";
        }
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

        Console.WriteLine("-STORE-");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine($"You have {currency}$.");
        Console.WriteLine("");
        Console.WriteLine("What do you want to purchase?");
        Console.WriteLine("");
        Console.WriteLine("a = ROCK (5$)     b = BREAD (25$)     c = PASS (200$)");

        StoreOption = Console.ReadLine();
    }
    //
    if (StoreOption == "a"){price = 5; Console.WriteLine("Rocks don't do anything particular. (They are rocks after all)"); 
    Console.ReadLine();
    }

    if (StoreOption == "b"){ price = 25; Console.WriteLine("Gives you some food for the day, doesn't help you getting out however..."); 
    Console.ReadLine();
    }
    //Bestämmer värdet på varje produkt beroende på svaret av "StoreOption"

    //
    if (StoreOption == "c" && currency < 200){price = 200; Console.WriteLine("Allows you to get out of the city");
    Console.ReadLine();
    }
   
    if (StoreOption == "c" && currency >= 200){price = 200; Console.WriteLine("Allows you to get out of the city"); 
    area = "finalpurchase";
    }
    //Kollar om spelaren har råd för att köpa passet. Om ej, skickas de tillbaka till butiken. Om de kan, så skickas de automatiskt till slutet.

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
        Console.WriteLine("a = YES                 b = NO");

        answer = Console.ReadLine();
    }

    if (answer == "a")
    //Bestämmer om användaren vill återställa loopen och köpa fler produkter, eller om loopen ska avslutas och spelaren skickas tillbaka till uppdragsmenyn.
    {
        Console.Clear();
        game = true;
        //Spelaren återgår till butiken.
    }

    if (answer == "b")
    {
        Console.WriteLine("You leave the store.");
        Console.Clear();
        area = "missions";
        //Flyttar spelaren tillbaka till uppdragsmenyn
    }
}
    }

if (game == false)
//Avslutar loopen och stänger ner konsolen då spelaren har köpt passet.
{
    Console.ReadLine();
}