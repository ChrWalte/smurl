using System;

namespace smurl.data
{
    public static class SqlCommand
    {
        #region Tables

        public static string CreateLinkTable
            => ReadSqlFromFile("/Sql/Tables/CreateLinkTable.sql");

        public static string CreateClickTable
            => ReadSqlFromFile("/Sql/Tables/CreateClickTable.sql");

        #endregion Tables

        #region Links

        public static string GetLink
            => ReadSqlFromFile("./Sql/Link/GetLink.sql");

        public static string CreateLink
            => ReadSqlFromFile("/Sql/Link/CreateLink.sql");

        public static string UpdateLink
            => ReadSqlFromFile("/Sql/Link/UpdateLink.sql");

        public static string DeleteLink
            => ReadSqlFromFile("/Sql/Link/DeleteLink.sql");

        #endregion Links

        #region Clicks

        public static string GetClicks
            => ReadSqlFromFile("/Sql/Click/GetClicks.sql");

        public static string CreateClick
            => ReadSqlFromFile("/Sql/Click/CreateClick.sql");

        public static string UpdateClick
            => ReadSqlFromFile("/Sql/Click/UpdateClick.sql");

        public static string DeleteClick
            => ReadSqlFromFile("/Sql/Click/DeleteClick.sql");

        #endregion Clicks

        private static string ReadSqlFromFile(string path)
            => System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + path);
    }
}