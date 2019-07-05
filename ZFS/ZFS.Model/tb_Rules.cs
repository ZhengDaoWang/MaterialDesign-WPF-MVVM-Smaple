
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_Rules 
    {
        #region  private

        private int _isid;
        private string _DocName;
        private string _Header;
        private string _YYMM;
        private Nullable<int> _MaxID;
        private string _Remark;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string DocName { get { return _DocName; } set { _DocName = value;  } }
        public string Header { get { return _Header; } set { _Header = value;  } }
        public string YYMM { get { return _YYMM; } set { _YYMM = value;  } }
        public Nullable<int> MaxID { get { return _MaxID; } set { _MaxID = value;  } }
        public string Remark { get { return _Remark; } set { _Remark = value;  } }
    }
}
