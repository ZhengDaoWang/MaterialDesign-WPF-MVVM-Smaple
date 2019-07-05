
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    [Serializable]
    public partial class tb_Attachment 
    {
        #region private

        private int _FileID;
        private string _DocID;
        private string _FileTitle;
        private string _FileName;
        private string _FileType;
        private Nullable<decimal> _FileSize;
        private byte[] _FileBody;
        private string _IsDroped;

        #endregion

        [Key]
        public int FileID { get { return _FileID; } set { _FileID = value;  } }
        public string DocID { get { return _DocID; } set { _DocID = value; } }
        public string FileTitle { get { return _FileTitle; } set { _FileTitle = value;  } }
        public string FileName { get { return _FileName; } set { _FileName = value;  } }
        public string FileType { get { return _FileType; } set { _FileType = value;  } }
        public Nullable<decimal> FileSize { get { return _FileSize; } set { _FileSize = value;  } }
        public byte[] FileBody { get { return _FileBody; } set { _FileBody = value;  } }
        public string IsDroped { get { return _IsDroped; } set { _IsDroped = value;  } }
    }
}
