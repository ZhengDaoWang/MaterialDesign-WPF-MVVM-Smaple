using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZFS.ILayer;
using ZFS.Library.Enums;
using ZFS.Library.Helper;
using ZFSDomain.Common.CoreLib;

namespace ZFSDomain.SysModule
{
    /// <summary>
    /// 主窗口基类
    /// </summary>
    public partial class BaseOperation<T> : ViewModelBase where T : class, new()
    {

        #region 基类属性  [搜索、功能按钮、数据表单]

        private string searchText = string.Empty;
        private bool _DisplayGrid, _DisplayMetro = true;
        private ObservableCollection<T> _GridModelList;
        private ObservableCollection<ContextMenuModel> _ContextMenuModel;
        private ObservableCollection<ToolBarDefault<T>> _ButtonDefaults;

        /// <summary>
        /// 搜索内容
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; RaisePropertyChanged(); }
        }

        public bool DisplayGrid
        {
            get { return _DisplayGrid; }
            set { _DisplayGrid = value; RaisePropertyChanged(); }
        }

        public bool DisplayMetro
        {
            get { return _DisplayMetro; }
            set { _DisplayMetro = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 表单数据
        /// </summary>
        public ObservableCollection<T> GridModelList
        {
            get { return _GridModelList; }
            set { _GridModelList = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 右键模块
        /// </summary>
        public ObservableCollection<ContextMenuModel> ContextMenuModel
        {
            get { return _ContextMenuModel; }
            set { _ContextMenuModel = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 功能集合
        /// </summary>
        public ObservableCollection<ToolBarDefault<T>> ButtonDefaults
        {
            get { return _ButtonDefaults; }
            set { _ButtonDefaults = value; RaisePropertyChanged(); }
        }

        #endregion

        #region 基类实现

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void InitViewModel()
        {
            GridModelList = new ObservableCollection<T>();
            ButtonDefaults = new ObservableCollection<ToolBarDefault<T>>();
            this.SetDefaultButton(); //默认功能按钮
            this.SetContextMenu(); //默认右键菜单
            this.SetButtonAuth(); //设置按钮权限
            this.GetPageData(this.PageIndex); //获取首次加载数据
        }

        /// <summary>
        /// 设置默认按钮
        /// </summary>
        public virtual void SetDefaultButton()
        {
            ButtonDefaults.Add(new ToolBarDefault<T>() { AuthValue = Authority.ADD, ModuleName = "新增", Command = this.AddCommand });
            ButtonDefaults.Add(new ToolBarDefault<T>() { AuthValue = Authority.EDIT, ModuleName = "编辑", Command = this.EditCommand, IsVisibility = true, Hide = true });
            ButtonDefaults.Add(new ToolBarDefault<T>() { AuthValue = Authority.DELETE, ModuleName = "删除", Command = this.DelCommand, IsVisibility = true, Hide = true });
        }

        public virtual void SetContextMenu()
        {
            ContextMenuModel = new ObservableCollection<ContextMenuModel>();
            ContextMenuModel.Add(new Common.CoreLib.ContextMenuModel() { MenuHeader = ContextMenuType.MetroMode });
        }

        #endregion

        #region 功能命令

        private RelayCommand<T> _AddCommand;
        private RelayCommand<T> _EditCommand;
        private RelayCommand<T> _DelCommand;
        private RelayCommand _QueryCommand;
        private RelayCommand _ResetCommand;
        private RelayCommand<ContextMenuModel> _ExcuteCommand;

        /// <summary>
        /// 右键命令
        /// </summary>
        public RelayCommand<ContextMenuModel> ExcuteCommand
        {
            get
            {
                if (_ExcuteCommand == null)
                {
                    _ExcuteCommand = new RelayCommand<ContextMenuModel>(t => Excute(t));
                }
                return _ExcuteCommand;
            }
            set { _ExcuteCommand = value; }
        }



        /// <summary>
        /// 新增
        /// </summary>
        public RelayCommand<T> AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand<T>(t => Add(t));
                }
                return _AddCommand;
            }
            set { _AddCommand = value; }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public RelayCommand<T> EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new RelayCommand<T>(t => Edit(t));
                }
                return _EditCommand;
            }
            set { _EditCommand = value; }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<T> DelCommand
        {
            get
            {
                if (_DelCommand == null)
                {
                    _DelCommand = new RelayCommand<T>(t => Del(t));
                }
                return _DelCommand;
            }
            set { _DelCommand = value; }
        }

        /// <summary>
        /// 查询
        /// </summary>
        public RelayCommand QueryCommand
        {
            get
            {
                if (_QueryCommand == null)
                {
                    _QueryCommand = new RelayCommand(() => Query());
                }
                return _QueryCommand;
            }
            set { _QueryCommand = value; }
        }

        /// <summary>
        /// 重置
        /// </summary>
        public RelayCommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new RelayCommand(() => Reset());
                }
                return _ResetCommand;
            }
            set { _ResetCommand = value; }
        }



        #endregion
    }

    /// <summary>
    /// 主窗口/分布基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseOperation<T> : IDataOperation, IPermission, IDataPager
    {
        #region IPermission

        protected int? authValue;

        /// <summary>
        /// 权限值
        /// </summary>
        public int? AuthValue { get { return authValue; } set { authValue = value; } }


        /// <summary>
        /// 验证按钮权限
        /// </summary>
        /// <param name="authValue"></param>
        /// <returns></returns>
        public bool GetButtonAuth(int authValue)
        {
            var def = ButtonDefaults.FirstOrDefault(t => (AuthValue & t.AuthValue) == authValue);//
            //&& t.IsVisibility.Equals(false));

            if (def != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        public void SetButtonAuth()
        {
            if (Loginer.LoginerUser.IsAdmin) return;

            foreach (var b in ButtonDefaults)
                if ((this.AuthValue & b.AuthValue) != b.AuthValue)
                    b.IsVisibility = true; //隐藏功能
        }


        #endregion

        #region IDataPager

        public RelayCommand GoHomePageCommand { get { return new RelayCommand(() => GoHomePage()); } }

        public RelayCommand GoOnPageCommand { get { return new RelayCommand(() => GoOnPage()); } }

        public RelayCommand GoNextPageCommand { get { return new RelayCommand(() => GoNextPage()); } }

        public RelayCommand GoEndPageCommand { get { return new RelayCommand(() => GoEndPage()); } }


        private int totalCount = 0;
        private int pageSize = 15;
        private int pageIndex = 1;
        private int pageCount = 0;

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get { return totalCount; } set { totalCount = value; RaisePropertyChanged(); } }

        /// <summary>
        /// 当前页大小
        /// </summary>
        public int PageSize { get { return pageSize; } set { pageSize = value; RaisePropertyChanged(); } }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get { return pageIndex; } set { pageIndex = value; RaisePropertyChanged(); } }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int PageCount { get { return pageCount; } set { pageCount = value; RaisePropertyChanged(); } }

        /// <summary>
        /// 首页
        /// </summary>
        public virtual void GoHomePage()
        {
            if (this.PageIndex == 1) return;

            PageIndex = 1;

            GetPageData(PageIndex);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        public virtual void GoOnPage()
        {
            if (this.PageIndex == 1) return;

            PageIndex--;

            this.GetPageData(PageIndex);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        public virtual void GoNextPage()
        {
            if (this.PageIndex == PageCount) return;

            PageIndex++;

            this.GetPageData(PageIndex);
        }

        /// <summary>
        /// 尾页
        /// </summary>
        public virtual void GoEndPage()
        {
            this.PageIndex = PageCount;

            GetPageData(PageCount);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pageIndex"></param>
        public virtual void GetPageData(int pageIndex) { }

        /// <summary>
        /// 设置页数
        /// </summary>
        public virtual void SetPageCount()
        {
            PageCount = Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)PageSize));
        }

        #endregion

        #region IDataOperation

        /// <summary>
        /// 新增
        /// </summary>
        public virtual void Add<TModel>(TModel model) { }

        /// <summary>
        /// 编辑
        /// </summary>
        public virtual void Edit<TModel>(TModel model) { }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Del<TModel>(TModel model) { }

        /// <summary>
        /// 查询
        /// </summary>
        public virtual void Query()
        {
            this.GetPageData(this.PageIndex);
        }

        /// <summary>
        /// 重置
        /// </summary>
        public virtual void Reset()
        {
            this.SearchText = string.Empty;
        }

        #endregion

        #region 右键模块

        /// <summary>
        /// 执行选择模块
        /// </summary>
        /// <param name="model"></param>
        public void Excute(ContextMenuModel model)
        {
            switch (model.MenuHeader)
            {
                case ContextMenuType.MetroMode:
                    this.DisplayGrid = true;
                    this.DisplayMetro = false;
                    model.MenuHeader = ContextMenuType.ListMode;
                    break;
                case ContextMenuType.ListMode:
                    this.DisplayGrid = false;
                    this.DisplayMetro = true;
                    model.MenuHeader = ContextMenuType.MetroMode;
                    break;
                    //...
            }
        }

        #endregion
    }

    /// <summary>
    /// 弹出式窗口基类-Host
    /// </summary>
    public class BaseHostDialogOperation : ViewModelBase
    {
        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 窗口打开时处理的逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public virtual void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {

        }

        /// <summary>
        /// 窗口关闭前处理的逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public virtual void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false) return;
        }
    }

    /// <summary>
    /// 弹出式窗口基类-Window
    /// </summary>
    public class BaseDialogOperation : ViewModelBase
    {
        public bool Result { get; set; }

        private RelayCommand _CancelCommand;
        private RelayCommand _SaveCommand;

        public RelayCommand CancelCommand
        {
            get {
                if (_CancelCommand == null)
                    _CancelCommand = new RelayCommand(() => Cancel());
                return _CancelCommand; }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new RelayCommand(() => Save());
                return _SaveCommand;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            Result = false;
            Messenger.Default.Send("", "DialogClose");
        }

        /// <summary>
        /// 确定
        /// </summary>
        public void Save()
        {
            Result = true;
            Messenger.Default.Send("", "DialogClose");
        }


    }
}
