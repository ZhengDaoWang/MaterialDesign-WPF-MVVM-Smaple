
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_User 
    {
        #region private

        private int _isid;
        private string _Account;
        private string _UserName;
        private string _Address;
        private string _Tel;
        private string _Email;
        private string _Password;
        private Nullable<System.DateTime> _LastLoginTime;
        private Nullable<System.DateTime> _LastLogoutTime;
        private Nullable<int> _IsLocked;
        private Nullable<System.DateTime> _CreateTime;
        private string _FlagAdmin;
        private string _FlagOnline;
        private Nullable<int> _LoginCounter;
        private string _DataSets;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string Account { get { return _Account; } set { _Account = value;  } }
        public string UserName { get { return _UserName; } set { _UserName = value;  } }
        public string Address { get { return _Address; } set { _Address = value;  } }
        public string Tel { get { return _Tel; } set { _Tel = value;  } }
        public string Email { get { return _Email; } set { _Email = value;  } }
        public string Password { get { return _Password; } set { _Password = value;  } }
        public Nullable<System.DateTime> LastLoginTime { get { return _LastLoginTime; } set { _LastLoginTime = value;  } }
        public Nullable<System.DateTime> LastLogoutTime { get { return _LastLogoutTime; } set { _LastLogoutTime = value;  } }
        public Nullable<int> IsLocked { get { return _IsLocked; } set { _IsLocked = value;  } }
        public Nullable<System.DateTime> CreateTime { get { return _CreateTime; } set { _CreateTime = value;  } }
        public string FlagAdmin { get { return _FlagAdmin; } set { _FlagAdmin = value;  } }
        public string FlagOnline { get { return _FlagOnline; } set { _FlagOnline = value;  } }
        public Nullable<int> LoginCounter { get { return _LoginCounter; } set { _LoginCounter = value;  } }
        public string DataSets { get { return _DataSets; } set { _DataSets = value;  } }
    }
}
