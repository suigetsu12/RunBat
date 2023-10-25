using RunBatForm.Enums;

namespace RunBatForm.Models
{
    public class DatabaseItemModel : BaseItemModel
    {
        public HandleDatabaseType handle_type { get; set; }
        public ScriptType script_type { get; set; }
    }
}
