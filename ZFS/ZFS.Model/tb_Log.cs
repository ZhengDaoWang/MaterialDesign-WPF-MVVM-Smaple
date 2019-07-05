
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_Log 
    {
        #region private

        private int _isid;
        private string _LodID;
        private string _LogUser;
        private System.DateTime _LogDate;
        private int _OperationType;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string LodID { get { return _LodID; } set { _LodID = value;  } }
        public string LogUser { get { return _LogUser; } set { _LogUser = value;  } }
        public System.DateTime LogDate { get { return _LogDate; } set { _LogDate = value;  } }
        public int OperationType { get { return _OperationType; } set { _OperationType = value;  } }
    }
}
