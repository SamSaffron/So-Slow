using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SoSlow {

    class ProgressEventArgs : EventArgs {
        public int RowsImported { get; set; }
    }

    class Importer {
        const int TIMEOUT = 5 * 60;
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

            SqlBulkCopy copy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock , null);
            copy.BulkCopyTimeout = TIMEOUT;
            copy.DestinationTableName = targetTable;
            
            copy.NotifyAfter = NotifyPerRows;
            copy.SqlRowsCopied += new SqlRowsCopiedEventHandler(copy_SqlRowsCopied);
            copy.BatchSize = NotifyPerRows;

            // TODO: Extract this further up
            var validator = targetTable == "Comments" ? CommentsValidator : (ColumnValidator)null;

            var dumpReader = new DumpReader(filename, targetTable, connection, validator);
            copy.WriteToServer(dumpReader);
           
        }

        string CommentsValidator(string name, string value) {
            if (name == "UserId" && value == "") {
                return "-1";
            }
            return value;
        }  

        void copy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e) {
            var p = Progress;
            if (p != null) p(this, new ProgressEventArgs() { RowsImported = (int)e.RowsCopied });
        }



    }
}
