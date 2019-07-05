/*
   绑定视图：MenuView.xaml
   文件说明：菜单管理业务层
*/

using GalaSoft.MvvmLight.Command;
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
using ZFSBridge;
using ZFSData;
using ZFSData.InterFace.User;
using ZFSDomain.Common.CoreLib;
using ZFSDomain.Service;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Menu
{
    public class MenuViewModel : BaseOperation<tb_Menu>
    {
        public override async void GetPageData(int pageIndex)
        {
            try
            {
                IMenu user = ZFSBridge.BridgeFactory.BridgeManager.GetMenuManager();
                var request = await user.GetPagingModels(
                     pageIndex,
                     PageSize,
                     new tb_Menu() { MenuCode = SearchText, MenuName = SearchText });
                TotalCount = request.TotalCount;
                GridModelList.Clear();
                var GirdList = request.Results as List<tb_Menu>;
                GirdList.ForEach((arg) => GridModelList.Add(arg));
                base.SetPageCount();
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message, false);
            }
        }

        /// <summary>
        /// 绑定默认功能
        /// </summary>
        public override void SetDefaultButton()
        {
            ButtonDefaults.Add(new ToolBarDefault<tb_Menu>() { AuthValue = Authority.IMPORT, ModuleName = "导入", Command = this.ImportCommand });
        }

        /// <summary>
        /// 导入菜单
        /// </summary>
        public async void Import(object obj)
        {
            
                MenuDialogViewModel view = new MenuDialogViewModel();
                view.Title = Configuration.MENU_ADD_TITLE;
                var Imenu = ServiceProvider.Instance.Get<IModelDialog>("MenuViewDlg");
                Imenu.BindViewModel(view);
                bool taskResult = await Imenu.ShowDialog(null, view.ExtendedClosingEventHandler);
                if (taskResult)
                {
                    try
                    {
                        if (view.MenusModelList.Count > 0)
                        {
                            var Iuser = BridgeFactory.BridgeManager.GetMenuManager();
                            List<tb_Menu> menus = new List<tb_Menu>();
                            for (int i = 0; i < view.MenusModelList.Count; i++)
                            {
                                menus.Add(view.MenusModelList[i]);
                            }
                            var req = await Iuser.UpdateMenus(menus);
                            if (req.Success)
                                Msg.Info(Configuration.ADD_MSG);
                            else
                                Msg.Info(req.ErrorCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Msg.Error(ex.Message, false);
                    }
                }

        }

        public override void Add<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public override void Edit<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public override void Del<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        #region 绑定命令

        private RelayCommand<tb_Menu> _importCommand;

        public RelayCommand<tb_Menu> ImportCommand
        {
            get
            {
                if (_importCommand == null)
                {
                    _importCommand = new RelayCommand<tb_Menu>(t => Import(t));
                }
                return _importCommand;
            }
            set { _importCommand = value; }
        }

        #endregion
        
    }
}
