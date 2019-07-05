
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{

    [Serializable]
    public partial class View_UserAuthority 
    {
        #region private

        private string _Account;
        private string _MenuName;
        private string _MenuCaption;
        private string _MenuNameSpace;
        private string _GroupName;
        private Nullable<int> _Authorities;
        private int _isid;
        private string _ParentName;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }

        public string Account { get { return _Account; } set { _Account = value;  } }
        public string MenuName { get { return _MenuName; } set { _MenuName = value;  } }
        public string MenuCaption { get { return _MenuCaption; } set { _MenuCaption = value;  } }
        public string MenuNameSpace { get { return _MenuNameSpace; } set { _MenuNameSpace = value;  } }
        public string GroupName { get { return _GroupName; } set { _GroupName = value;  } }
        public Nullable<int> Authorities { get { return _Authorities; } set { _Authorities = value;  } }

        public string ParentName { get { return _ParentName; } set { _ParentName = value;  } }
    }
}
