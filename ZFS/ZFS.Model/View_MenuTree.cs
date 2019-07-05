
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{

    [Serializable]
    public partial class View_MenuTree 
    {
        #region private

        private int _isid;
        private string _MenuName;
        private string _MenuCaption;
        private string _ParentName;
        private string _AuthorityName;
        private Nullable<int> _AuthorityValue;
        private string _MenuCode;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string MenuName { get { return _MenuName; } set { _MenuName = value;  } }
        public string MenuCaption { get { return _MenuCaption; } set { _MenuCaption = value;  } }
        public string ParentName { get { return _ParentName; } set { _ParentName = value;  } }
        public string AuthorityName { get { return _AuthorityName; } set { _AuthorityName = value;  } }
        public Nullable<int> AuthorityValue { get { return _AuthorityValue; } set { _AuthorityValue = value;  } }
        public string MenuCode { get { return _MenuCode; } set { _MenuCode = value;  } }
    }
}
