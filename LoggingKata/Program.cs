﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var allRestaurants = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable finalR1 = null; //Final answer!
            ITrackable finalR2 = null;
            double? finalDistance = 0;


            double testDistance = 0;
            ITrackable locA = null;
            ITrackable locB = null;
            var corA = new GeoCoordinate(0, 0);
            var corB = new GeoCoordinate(0, 0);
            


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < allRestaurants.Length; i++)
            {
                locA = allRestaurants[i];
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;
                

                for (int i2 = 0; i2 < allRestaurants.Length; i2++)
                {
                    locB = allRestaurants[i2];
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    testDistance = corA.GetDistanceTo(corB);
                    

                    if (testDistance > finalDistance)
                    {
                        finalDistance = testDistance;
                        finalR1 = locA;
                        finalR2 = locB;
                        
                    }
                }               

                              
            }
            double formula = 1609.34;
            finalDistance /= formula;

            Console.WriteLine();
            Console.WriteLine($"The the final locations are {finalR1.Name}, and {finalR2.Name}");
            Console.WriteLine($"{finalDistance} miles is the distance between them");


            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
