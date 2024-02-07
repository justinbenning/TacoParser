using System.ComponentModel.DataAnnotations;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line) 
        {
            logger.LogInfo("Begin parsing");

            
            var cells = line.Split(',');

            
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null; 
            }

            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);  // TODO: Grab the longitude from your array at index 1
            var location = new Point { Latitude = latitude, Longitude = longitude };

            var name = cells[2];// TODO: Grab the name from your array at index 2

            Point point = new Point { Latitude = latitude, Longitude = longitude };
          
            var bell = new TacoBell { Name = name, Location = location };

            return bell ;
        }
    }
}
