
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_Menu 
    {
        #region private

        private int _isid;
        private string _MenuCode;
        private string _MenuName;
        private string _MenuCaption;
        private string _MenuNameSpace;
        private Nullable<int> _MenuAuthorities;
        private string _ParentName;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string MenuCode { get { return _MenuCode; } set { _MenuCode = value;  } }
        public string MenuName { get { return _MenuName; } set { _MenuName = value;  } }
        public string MenuCaption { get { return _MenuCaption; } set { _MenuCaption = value;  } }
        public string MenuNameSpace { get { return _MenuNameSpace; } set { _MenuNameSpace = value;  } }
        public Nullable<int> MenuAuthorities { get { return _MenuAuthorities; } set { _MenuAuthorities = value;  } }
        public string ParentName { get { return _ParentName; } set { _ParentName = value;  } }
    }
}
