
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_DictionaryType 
    {
        #region private

        private int _isid;
        private string _TypeName;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string TypeName { get { return _TypeName; } set { _TypeName = value;  } }
    }
}
