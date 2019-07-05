
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_LogFields 
    {
        #region private

        private int _isid;
        private string _TableName;
        private string _FieldName;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string TableName { get { return _TableName; } set { _TableName = value;  } }
        public string FieldName { get { return _FieldName; } set { _FieldName = value;  } }
    }
}
