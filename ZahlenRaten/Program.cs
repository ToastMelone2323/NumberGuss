using System;
class Program
{
    const int BoxBreite = 57;
    static void Main(string[] args)
    {
        bool nochmal = true;


        while (nochmal)
        {
            Console.Clear();
            SpieleRunde();

            ZeigeZeile("Willst du nochmal spielen? (j/n)");
            ZeigeLinie();
            string weiter = Console.ReadLine();
            nochmal = weiter == "j";
        }

        ZeigeZeile("Danke fürs Spielen!");
        ZeigeLinie();
    }

    static void SpieleRunde()
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
        ZeigeZeile("Gib die Schwierigkeit ein (1-3):");
        ZeigeAuswahl();

        while (maxVersuche == 0)
        {
            schwierigkeit = Console.ReadLine();

            if (schwierigkeit == "1") maxVersuche = 10;
            else if (schwierigkeit == "2") maxVersuche = 5;
            else if (schwierigkeit == "3") maxVersuche = 3;
            else
            {
                ZeigeLinie();
                ZeigeZeile("Ungültige Eingabe!");
                ZeigeZeile("Bitte erneut eingeben:");
                ZeigeAuswahl();
            }

        }

        ZeigeLinie();
        ZeigeZeile($"Du hast {maxVersuche} Versuche!");
        ZeigeLinie();

        while (!erraten && versuche < maxVersuche)
        {

            ZeigeZeile("Gib deine Zahl ein:");
            ZeigeLinie();
            input = Console.ReadLine();
            bool isNum = int.TryParse(input, out int number);

            if (isNum)
            {
                versuche++;

                if (number < randomNumber)
                {
                    ZeigeLinie();
                    ZeigeZeile("Die Zahl ist zu klein!");
                    ZeigeZeile($"{maxVersuche - versuche} Versuche übrig!");
                    ZeigeLinie();

                }
                else if (number > randomNumber)
                {
                    ZeigeLinie();
                    ZeigeZeile("Die Zahl ist zu groß!");
                    ZeigeZeile($"{maxVersuche - versuche} Versuche übrig!");
                    ZeigeLinie();
                }
                else
                {
                    ZeigeLinie();
                    ZeigeZeile("Du hast die Zahl erraten!");
                    ZeigeZeile($"Du hast {versuche} Versuche gebraucht!");
                    ZeigeLinie();
                    erraten = true;
                }
            }
            else
            {
                ZeigeZeile("Das war keine Zahl");
                ZeigeLinie();
            }
        }
        if (!erraten)
        {
            ZeigeLinie();
            ZeigeZeile("Du hast leider keine Versuche mehr übrig!");
            ZeigeZeile($"Die Zahl war: {randomNumber}");
            ZeigeLinie();
        }


    }

    static void ZeigeAuswahl()
    {
        ZeigeZeile("1 = Leicht (10 Versuche)");
        ZeigeZeile("2 = Mittel (5 Versuche)");
        ZeigeZeile("3 = Schwer (3 Versuche)");
        ZeigeLinie();
    }
    static void ZeigeLinie()
    {
        Console.WriteLine(" |" + new string('-', BoxBreite) + "|");
    }

    static void ZeigeZeile(string text)
    {
        Console.WriteLine(" |" + text.PadRight(BoxBreite) + "|");
    }
}

