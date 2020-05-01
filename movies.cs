using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Cinema
    {
        public static Random rnd = new Random();
        public int Rating = 0;
        public virtual String GetInfo()
        {
           var str = String.Format("\nРейтинг (TOMATOMETER): {0}", this.Rating);
            return str;
        }
    }
    public class Film : Cinema
     {
            public int TimingCount = 0;
        public bool Withpitt = false;
        
        public static Film Generate()
        {    
            return new Film
            {
                Rating = rnd.Next() % 100, 
                TimingCount = 50 + rnd.Next() % 150,
                Withpitt = rnd.Next() % 2 == 0
            };
        }
    }
    public class Series : Cinema
    {
        public int RangeNumber = 0; 
        public int SeasonNumber = 0; 
        public override String GetInfo()
        {
            var str = "Я Сериал";
            str += base.GetInfo();
            str += String.Format("\nКол во серий: {0}", this.RangeNumber);
            str += String.Format("\nКол во сезонов: {0}", this.SeasonNumber);
            return str;
        }
        public static Series Generate()
        {
            return new Series
            {
                Rating = rnd.Next() % 100,
                RangeNumber = 6 + rnd.Next() % 10, 
                SeasonNumber = 2 + rnd.Next() % 2, 
            };
        }
    }
    public enum TelecastType { автомобильный, кулинарный, музыкальный, медицинский };
    public class Telecast : Cinema
    {
        public int RangeNumber = 0; 
        public TelecastType type = TelecastType.кулинарный; 
        public override String GetInfo()
        {
            var str = "Я телепередача";
            str += base.GetInfo();
            str += String.Format("\nКол во серий: {0}", this.RangeNumber);
            str += String.Format("\nТип: {0}", this.type);
            return str;
        }
        public static Telecast Generate()
        {
            return new Telecast
            {
                Rating = rnd.Next() % 100, 
                RangeNumber = 6 + rnd.Next() % 10, 
                type = (TelecastType)rnd.Next(4) 
            };
        }
    }
}
