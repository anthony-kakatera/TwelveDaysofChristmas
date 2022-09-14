using System.Security.Cryptography;

namespace TwelveDaysofChristmas{


    public class TwelveDaysofChristmas {

        public static void Main(string[] args) {
            //get input from user
            Console.WriteLine("Provide a number for the verses to be generated");
            //getting number of verses to gnerate
            string numberOfVerses = Console.ReadLine();

            //check if provided value is an actual number
            if (!int.TryParse(numberOfVerses, out _))
            {
                //Notify user of the wrong input
                Console.WriteLine("The provided input isn't a number");
            }
            else
            {
                //calling verse constraction function
                string[] temp = twelveDaysofChristmas(Int32.Parse(numberOfVerses));
                Console.WriteLine(String.Join(" ", temp));
            }
        }

        public static string[] twelveDaysofChristmas(int verseCount)
        {
            string[] verses = generateVerses(verseCount);
            //save option
            bool printState = saveToHistoryOption(verses);

            if (printState)
            {
                //returning empty verses to print blank after saving
                Array.Clear(verses, 0, verses.Length);
                return verses;
            }
            else {
                //returning verses
                return verses;
            }
            
        }

        public static string[] generateVerses(int verseCount) {
            //worded representation of numbers
            string[] days = { "First", "Second", "Third", "Fourth", "Fith", "Sith", "Seventh", "Eigth", "Tenth", "Eleventh", "Twelveth" };
            //a random gift that will be randomized
            string[] gift = { "Mug", "Cheese Wheel", "Car", "Fire truck", "Jaguar", "Basket Ball", "Tenis Racket", "Rug", "Carpet" };
            //common phrases
            string commonPhrase1 = "On the";
            string commonPhrase2 = "day of Christmas,\nMy true love gave to me\n";
            //verses
            string[] verses = new string[verseCount];
            //loop through 
            for (int i = 0; i < verses.Length; i++)
            {
                //verse constraction
                verses[i] = commonPhrase1 + " " + days[i] + " " + commonPhrase2 + "A " + gift[RandomNumberGenerator.GetInt32(0, gift.Length - 1)] + "\n";
            }
            return verses;
        }

        public static bool saveToHistoryOption(string[] verses)
        {
            //get input from user
            Console.WriteLine("Do you wish to save these verses to a specific file ? (Y/N)\nNote: N prints out the verses on the console");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower().Equals("y"))
            {
                //Get new filename from user
                //C:\Users\akakatera\source\repos\TwelveDaysofChristmas\sample.txt
                Console.WriteLine("Please provide a valid file path");
                string userFileName = Console.ReadLine();
                //create file
                if (File.Exists(@userFileName))
                {
                    //save file
                    writeToFile(verses, userFileName);
                }
                else {
                    Console.WriteLine("File doesn't exist");
                }
                return true;

            }
            else {
                return false;
            }
        }

        private static void createFile(string? userFileName)
        {
            //create path
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\", userFileName + ".txt");
            //check if file exists
            if (!File.Exists(path))
            {
                //creaete file
                File.Create(path);
            }
            else {
                //append
                Console.WriteLine("File already exists. new verses will be appended");
            }
        }
        public static void writeToFile(string[] verses, string userFileName)
        {
            string path = System.IO.Path.Combine(@userFileName);
            //save verses
            File.AppendAllText(path, String.Join("", verses));
            //display saved 
            Console.WriteLine("Verses saved to user specified file");
            Console.ReadLine();
        }
    }

}