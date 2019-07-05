
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_LoginLog 
    {
        #region private

        private int _isid;
        private string _Account;
        private string _LoginType;
        private Nullable<System.DateTime> _CurrentTime;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string Account { get { return _Account; } set { _Account = value;  } }
        public string LoginType { get { return _LoginType; } set { _LoginType = value;  } }
        public Nullable<System.DateTime> CurrentTime { get { return _CurrentTime; } set { _CurrentTime = value;  } }
    }
}
