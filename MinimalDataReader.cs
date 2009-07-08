using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SoSlow {
    // minimal reader for bulk importer 
    abstract class MinimalDataReader : IDataReader {

        public abstract void Dispose();

        public abstract int FieldCount {
            get;
        }

        public abstract object GetValue(int i);

        public abstract DataTable GetSchemaTable();

        public abstract bool Read();


        public int RecordsAffected {
            get {throw new NotImplementedException();}
        }

        public void Close() {
            throw new NotImplementedException();
        }

        public int Depth {
            get { throw new NotImplementedException(); }
        }

      
        public bool IsClosed {
            get { throw new NotImplementedException(); }
        }

        public bool NextResult() {
            throw new NotImplementedException();
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




  

    }
}
