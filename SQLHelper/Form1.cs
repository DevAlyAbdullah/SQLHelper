namespace SQLHelper
{
    public partial class Form1 : Form
    {
        public static readonly string Disk = "C:\\Users\\Aly\\Desktop\\Database";
        public static readonly string AccountDB = "SRO_VT_ACCOUNT";
        public static readonly string ShardDB = "SRO_VT_SHARD";
        public static readonly string ShardLogDB = "SRO_VT_SHARDLOG";

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Backup_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                //declare date
                string month = DateTime.Now.Month.ToString("00");
                string day = DateTime.Now.Day.ToString("00");
                string year = DateTime.Now.Year.ToString("0000");
                string date = month + day + year;

                SQL.Post($@"backup database {AccountDB} to disk = '{Disk}\{AccountDB}{date}.bak'");
                SQL.Post($@"backup database {ShardDB} to disk = '{Disk}\{ShardDB}{date}.bak'");
                SQL.Post($@"backup database {ShardLogDB} to disk = '{Disk}\{ShardLogDB}{date}.bak'");
            });
        }

        private void BTN_Restore_Click(object sender, EventArgs e)
        {
            DeleteDatabase();

            Task.Run(() =>
            {
                //clear old data
                string StartWithAccountDB = "";
                string StartWithShardDB = "";
                string StartWithShardLogDB = "";

                //set new data
                StartWithAccountDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(AccountDB) && x.Contains(".bak")).FirstOrDefault();
                StartWithShardDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(ShardDB) && x.Contains(".bak")).FirstOrDefault();
                StartWithShardLogDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(ShardLogDB) && x.Contains(".bak")).FirstOrDefault();

                //assure the data is correct
                if (StartWithAccountDB.Contains(AccountDB) && StartWithAccountDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {AccountDB} from disk = '{StartWithAccountDB}'");
                }
                if (StartWithShardDB.Contains(ShardDB) && StartWithShardDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {ShardDB} from disk = '{StartWithShardDB}'");
                }
                if (StartWithShardLogDB.Contains(ShardLogDB) && StartWithShardLogDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {ShardLogDB} from disk = '{StartWithShardLogDB}'");
                }
            });
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            DeleteDatabase();
        }

        private void DeleteDatabase()
        {
            Task.Run(() =>
            {
                SQL.Post($"DROP DATABASE {AccountDB}");
                SQL.Post($"DROP DATABASE {ShardDB}");
                SQL.Post($"DROP DATABASE {ShardLogDB}");
            });
        }
    }
}