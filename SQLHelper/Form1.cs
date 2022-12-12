using System.Data;

namespace SQLHelper
{
    public partial class Form1 : Form
    {
        public static readonly string Disk = "YourDatabasesLocation";
        public static readonly string AccountDB = "SRO_VT_ACCOUNT";
        public static readonly string ShardDB = "SRO_VT_SHARD";
        public static readonly string ShardLogDB = "SRO_VT_SHARDLOG";
        public static readonly string ProxyDB = "SRO_VT_PROXY";

        public Form1()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls = false;
        }

        private void BTN_Backup_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                BackupDatabase();
            });
        }

        private void BTN_Restore_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                DeleteDatabase();
                RestoreDatabase();
            });
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                DeleteDatabase();
            });
        }

        private void BackupDatabase()
        {
            Label_Backup.Text = $"Processing...";
            Label_Backup.ForeColor = System.Drawing.Color.Black;
            try
            {
                int counter = 0;
                string month = DateTime.Now.Month.ToString("00");
                string day = DateTime.Now.Day.ToString("00");
                string year = DateTime.Now.Year.ToString("0000");
                string date = month + day + year;
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{AccountDB}'") != string.Empty)
                {
                    SQL.Post($@"backup database {AccountDB} to disk = '{Disk}\{AccountDB}{date}.bak'");
                    counter++;
                }
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardDB}'") != string.Empty)
                {
                    SQL.Post($@"backup database {ShardDB} to disk = '{Disk}\{ShardDB}{date}.bak'");
                    counter++;
                }
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardLogDB}'") != string.Empty)
                {
                    SQL.Post($@"backup database {ShardLogDB} to disk = '{Disk}\{ShardLogDB}{date}.bak'");
                    counter++;
                }
                if (counter > 0)
                {
                    Label_Backup.Text = $"[{counter}] Databases found and backuped.";
                    Label_Backup.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label_Backup.Text = "No Databases found.";
                    Label_Backup.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch
            {
                Label_Backup.Text = "Error!";
                Label_Backup.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void RestoreDatabase()
        {
            Label_Restore.Text = $"Processing...";
            Label_Restore.ForeColor = System.Drawing.Color.Black;
            try
            {
                int counter = 0;
                string StartWithAccountDB = "";
                string StartWithShardDB = "";
                string StartWithShardLogDB = "";
                StartWithAccountDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(AccountDB) && x.Contains(".bak")).FirstOrDefault();
                StartWithShardDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(ShardDB) && x.Contains(".bak")).FirstOrDefault();
                StartWithShardLogDB =
               Directory.GetFiles(Disk).Where(x => x.Contains(ShardLogDB) && x.Contains(".bak")).FirstOrDefault();

                if (StartWithAccountDB.Contains(AccountDB) && StartWithAccountDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {AccountDB} from disk = '{StartWithAccountDB}'");
                    counter++;
                }
                if (StartWithShardDB.Contains(ShardDB) && StartWithShardDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {ShardDB} from disk = '{StartWithShardDB}'");
                    counter++;
                }
                if (StartWithShardLogDB.Contains(ShardLogDB) && StartWithShardLogDB.Contains(".bak"))
                {
                    SQL.Post($@"restore database {ShardLogDB} from disk = '{StartWithShardLogDB}'");
                    counter++;
                }

                if (counter > 0)
                {
                    Label_Restore.Text = $"[{counter}] Databases found and restored.";
                    Label_Restore.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label_Restore.Text = $"No Databases found.";
                    Label_Restore.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch
            {
                Label_Restore.Text = "Error!";
                Label_Restore.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DeleteDatabase()
        {
            Label_Delete.Text = $"Processing...";
            Label_Delete.ForeColor = System.Drawing.Color.Black;
            try
            {
                int FoundCounter = 0;
                int DeletedCounter = 0;
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{AccountDB}'") != string.Empty)
                {
                    FoundCounter++;
                    SQL.Post($"DROP DATABASE {AccountDB}");
                    if (string.IsNullOrEmpty(SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{AccountDB}'")))
                    {
                        DeletedCounter++;
                    }
                }
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardDB}'") != string.Empty)
                {
                    FoundCounter++;
                    SQL.Post($"DROP DATABASE {ShardDB}");
                    if (string.IsNullOrEmpty(SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardDB}'")))
                    {
                        DeletedCounter++;
                    }
                }
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardLogDB}'") != string.Empty)
                {
                    FoundCounter++;
                    SQL.Post($"DROP DATABASE {ShardLogDB}");
                    if (string.IsNullOrEmpty(SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ShardLogDB}'")))
                    {
                        DeletedCounter++;
                    }
                }
                if (SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ProxyDB}'") != string.Empty)
                {
                    FoundCounter++;
                    SQL.Post($"DROP DATABASE {ProxyDB}");
                    if (string.IsNullOrEmpty(SQL.GetSingleValue($"select top 1 name from master.sys.databases where name = '{ProxyDB}'")))
                    {
                        DeletedCounter++;
                    }
                }
                if (FoundCounter > 0 || DeletedCounter > 0)
                {
                    if (FoundCounter == DeletedCounter)
                    {
                        Label_Delete.Text = $"[{FoundCounter}] Databases found and deleted.";
                        Label_Delete.ForeColor = System.Drawing.Color.Green;
                        return;
                    }
                    if (FoundCounter > DeletedCounter)
                    {
                        Label_Delete.Text = $"[{FoundCounter}/{DeletedCounter}] Databases found and deleted.";
                        Label_Delete.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    Label_Delete.Text = "No Databases found.";
                    Label_Delete.ForeColor = System.Drawing.Color.Green;
                    return;
                }
            }
            catch
            {
                Label_Delete.Text = "Error!";
                Label_Delete.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}