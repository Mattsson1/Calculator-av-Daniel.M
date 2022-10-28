namespace Calculator
{
    /* Analysering av miniräknare, hur jag skulle kunnat utveckla den mer.
     * 
     * Om jag hade velat utöka min kod ännu mer hade jag tillexempel kunnat använda "split string" metoden
     * så att spelaren kan mata in hel ekvation på en rad istället för
     * att behöva trycka enter vid varje inmatning.
     * 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Meny = true;
            bool end = false;//Sätter min bool till false, ska använda detta sen i while loopen
            string message = "Välkommen till miniräknaren! Välj ett av följande alternativ!";
            foreach (char rubrik in message)// Kör en foreach-loop för att få ut varje bokstav i meddelandet. 
            {
                Thread.Sleep(10);//Thread.Sleep metoden på varje bokstav. 10 milisekunder
                Console.Write(rubrik);//Skriver en bokstav på 10 milliesekund
            }


            List<string> sparadetal = new List<string>();//Skapar en samlingsklass "List" där jag ska spara användarens tal



            while (end == false)//Medans while är false körs loopen
            {

                if (Meny == true)//Skapar en If-Sats till menyn så att spelaren kan komma tillbaka ifall boolen "Meny" är True.
                {
                    Console.WriteLine("");
                    Console.WriteLine("1. Starta miniräknare");//Användar menyn
                    Console.WriteLine("2. Kolla uträkningar");
                    Console.WriteLine("3. Avsluta miniräknaren");
                }

                double num1 = 0;//Inmatning till spelarens första tal
                double num2 = 0;//Inmatning till spelarens andra tal
                string MathOperator;
                int val;// Här gör jag en hel-tals variabel som jag ska använda i switch-casen för att läsa in spelarens val. 

                Console.WriteLine("");

                {
                    try// Skapar en Try-Catch som ska fånga upp alla fel inmatningar. 
                    {

                        Meny = false;//Sätter "Meny" till false så att inte menyn kommer upp hela tiden
                        val = Convert.ToInt32(Console.ReadLine());// Läser in vad väljaren valde
                        Console.Clear();//Console.Clear för att rensa Menyn så att det inte blir allt för stökigt

                        switch (val)//En Switch-Case sats, Val variabeln som läser in inmatningen som användaren väljer
                        {
                            case 1:
                                Console.WriteLine("Skriv ett tal");
                                num1 = Convert.ToDouble(Console.ReadLine());//Läser in spelarens inmatning samt konverterar det till en int
                                Console.WriteLine("Ange en matematisk operator ( +, - ,* ,/ )");

                                MathOperator = Console.ReadLine();//Läser in den matematiska operatorn

                                addition();//Kör additions metoden

                                subtraktion();//Kör subratktions metoden

                                division();//Kör divisions metoden

                                multiplikation();//Kör multiplikations metoden

                                Console.WriteLine("Vill du återgå till menyn? J/N");//Efter att någon av metoderna har körts så frågar
                                //jag om spelaren vill återgå till menyn.
                                string svar = Console.ReadLine().ToLower();//Läser in spelarens val, Använder även metoden "ToLower" Så att det som spelaren skriver
                                //görs om till små bokstäver
                                if (svar == "j")//Om spelaren skriver "j" 
                                {
                                    Meny = true;//Gör meny till true så att menyn kan visas igen
                                }
                                else if (svar == "n")//Om spelaren skriver "n"
                                {
                                    Console.Clear();//Rensa consolen
                                    goto case 1;//Goto case 1 som hoppar till case 1
                                }
                                continue;//"continue" hoppar till början av while-loopen


                            case 2://Case 2 till att få fram historiken
                                int tal = 1;//Skapar en heltals variabel till att hålla reda på vilken ekvation det är
                                Console.Clear();

                                foreach (string num in sparadetal)//Skapar en Foreach loop för att få ur alla uträkningar i listan
                                {
                                    Console.WriteLine($"Ekvation {tal}: {num}");
                                    tal++;//Tal++ för att vi ska få fram ekvation 2, ekvation 3, osv..

                                }
                                Meny = true;//Meny true för att få fram menyn igen
                                continue;

                            case 3:
                                Console.WriteLine("Progammet avslutas...");
                                end = true;//Sätter end till true så vílket gör att while loopen inte kan köras
                                break;//Break som gör att vi hoppar ut ur switch-casen, och eftersom vi gjorde end till
                                //true, kan inte while-loopen köras



                        }
                    }
                    catch (Exception ex)//Med "Exception" fångar vi upp all oväntad kod
                    {

                        Console.ForegroundColor = ConsoleColor.Red;//Jag vill ha fel meddelandet rött
                        Console.WriteLine(ex.Message);//Väljer även att printa ut Exceptionet
                        Console.WriteLine("Ogiltig inmatning!");//Skriver även ut ett till felmeddelande
                        Console.ReadKey();//Readkey så att den väntar lite innan den hoppar till menyn igen
                        Console.Clear();
                        Console.ResetColor();//Nollställer färgen då jag bara ville ha fel meddelandet rött
                        Meny = true;
                        continue;
                    }

                    void addition()// Skapat metoden addition
                    {
                        if (MathOperator.Contains('+'))//Om inmatning innehåller(Contains) "+" ska denna kod utföras
                        {
                            Console.WriteLine("Ange nästa tal");
                            num2 = Convert.ToDouble(Console.ReadLine());//Läser in andra inmatningen
                            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");//Skriver ut hela ekvationen
                            sparadetal.Add($"{num1} + {num2} = {num1 + num2}");//Sparar hela ekvationen i listan genom att skriva listans namn och .Add
                        }
                    }

                    void subtraktion()// Skapat metoden subtraktion
                    {
                        if (MathOperator.Contains('-'))//Samma här, bara att det är en annnan matematisk operator
                        {
                            Console.WriteLine("Ange nästa tal");
                            num2 = Convert.ToDouble(Console.ReadLine());//Läser in andra inmatninen
                            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                            sparadetal.Add($"{num1} - {num2} = {num1 - num2}");
                        }
                    }

                    void division()// Skapat metoden division
                    {
                        if (MathOperator.Contains('/'))
                        {
                            Console.WriteLine("Ange nästa tal");
                            num2 = Convert.ToDouble(Console.ReadLine());
                            if (num1 == 0 && num2 == 0)//Om spelaren väljer att dela 0/0 ska error meddelandet nedan printas ut
                            {
                                Console.WriteLine("Ogiltig inmatning!");
                            }
                            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                            sparadetal.Add($"{num1} / {num2} = {num1 / num2}");
                        }
                    }

                    void multiplikation()// Skapat metoden multiplikation
                    {
                        if (MathOperator.Contains('*'))
                        {
                            Console.WriteLine("Ange nästa tal");
                            num2 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                            sparadetal.Add($"{num1} * {num2} = {num1 * num2}");
                        }
                    }
                }
            }
        }
    }
}