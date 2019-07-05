/*
   绑定视图：DictionaryView.xaml
   文件说明：数据字典业务层
*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.ILayer.Base;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData;
using ZFSData.InterFace;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Service;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Dictionary
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class DictionaryViewModel : BaseOperation<tb_Dictionary>
    {
        public override async void GetPageData(int pageIndex)
        {
            try
            {
                IDictionary user = ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryManager();
                var req = await user.GetPagingModels(pageIndex, PageSize, new tb_Dictionary() { DataCode = SearchText, NativeName = SearchText });
                TotalCount = req.TotalCount;
                GridModelList.Clear();
                var UserList = req.Results as List<tb_Dictionary>;
                UserList.ForEach((arg) => GridModelList.Add(arg));
                base.SetPageCount();
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        public override async void Add<TModel>(TModel model)
        {
            try
            {
                DictionaryDialogViewModel view = new DictionaryDialogViewModel();
                view.Title = Configuration.DIC_ADD_TITLE;
                view.TypeList = (await ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryTypeManager().GetDictionaryTypes()).Results;
                var dialog = ServiceProvider.Instance.Get<IModelDialog>("DictionaryViewDlg");
                dialog.BindViewModel(view);
                var taskResult = await dialog.ShowDialog(
               null,
               view.ExtendedClosingEventHandler);
                if (taskResult)
                {
                    view.Dictionary.CreatedBy = Loginer.LoginerUser.UserName;
                    view.Dictionary.CreationDate = DateTime.Now;
                    var req = await ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryManager().AddEntity(view.Dictionary);
                    if (req.Success)
                    {
                        GridModelList.Add(view.Dictionary);
                        Msg.Info(Configuration.ADD_MSG);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        public override async void Edit<TModel>(TModel model)
        {
            if (!this.GetButtonAuth(Authority.EDIT)) return;

            if (model != null)
            {
                try
                {
                    DictionaryDialogViewModel view = new DictionaryDialogViewModel();
                    view.Title = Configuration.DIC_EDIT_TITLE;
                    view.Dictionary = model as tb_Dictionary;
                    view.TypeList = (await ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryTypeManager().GetDictionaryTypes()).Results;
                    var dialog = ServiceProvider.Instance.Get<IModelDialog>("DictionaryViewDlg");
                    dialog.BindViewModel(view);
                    var taskResult = await dialog.ShowDialog(
               null,
               view.ExtendedClosingEventHandler);
                    if (taskResult)
                    {
                        view.Dictionary.LastUpdatedBy = Loginer.LoginerUser.UserName;
                        view.Dictionary.LastUpdateDate = DateTime.Now;
                        var dicSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryManager();
                        var req = await dicSerivce.UpdateEntity(view.Dictionary);
                        if (req.Success)
                        {
                            var mod = GridModelList.FirstOrDefault(t => t.isid.Equals(view.Dictionary.isid));
                            GridModelList.Remove(mod);
                            GridModelList.Add(view.Dictionary);
                            Msg.Info(Configuration.UPDATE_MSG);
                        }
                    }
                }
                catch (Exception ex)
                { Msg.Error(ex.Message, false); }
            }
        }

        public override async void Del<TModel>(TModel model)
        {
            if (!this.GetButtonAuth(Authority.DELETE)) return;

            if (model != null)
            {
                var dic = model as tb_Dictionary;

                bool result = await Msg.Question(string.Format(Configuration.DIC_EDIT_TITLE, dic.NativeName));

                try
                {
                    if (result)
                    {
                        var DicSerivce = ZFSBridge.BridgeFactory.BridgeManager.GetDictionaryManager();
                        var req = await DicSerivce.DeleteEntity(dic);
                        if (req.Success)
                        {
                            var mod = GridModelList.FirstOrDefault(t => t.isid.Equals(dic.isid));
                            GridModelList.Remove(mod);
                            Msg.Info(Configuration.DELETE_MSG);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Msg.Error(ex.Message, false);
                }
            }
        }
    }
}
