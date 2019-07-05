
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_GroupFunc 
    {
        #region private

        private int _isid;
        private string _GroupCode;
        private string _MenuCode;
        private Nullable<int> _Authorities;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string GroupCode { get { return _GroupCode; } set { _GroupCode = value;  } }
        public string MenuCode { get { return _MenuCode; } set { _MenuCode = value;  } }
        public Nullable<int> Authorities { get { return _Authorities; } set { _Authorities = value;  } }
    }
}
