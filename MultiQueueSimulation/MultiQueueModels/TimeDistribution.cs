using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class TimeDistribution
    {
        public int Time { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        
        public decimal SetCummProp(decimal Last)
        {
            CummProbability = this.Probability + Last;
            return CummProbability;
        }
        public void SetRanges(int Minimum)
        {
            MinRange = Minimum;
            MaxRange = (int)CummProbability*100;
        }
        
    }
}
