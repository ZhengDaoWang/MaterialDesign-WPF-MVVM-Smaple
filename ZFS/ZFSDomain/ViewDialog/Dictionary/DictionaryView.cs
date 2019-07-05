using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Model;
using ZFSDomain.SysModule;
using ZFSDomain.ViewModel.Dictionary;

namespace ZFSDomain.ViewDialog.Dictionary
{
    /// <summary>
    /// 字典
    /// </summary>
    [Module(ModuleType.System, "DictionaryView", "字典管理", "管理基础字典信息", "ZFSDomain.ViewDialog.Dictionary.DictionaryView", 7, "\xe669")]
    public class DictionaryView : BaseView<View.Dictionary.DictionaryView, ViewModel.Dictionary.DictionaryViewModel, tb_Dictionary>, IModel
    {

    }
}
