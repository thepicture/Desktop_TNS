using System.Linq;

namespace TelekomNevaSvyazWpfApp.Models.Entities
{
    public partial class Subscriber
    {
        public string PassportSeries => string.Join("",
                                                    PassportSeriesAndNumber
                                                        .Replace(" ", "")
                                                        .Take(4));
        public string PassportNumber => string
            .Join("", 
                  PassportSeriesAndNumber
                    .Replace(" ", "")
                    .Reverse()
                    .Take(6));
    }
}
