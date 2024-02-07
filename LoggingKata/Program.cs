using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.CompilerServices;




namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            string[] lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");
            //Console.WriteLine(lines[0] );
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            ITrackable[] locations = lines.Select(parser.Parse).ToArray();
            //Console.WriteLine(locations[0].Name);



            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other.


            ITrackable trackTacoBell1 = null;
            ITrackable trackTacoBell2 = null;
            // TODO: Create a `double` variable to store the distance
            double distanceBetween;

            double currentBetween = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                var loc1 = locations[i];
                var cor1 = new GeoCoordinate(loc1.Location.Latitude, loc1.Location.Longitude);
                for (int j = i +1 ; j < locations.Length ; j++)
                {
                    var loc2 = locations[j];
                    var cor2 = new GeoCoordinate(loc2.Location.Latitude, loc2.Location.Longitude);
                    distanceBetween = cor1.GetDistanceTo(cor2);
                    
                    if (distanceBetween > currentBetween)
                    {
                        currentBetween = distanceBetween;
                        trackTacoBell1 = locations[i];
                        trackTacoBell2 = locations[j];
                    }
                    
                }   
            }
            Console.WriteLine(trackTacoBell1.Name);
            Console.WriteLine(trackTacoBell2.Name);
            Console.WriteLine(currentBetween);
        }
    }
}
