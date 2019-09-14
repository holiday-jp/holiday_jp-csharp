
using Newtonsoft.Json;

namespace HolidayJp
{
    public class Holiday
    {
        [JsonProperty("date")]
        public string Ymd { get; set; }
        public string Week { get; set; }
        [JsonProperty("week_en")]
        public string WeekEn { get; set; }
        public string Name { get; set; }
        [JsonProperty("name_en")]
        public string NameEn { get; set; }

    }
}