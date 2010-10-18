using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SoSlow {
    class TagReader : MinimalDataReader {

        DataTable schema;
        DataColumn nameColumn;
        SqlDataReader unsplitReader;
        TagIdResolver resolver;
        SqlConnection connection;

        List<string> currentTags = new List<string>();
        int currentPostId;

        public TagReader(string connectionString) {

            resolver = new TagIdResolver(connectionString);
            connection = new SqlConnection(connectionString);
            connection.Open();

            using (var cmd = connection.CreateCommand()) {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select top 1 * from PostTags";
                using (var reader = cmd.ExecuteReader()) {
                    schema = reader.GetSchemaTable();
                }
            }

            using (var command = connection.CreateCommand()) {
                command.CommandText = "select Id, Tags from Posts where PostTypeId = 1 and Tags is not null";
                unsplitReader = command.ExecuteReader();
            }

            nameColumn = schema.Columns[0];
        }

        public override void Dispose() {
            unsplitReader.Close();
            resolver.Dispose();
            connection.Close();
        }

        public override int FieldCount {
            get { return 2; }
        }

        public override object GetValue(int i) {
            // can be optimised 
            string name = (string)schema.Rows[i][nameColumn];
            if (name == "PostId") {
                return currentPostId;
            } else {
                return resolver.Resolve(currentTags[0]);
            }
        }

        public override DataTable GetSchemaTable() {
            return schema;
        }

        public override bool Read() {

            bool done = false;

            if (currentTags.Count > 0) {
                // pop 
                currentTags.RemoveAt(0);
            }

            while (!done && currentTags.Count == 0) {
                done = !unsplitReader.Read();
                if (done) break;
                currentTags.AddRange(unsplitReader.GetString(1).Replace("<", "").Split('>'));
                
                // I should really just use LINQ - I'm trying to ensure this builds on .Net 2.0 
                for (int i = currentTags.Count - 1; i >= 0; i--) {
                    if (currentTags[i].Trim().Length == 0) {
                        currentTags.RemoveAt(i);
                    }
                }

                // really ... LINQ would to wonders
                var dict = new Dictionary<string, object>();
                foreach (var item in currentTags) {
                    dict[item] = currentTags;
                }

                currentTags = new List<string>(dict.Keys);

                currentPostId = unsplitReader.GetInt32(0);
            }

            return !done;
        }
    } 
}
