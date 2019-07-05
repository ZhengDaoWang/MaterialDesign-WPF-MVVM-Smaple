using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Model;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Dictionary
{
    /// <summary>
    /// 编辑字典
    /// </summary>
    public class DictionaryDialogViewModel : BaseHostDialogOperation
    {
        public DictionaryDialogViewModel()
        {
            Dictionary = new tb_Dictionary();
        }

        /// <summary>
        /// 类型集合
        /// </summary>
        public List<tb_DictionaryType> TypeList { get; set; }

        private tb_Dictionary dictionary;

        /// <summary>
        /// 字典内容
        /// </summary>
        public tb_Dictionary Dictionary
        {
            get { return dictionary; }
            set { dictionary = value; RaisePropertyChanged(); }
        }

        public override void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false) return;

            if (string.IsNullOrWhiteSpace(Dictionary.DataCode) || string.IsNullOrWhiteSpace(
                Dictionary.NativeName) || Dictionary.DataType == 0)
            {
                eventArgs.Cancel();
            }
        }
    }
}
