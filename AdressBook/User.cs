using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdressBook
{
    public enum Edit { YES, NO };
    public enum Sexs { 男, 女 };
    public enum Roles { 非法用户,全权用户, 可写用户,只读用户 };

    public delegate void chage(User user);

    [SugarTable("user")]
    public class User : INotifyPropertyChanged,ICloneable
    {
        private String _name;
        private Sexs _sex;
        private String _unit;
        private String _adress;
        private String _tel;
        private DateTime _birthday;
        private Roles _role;

        public event chage Change;

        #region 属性
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public Int32 id { get; set; }
        //[SugarColumn(ColumnName = "role")]
        //public Int32 TRole
        //{
        //    get { return (int)_role; }
        //    set
        //    {
        //        switch (value)
        //        {
        //            case 0:_role = Roles.非法用户;
        //                break;
        //            case 1:
        //                _role = Roles.全权用户;
        //                break;
        //            case 2:
        //                _role = Roles.只读用户;
        //                break;
        //            case 3:
        //                _role = Roles.可写用户;
        //                break;
        //        }
        //    }
        //}
        [SugarColumn(ColumnName = "role")]
        public Roles Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "name")]
        public String Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "sex")]
        public Sexs Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "tel")]
        public String Tel
        {
            get { return _tel; }
            set
            {
                if (_tel != value)
                {
                    _tel = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "unit")]
        public String Unit
        {
            get { return _unit; }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "adress")]
        public String Adress
        {
            get { return _adress; }
            set
            {
                if (_adress != value)
                {
                    _adress = value;
                    OnPropertyChanged();
                }
            }
        }
        [SugarColumn(ColumnName = "birthday",ColumnDataType = "DateTime")]
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new User() as object;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Change?.Invoke(this);
        }
    }
}
