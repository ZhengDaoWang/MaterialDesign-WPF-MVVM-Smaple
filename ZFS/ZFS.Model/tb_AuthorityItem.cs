
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_AuthorityItem 
    {
        #region private

        private int _isid;
        private string _AuthorityName;
        private Nullable<int> _AuthorityValue;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string AuthorityName { get { return _AuthorityName; } set { _AuthorityName = value;  } }
        public Nullable<int> AuthorityValue { get { return _AuthorityValue; } set { _AuthorityValue = value;  } }
    }
}
