
using System;
namespace chiase
{
    public class ObjectIud
    {
        private string _columnname;
        private string _dulieu;
        private string _kieudulieu;

        public ObjectIud()
        {
        }

        public ObjectIud(string columnname, string dulieu, string kieudulieu)
        {
            this._columnname = columnname;
            this._dulieu = dulieu;
            this._kieudulieu = kieudulieu;
        }

        public string getColName
        {
            get
            {
                return this._columnname;
            }
        }

        public string getData
        {
            get
            {
                return this._dulieu;
            }
        }

        public string getStyleData
        {
            get
            {
                return this._kieudulieu;
            }
        }

        public string setColName
        {
            set
            {
                this._columnname = value;
            }
        }

        public string setData
        {
            set
            {
                this._dulieu = value;
            }
        }

        public string setStyleData
        {
            set
            {
                this._kieudulieu = value;
            }
        }
    }


}