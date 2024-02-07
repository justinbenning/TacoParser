using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public Point Location { get ; set ; }
     
        
        public string Name { get ; set ; }
    }
}
