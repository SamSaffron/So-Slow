using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

namespace SoSlow {


    delegate string ColumnValidator(string name, string value);

    class DumpReader : MinimalDataReader {

        DataTable schema;
        DataColumn nameColumn;
        ColumnValidator validator;
        XmlTextReader reader;

        public DumpReader(string filename, string target, SqlConnection connection, ColumnValidator validator) {
            using (var cmd = connection.CreateCommand()) {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select top 1 * from " + target;
                using (var reader = cmd.ExecuteReader()) {
                    schema = reader.GetSchemaTable();
                }
            }

            nameColumn = schema.Columns[0];

            this.reader = new XmlTextReader(filename);
            this.validator = validator;
        }

        int rowNumber;
        public override bool Read() {
            rowNumber++;
            bool gotRow = false;
            while (reader.Read()) {
                if (reader.Name == "row") {
                    gotRow = true;
                    break;
                }
            }
            return gotRow;
        }

        public override void Dispose() {
            reader.Close();
        }

        public override int FieldCount {
            get { return schema.Rows.Count; }
        }

        public override object GetValue(int i) {
            string name = (string)schema.Rows[i][nameColumn];
            return ValidateOrDefault(name, reader.GetAttribute(name));
        }

        private string ValidateOrDefault(string name, string data) {
            if (validator != null) {
                return validator(name, data);
            }
            return data;
        }

        public override DataTable GetSchemaTable() {
            return schema;
        }

    } 
}
