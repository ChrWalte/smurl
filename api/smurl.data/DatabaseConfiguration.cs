namespace smurl.data
{
    public class DatabaseConfiguration
    {
        public readonly string ConnectionString;

        public DatabaseConfiguration(string connectionString)
            => ConnectionString = connectionString;
    }
}