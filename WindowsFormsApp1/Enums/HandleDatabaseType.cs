using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Enums
{
    public enum HandleDatabaseType
    {
        DEPLOY = 0,
        MIGRATE = 1,
        DROP = 2,
        BACKUP = 3,
        RESTORE = 4
    }

    public enum ScriptType
    {
        DEPLOY_MAIN = 0,
        DEPLOY_CF = 1,
        MIGRATE_MAIN = 2,
        MIGRATE_CF = 3,
        BACKUP_MAIN = 4,
        BACKUP_CF = 5,
        RESTORE_MAIN = 6,
        RESTORE_CF = 7,
        DROP_MAIN = 8,
        DROP_CF = 9
    }

    public enum ServerType
    {
        MAIN = 0,
        CF = 1
    }
}
