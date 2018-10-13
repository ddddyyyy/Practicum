using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    [SugarTable("comment")]
    class Comment : INotifyPropertyChanged
    {
        private String _content;
        private Int32 _uid;
        private Int32 _cuid;
        private DateTime _date;


        #region 属性
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public Int32 Id { get; set; }
        [SugarColumn(ColumnName = "uid")]
        public Int32 Uid
        {
            get { return _uid; }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "c_uid")]
        public Int32 Cuid
        {
            get { return _cuid; }
            set
            {
                if (_cuid != value)
                {
                    _cuid = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "content")]
        public String Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "create_date", ColumnDataType = "DateTime")]
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
