using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ardalis Insurance Rating System Starting...");

                var engine = new RatingEngine();
                engine.Rate();

                if (engine.Rating > 0)
                {
                    Console.WriteLine($"Rating: {engine.Rating}");
                }
                else
                {
                    Console.WriteLine("No rating produced.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
