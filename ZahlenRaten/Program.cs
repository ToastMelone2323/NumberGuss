using System;
class Program
{
    static void Main(string[] args)
    {
        bool nochmal = true;

        while (nochmal)
        {
            Console.Clear();
            SpielRunden();

            ZeigeLinie();
            Console.WriteLine(" |Willst du nochmal spielen? (j/n)                         |");
            ZeigeLinie();
            string weiter = Console.ReadLine();
            nochmal = weiter == "j";
        }

        Console.WriteLine(" |Danke fürs Spielen!                                      |");
        ZeigeLinie();
    }

    static void SpielRunden()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        bool erraten = false;
        int versuche = 0;
        string schwierigkeit;
        int maxVersuche = 0;
        string input;

        Console.WriteLine("        /-------------------------------------------\\");
        Console.WriteLine("       /      --------------------------------       \\");
        Console.WriteLine("      /       | Willkommen beim Zahlenraten! |        \\");
        Console.WriteLine("     /        --------------------------------         \\");
        Console.WriteLine("    /---------------------------------------------------\\");
        Console.WriteLine("   /Ich habe mir eine Zahl zwischen 1 und 100 ausgedacht.\\");
        Console.WriteLine("  /              Kannst du sie erraten?                   \\");
        ZeigeLinie();
        Console.WriteLine(" |Gib die Schwierigkeit ein (1-3):                         |");
        Console.WriteLine(" |1 = Leicht (10 Versuche)                                 |");
        Console.WriteLine(" |2 = Mittel (5 Versuche)                                  |");
        Console.WriteLine(" |3 = Schwer (3 Versuche)                                  |");
        ZeigeLinie();
        while (maxVersuche == 0)
        {
            schwierigkeit = Console.ReadLine();

            if (schwierigkeit == "1") maxVersuche = 10;
            else if (schwierigkeit == "2") maxVersuche = 5;
            else if (schwierigkeit == "3") maxVersuche = 3;
            else
            {
                ZeigeLinie();
                Console.WriteLine(" |Ungültige Eingabe!                                       |");
                Console.WriteLine(" |Bitte erneut eingeben:                                   |");
                ZeigeLinie();
                Console.WriteLine(" |1 = Leicht (10 Versuche)                                 |");
                Console.WriteLine(" |2 = Mittel (5 Versuche)                                  |");
                Console.WriteLine(" |3 = Schwer (3 Versuche)                                  |");
                ZeigeLinie();
            }

        }

        ZeigeLinie();
        Console.WriteLine($" |Du hast {maxVersuche} Versuche!                                     |");

        while (erraten == false && versuche < maxVersuche)
        {

            Console.WriteLine(" |Gib deine Zahl ein:                                      |");
            ZeigeLinie();
            input = Console.ReadLine();
            bool isNum = int.TryParse(input, out int number);

            if (isNum == true)
            {
                versuche++;

                if (number < randomNumber)
                {
                    ZeigeLinie();
                    Console.WriteLine(" |Die Zahl ist zu klein!                                   |");
                    Console.WriteLine(" |" + (maxVersuche - versuche) + " Versuche übrig!                                        |");
                    ZeigeLinie();

                }
                else if (number > randomNumber)
                {
                    ZeigeLinie();
                    Console.WriteLine(" |Die Zahl ist zu groß!                                    |");
                    Console.WriteLine(" |" + (maxVersuche - versuche) + " Versuche übrig!                                        |");
                    ZeigeLinie();
                }
                else
                {
                    ZeigeLinie();
                    Console.WriteLine(" |Du hast die Zahl erraten!                                |");
                    Console.WriteLine(" |Du hast " + versuche + " Versuche gebraucht!             |");
                    ZeigeLinie();
                    erraten = true;
                }
            }
            else
            {
                Console.WriteLine(" |Das war keine Zahl                                           |");
            }
        }
        if (!erraten)
        {
            ZeigeLinie();
            Console.WriteLine(" |Du hast leider keine Versuche mehr übrig!                |");
            Console.WriteLine(" |Die Zahl war: " + randomNumber + "                                         |");
            ZeigeLinie();
        }


    }
    static void ZeigeLinie()
    {
        Console.WriteLine(" |" + new string('-', 57) + "|");
    }

    static void ZeigeZeile(string text)
    {
        Console.WriteLine(" |" + text.PadRight(57) + "|");
    }
}

