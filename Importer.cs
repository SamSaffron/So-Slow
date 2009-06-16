using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace SoSlow {

    class ProgressEventArgs : EventArgs {
        public int RowsImported { get; set; }
    }

    class Importer {

        string filename;
        string targetTable;
        SqlConnection connection;

        public Importer(string filename, string targetTable, SqlConnection connection) {
            this.filename = filename;
            this.targetTable = targetTable;
            this.connection = connection;
            NotifyPerRows = 500; 
        }

        public string TargetTable { get { return targetTable; } }

        public int NotifyPerRows { get; set; }

        public event EventHandler<ProgressEventArgs> Progress; 

        public void Import() {

            SqlBulkCopy copy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, null);
            copy.DestinationTableName = targetTable;
            
            copy.NotifyAfter = NotifyPerRows;
            copy.SqlRowsCopied += new SqlRowsCopiedEventHandler(copy_SqlRowsCopied);
            copy.BatchSize = NotifyPerRows;
            
            copy.WriteToServer(new DumpReader(filename, targetTable, connection));
            

            
        }

        void copy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e) {
            var p = Progress;
            if (p != null) p(this, new ProgressEventArgs() { RowsImported = (int)e.RowsCopied });
        }

  

        class DumpReader : IDataReader {

            DataTable schema;
            DataColumn nameColumn;

            XmlTextReader reader;

            public DumpReader(string filename, string target, SqlConnection connection) {
                using (var cmd = connection.CreateCommand()) {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 1 * from " + target;
                    using (var reader = cmd.ExecuteReader()) {
                        schema = reader.GetSchemaTable();
                    }
                }

                nameColumn = schema.Columns[0];

                this.reader = new XmlTextReader(filename);
            }

            #region IDataReader Members

            public void Close() {
                throw new NotImplementedException();
            }

            public int Depth {
                get { throw new NotImplementedException(); }
            }

            public DataTable GetSchemaTable() {
                return schema;
            }

            public bool IsClosed {
                get { throw new NotImplementedException(); }
            }

            public bool NextResult() {
                throw new NotImplementedException();
            }

            public bool Read() {
                bool gotRow = false;
                while (reader.Read()) {
                    if (reader.Name == "row") {
                        gotRow = true;
                        break;
                    }
                }
                return gotRow;
            }

            public int RecordsAffected {
                get { throw new NotImplementedException(); }
            }

            #endregion

            #region IDisposable Members

            public void Dispose() {
                reader.Close();
            }

            #endregion

            #region IDataRecord Members

            public int FieldCount {
                get { return schema.Rows.Count; }
            }

            public bool GetBoolean(int i) {
                throw new NotImplementedException();
            }

            public byte GetByte(int i) {
                throw new NotImplementedException();
            }

            public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }

            public char GetChar(int i) {
                throw new NotImplementedException();
            }

            public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }

            public IDataReader GetData(int i) {
                throw new NotImplementedException();
            }

            public string GetDataTypeName(int i) {
                throw new NotImplementedException();
            }

            public DateTime GetDateTime(int i) {
                throw new NotImplementedException();
            }

            public decimal GetDecimal(int i) {
                throw new NotImplementedException();
            }

            public double GetDouble(int i) {
                throw new NotImplementedException();
            }

            public Type GetFieldType(int i) {
                throw new NotImplementedException();
            }

            public float GetFloat(int i) {
                throw new NotImplementedException();
            }

            public Guid GetGuid(int i) {
                throw new NotImplementedException();
            }

            public short GetInt16(int i) {
                throw new NotImplementedException();
            }

            public int GetInt32(int i) {
                throw new NotImplementedException();
            }

            public long GetInt64(int i) {
                throw new NotImplementedException();
            }

            public string GetName(int i) {
                throw new NotImplementedException();
            }

            public int GetOrdinal(string name) {
                throw new NotImplementedException();
            }

            public string GetString(int i) {
                throw new NotImplementedException();
            }

            

            public object GetValue(int i) {
                string name = (string)schema.Rows[i][nameColumn];
                return reader.GetAttribute(name);
            }

            public int GetValues(object[] values) {
                throw new NotImplementedException();
            }

            public bool IsDBNull(int i) {
                throw new NotImplementedException();
            }

            public object this[string name] {
                get { throw new NotImplementedException(); }
            }

            public object this[int i] {
                get { throw new NotImplementedException(); }
            }

            #endregion
        } 

    }
}
