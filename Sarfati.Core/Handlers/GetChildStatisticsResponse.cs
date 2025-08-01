using System;
using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetChildStatisticsResponse
    {
        public Statistic Weekly { get; set; }
        public Statistic Monthly { get; set; }
        public Statistic Yearly { get; set; }
    }

    public class Statistic
    {
        public int TotalCompleted { get; set; }
        public int TotalPending { get; set; }
        public int TotalInProgress { get; set; }
        public Dictionary<string, int> WorkActivity { get; set; }
    }
}