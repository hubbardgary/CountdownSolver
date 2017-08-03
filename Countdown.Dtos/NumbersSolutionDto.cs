using System;
using System.Collections.Generic;
using System.Text;

namespace Countdown.Api.Services.Models
{
    public class NumbersSolutionDto
    {
        public int Target { get; set; }
        public int[] Numbers { get; set; }
        public int DistanceFromTarget { get; set; }
        public IEnumerable<string> Solutions { get; set; }
    }
}
