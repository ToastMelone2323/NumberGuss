using System;
using System.Reflection.Metadata.Ecma335;
class Program
{
    const int BoxBreite = 57;
    static void Main(string[] args)
    {
        bool nochmal = true;
        int siege = 0;
        int loss = 0;
        int bestLeistung = 0;



        while (nochmal)
        {
            Console.Clear();
            int ergebnis = SpieleRunde();

            if (ergebnis > 0)
            {
                siege++;
                if (bestLeistung == 0 || ergebnis < bestLeistung)
                {
                    bestLeistung = ergebnis;
                }
            }
            else
            {
                loss++;
            }
            ZeigeStatistik(siege, loss, bestLeistung);
            ZeigeZeile("Willst du nochmal spielen? (j/n)");
            ZeigeLinie();
            string weiter = Console.ReadLine();
            nochmal = weiter == "j";
        }
        ZeigeZeile("Danke fürs Spielen!");
        ZeigeLinie();
        ZeigeStatistik(siege, loss, bestLeistung);
    }

    static int SpieleRunde()
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
                string outcome = Pruefen(number, randomNumber);

                if (outcome == "kleiner")
                {
                    ZeigeLinie();
                    ZeigeZeile("Die Zahl ist zu klein!");
                    ZeigeZeile($"{maxVersuche - versuche} Versuche übrig!");
                    ZeigeLinie();

                }
                else if (outcome == "groesser")
                {
                    ZeigeLinie();
                    ZeigeZeile("Die Zahl ist zu groß!");
                    ZeigeZeile($"{maxVersuche - versuche} Versuche übrig!");
                    ZeigeLinie();
                }

                string huk = HeisKalt(number, randomNumber);
                if (huk == "sehr")
                {
                    ZeigeZeile("Du bist sehr nah dran");
                    ZeigeLinie();
                }
                else if (huk == "nah")
                {
                    ZeigeZeile("Du bist nah dran");
                    ZeigeLinie();
                }

                if (outcome == "gleich")
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
            return 0;
        }
        else
        {
            return versuche;
        }


    }

    static string Pruefen(int number, int randomNumber)
    {
        if (number == randomNumber)
        {
            return "gleich";
        }
        else if (number < randomNumber)
        {
            return "kleiner";
        }
        else
        {
            return "groesser";
        }
    }

    static void ZeigeAuswahl()
    {
        ZeigeZeile("1 = Leicht (10 Versuche)");
        ZeigeZeile("2 = Mittel (5 Versuche)");
        ZeigeZeile("3 = Schwer (3 Versuche)");
        ZeigeLinie();
    }

    static string HeisKalt(int number, int randomNumber)
    {
        int diff = Math.Abs(number - randomNumber);
        if (diff < 6 && number != randomNumber)
        {
            return "sehr";
        }
        else if (diff < 11 && number != randomNumber)
        {
            return "nah";
        }
        else return "";
    }

    static void ZeigeStatistik(int siege, int loss, int bestLeistung)
    {
        ZeigeZeile($"Deine gesamten Siege waren: {siege}");
        ZeigeZeile($"Deine gesamten Niederlagen waren: {loss}");
        if (bestLeistung > 0) ZeigeZeile($"Bestleistung: {bestLeistung} Versuche");
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

