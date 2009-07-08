using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SoSlow {
    class TagIdResolver : IDisposable {

        SqlConnection connection;
        Dictionary<string, int> tagLookup = new Dictionary<string, int>();
        SqlCommand insertTagCommand;
        SqlParameter insertTagParam;
        SqlTransaction transaction;

        public TagIdResolver(string connectionString) {
            connection = new SqlConnection(connectionString);
            connection.Open();

            transaction = connection.BeginTransaction(); 

            insertTagCommand = connection.CreateCommand();
            insertTagCommand.Transaction = transaction;
            insertTagCommand.CommandText = "insert Tags(TagName) values (@TagName) select @@identity";
            insertTagParam = insertTagCommand.CreateParameter();
            insertTagParam.ParameterName = "TagName";
            insertTagCommand.Parameters.Add(insertTagParam);
        }

        public int Resolve(string tag) {
            int id;
            if (!tagLookup.TryGetValue(tag, out id)) {
                insertTagParam.Value = tag;
                var obj = insertTagCommand.ExecuteScalar();
                id = Convert.ToInt32(((Decimal)obj));
                tagLookup[tag] = id;
            }

            return id;
        }



        public void Dispose() {
            transaction.Commit();
            connection.Close();
        }

    }
}
