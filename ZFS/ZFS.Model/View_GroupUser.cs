
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class View_GroupUser 
    {
        #region private

        private string _GroupCode;
        private string _UserName;
        private string _Account;
        private int _isid;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }

        public string GroupCode { get { return _GroupCode; } set { _GroupCode = value;  } }
        public string UserName { get { return _UserName; } set { _UserName = value;  } }
        public string Account { get { return _Account; } set { _Account = value;  } }
    }
}
