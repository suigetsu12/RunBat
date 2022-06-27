using System.Text.Json.Serialization;

namespace RunBatForm.Models
{
    public class ItemModel : BaseItemModel
    {
        public bool ischecked { get; set; }

        [JsonIgnore]
        public string message { get; set; }

        [JsonIgnore]
        public int processid { get; set; }
    }
}
