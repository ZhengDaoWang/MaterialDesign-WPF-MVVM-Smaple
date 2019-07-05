
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_FieldNameDefs 
    {
        #region 

        private int _isid;
        private string _TableName;
        private string _FieldName;
        private string _DisplayName;
        private string _Remark;
        private string _FlagDisplay;

        #endregion


        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string TableName { get { return _TableName; } set { _TableName = value;  } }
        public string FieldName { get { return _FieldName; } set { _FieldName = value;  } }
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value;  } }
        public string Remark { get { return _Remark; } set { _Remark = value;  } }
        public string FlagDisplay { get { return _FlagDisplay; } set { _FlagDisplay = value;  } }
    }
}
