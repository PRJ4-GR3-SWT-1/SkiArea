using System;
using System.Collections.Generic;
using System.Linq;
using SkiAreaOpgave.Data;
using SkiAreaOpgave.Models;

namespace SkiAreaOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SkiArea");

            Area dummyArea = new Area()
            {
                Name = "Badass Area",
                Skilifts = new List<Skilift>(),
                Skipasses = new List<Skipass>(),
                Slopes = new List<Slope>()
            };
            Slope dummySlope = new Slope()
            {
                Name = "Badass Slope",
                Areas = new List<Area>(),
                Primed = false,
                SlopeCat = "Black"
            };
            dummySlope.Areas.Add(dummyArea);

            Skilift dummySkilift = new Skilift()
            {
                area = dummyArea,
                capacity = 420,
                from = "Langbortistan",
                to = "Tætpåistan",
                speed = 40
            };

            Guest guest = new Guest() { Age = 42, Name = "Flopper The Third" };
            DateTime from = new DateTime(2021, 3, 17, 11, 52, 00);
            DateTime to = new DateTime(2022, 3, 17, 11, 52, 00);

            Skipass dummySkipass = new Skipass()
            {
                AreaList = new List<Area>(),
                Guest = guest,
                Price = 99.99,
                ValidFrom = from,
                ValidTo = to
            };

            dummyArea.Skilifts.Add(dummySkilift);
            dummyArea.Skipasses.Add(dummySkipass);
            dummyArea.Slopes.Add(dummySlope);

            using (var context = new Context())
            {
                context.Area.Add(dummyArea);
                context.SaveChanges();
            }

           /* using (var context = new Context())
            {
                context.Area.Add(new Area()
                {
                    Name = "Badass Area",
                    Skilifts = new List<Skilift>(),
                    Skipasses = new List<Skipass>(),
                    Slopes = new List<Slope>()
                });
                
                context.Area.Last().Slopes.Add(new Slope()
                {
                    Name = "Badass Slope",
                    Areas = new List<Area>(),
                    Primed = false,
                    SlopeCat = "IDK"
                });
                context.Area.Last().Slopes.Last().Areas.Add(context.Area.Last());

                context.Area.Last().Skilifts.Add(new Skilift()
                {
                    area = context.Area.Last(),
                    capacity = 420,
                    from = "Langbortistan",
                    to = "Tætpåistan",
                    SkiliftId = 1,
                    speed = 40
                });

                Guest guest = new Guest() {Age = 42, GuestID = 1, Name = "Flopper The Third"};
                DateTime from = new DateTime(2021, 3, 17, 11, 52, 00);
                DateTime to = new DateTime(2022, 3, 17, 11, 52, 00);

                context.Area.Last().Skipasses.Add(new Skipass()
                {
                    AreaList = new List<Area>(),
                    Guest = guest,
                    Price = 99.99,
                    SkipassId = 1,
                    ValidFrom = from,
                    ValidTo = to
                });
                context.Area.Last().Skipasses.Last().AreaList.Add(context.Area.Last());
                
                context.SaveChanges();
            }*/
        }
    }
}
