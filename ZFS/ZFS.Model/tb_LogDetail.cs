
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_LogDetail 
    {
        #region private

        private int _isid;
        private string _LogID;
        private string _TableName;
        private string _FieldName;
        private string _OldValue;
        private string _NewValue;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string LogID { get { return _LogID; } set { _LogID = value;  } }
        public string TableName { get { return _TableName; } set { _TableName = value;  } }
        public string FieldName { get { return _FieldName; } set { _FieldName = value;  } }
        public string OldValue { get { return _OldValue; } set { _OldValue = value;  } }
        public string NewValue { get { return _NewValue; } set { _NewValue = value;  } }
    }
}
