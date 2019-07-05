using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Model
{
    public class ZFSConfig : DbContext
    {
        public ZFSConfig() : base("name=ZFSContext")
        {

        }

        public  DbSet<tb_Attachment> tb_Attachment { get; set; }
        public  DbSet<tb_AuthorityItem> tb_AuthorityItem { get; set; }
        public  DbSet<tb_DataRules> tb_DataRules { get; set; }
        public  DbSet<tb_Dictionary> tb_Dictionary { get; set; }
        public  DbSet<tb_DictionaryType> tb_DictionaryType { get; set; }
        public  DbSet<tb_FieldNameDefs> tb_FieldNameDefs { get; set; }
        public  DbSet<tb_Group> tb_Group { get; set; }
        public  DbSet<tb_GroupFunc> tb_GroupFunc { get; set; }
        public  DbSet<tb_GroupUser> tb_GroupUser { get; set; }
        public  DbSet<tb_Log> tb_Log { get; set; }
        public  DbSet<tb_LogDetail> tb_LogDetail { get; set; }
        public  DbSet<tb_LogFields> tb_LogFields { get; set; }
        public  DbSet<tb_LoginLog> tb_LoginLog { get; set; }
        public  DbSet<tb_Menu> tb_Menu { get; set; }
        public  DbSet<tb_Rules> tb_Rules { get; set; }
        public  DbSet<tb_User> tb_User { get; set; }
        public  DbSet<View_GroupUser> View_GroupUser { get; set; }
        public  DbSet<View_MenuTree> View_MenuTree { get; set; }
        public  DbSet<View_UserAuthority> View_UserAuthority { get; set; }

    }
}
