
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_Dictionary 
    {
        #region private

        private int _isid;
        private int _TypeID;
        private string _DataCode;
        private string _NativeName;
        private string _EnglishName;
        private Nullable<System.DateTime> _CreationDate;
        private string _CreatedBy;
        private Nullable<System.DateTime> _LastUpdateDate;
        private string _LastUpdatedBy;

        #endregion

        [Key]
        public int isid { get { return _isid; } set { _isid = value;  } }
        public int DataType { get { return _TypeID; } set { _TypeID = value; } }
        public string DataCode { get { return _DataCode; } set { _DataCode = value;  } }
        public string NativeName { get { return _NativeName; } set { _NativeName = value;  } }
        public string EnglishName { get { return _EnglishName; } set { _EnglishName = value;  } }
        public Nullable<System.DateTime> CreationDate { get { return _CreationDate; } set { _CreationDate = value;  } }
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value;  } }
        public Nullable<System.DateTime> LastUpdateDate { get { return _LastUpdateDate; } set { _LastUpdateDate = value;  } }
        public string LastUpdatedBy { get { return _LastUpdatedBy; } set { _LastUpdatedBy = value;  } }
    }
}
