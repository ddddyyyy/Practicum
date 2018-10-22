using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Model
{
    [SugarTable("comment")]
    public class Comment
    {
        #region 属性
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }

        [SugarColumn(ColumnName = "uid")]
        public Int32 Uid
        { get; set; }
        [SugarColumn(ColumnName = "c_uid")]
        public Int32 Cuid
        {
            get; set;
        }
        [SugarColumn(ColumnName = "content")]
        [StringLength(100), Display(Name = "评价")]
        public String Content
        {
            get; set;
        }
        [SugarColumn(ColumnName = "create_date", ColumnDataType = "DateTime")]
        [StringLength(100), Display(Name = "评价日期")]
        public DateTime Date
        { get; set; }

        #endregion
    }
}