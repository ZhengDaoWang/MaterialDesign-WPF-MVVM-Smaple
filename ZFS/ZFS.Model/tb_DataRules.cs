
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_DataRules 
    {
        #region private

        private int _isid;
        private string _DataCode;
        private string _Header;
        private Nullable<int> _Length;
        private Nullable<int> _MaxID;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public string DataCode { get { return _DataCode; } set { _DataCode = value;  } }
        public string Header { get { return _Header; } set { _Header = value;  } }
        public Nullable<int> Length { get { return _Length; } set { _Length = value;  } }
        public Nullable<int> MaxID { get { return _MaxID; } set { _MaxID = value;  } }
    }
}
