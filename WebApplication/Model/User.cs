using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Model
{
    public enum Edit { YES, NO };
    public enum Sexs { 男, 女 };
    public enum Roles { 非法用户, 全权用户, 可写用户, 只读用户 };

    [SugarTable("user")]
    public class User
    {

        #region 属性
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public Int32 Id { get; set; }


        [SugarColumn(ColumnName = "role")]
        [EnumDataType(typeof(Roles)), Display(Name = "角色")]
        public Roles Role
        {
            get;
            set;
        }
        [SugarColumn(ColumnName = "name")]
        [Required, StringLength(40), Display(Name = "姓名")]
        public String Name
        {
            get;
            set;
        }
        [SugarColumn(ColumnName = "sex")]
        [EnumDataType(typeof(Sexs)), Display(Name = "性别")]
        public Sexs Sex
        {
            get;
            set;
        }
        [SugarColumn(ColumnName = "tel")]
        [StringLength(40), Display(Name = "电话")]
        public String Tel
        {
            get;
            set;
        }
        [SugarColumn(ColumnName = "unit")]
        [StringLength(40), Display(Name = "单位")]
        public String Unit
        {
            get;
            set;
        }
        [SugarColumn(ColumnName = "adress")]
        [StringLength(40), Display(Name = "地址")]
        public String Adress
        {
            get;
            set;
        }
        [Range(typeof(DateTime), "1/1/2013", "1/1/3000", ErrorMessage = "Please provide an enrollment date after 1/1/2013")]
        [SugarColumn(ColumnName = "birthday", ColumnDataType = "DateTime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Birthday
        {
            get;
            set;
        }

#endregion
    }
}