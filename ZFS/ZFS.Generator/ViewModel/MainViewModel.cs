using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ZFS.Generator.ViewModel;
using ZFSData.InterFace;

namespace ZFS.Generator
{
    public class MainViewModel : ViewModelBase
    {
        #region 1.生成模型[Model]

        public SplashManager Manager { get; set; } = new SplashManager();

        #region 属性

        private string _tableName;
        private string _classNameSpace = "ZFS.Model";
        private string _classDesc;
        private string _buildtext;
        private bool _SaveFile = true;
        private bool _GenPreview = true;
        private string _SavePath;
        private List<string> _TabList;
        private RelayCommand _GetUvCommand;
        private RelayCommand _BuildCommand;
        private RelayCommand _SelectPathCommand;

        /// <summary>
        /// 保存文件位置
        /// </summary>
        public string SavePath
        {
           
            get { return _SavePath; }
            set { _SavePath = value;
                RaisePropertyChanged(); }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public bool SaveFile
        {
            get { return _SaveFile; }
            set { _SaveFile = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 生成预览
        /// </summary>
        public bool GenPreview
        {
            get { return _GenPreview; }
            set { _GenPreview = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 生成代码
        /// </summary>
        public string BuildText
        {
            get { return _buildtext; }
            set { _buildtext = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 选择表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 类命名空间
        /// </summary>
        public string ClassNameSpace
        {
            get { return _classNameSpace; }
            set { _classNameSpace = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 类说明
        /// </summary>
        public string ClassDesc
        {
            get { return _classDesc; }
            set { _classDesc = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 表列表
        /// </summary>
        public List<string> TabList
        {
            get { return _TabList; }
            set { _TabList = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Command

        /// <summary>
        /// 获取表
        /// </summary>
        public RelayCommand GetUvCommand
        {
            get
            {
                if (_GetUvCommand == null)
                {
                    _GetUvCommand = new RelayCommand(() => GetUv());
                }
                return _GetUvCommand;
            }
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        public RelayCommand BuildCommand
        {
            get
            {
                if (_BuildCommand == null)
                {
                    _BuildCommand = new RelayCommand(() => Build());
                }
                return _BuildCommand;
            }
        }

        /// <summary>
        /// 选择路径
        /// </summary>
        public RelayCommand SelectPathCommand
        {
            get
            {
                if (_SelectPathCommand == null)
                {
                    _SelectPathCommand = new RelayCommand(() => SelectPath());
                }
                return _SelectPathCommand;
            }
        }


        #endregion

        #region Command 实现

        /// <summary>
        /// 选择保存文件目录
        /// </summary>
        public void SelectPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePath = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// 获取表视图
        /// </summary>
        public async void GetUv()
        {
            try
            {
                IGenerator genrator = ZFSBridge.BridgeFactory.BridgeManager.GetGeneratorManager();
               var request = await genrator.GetUvs();
                if(request.Success)
                {
                    TabList = request.Results;
                    Manager.ShowDefault("加载成功!");
                }
                else
                {
                    System.Windows.MessageBox.Show(request.ErrorCode);
                }
               
            }
            catch
            {
                System.Windows.MessageBox.Show("未能连接服务！");
            }
        }

        /// <summary>
        /// 生成模型代码
        /// </summary>
        public async void Build()
        {
            try
            {
                IGenerator genrator = ZFSBridge.BridgeFactory.BridgeManager.GetGeneratorManager();
                var request = await genrator.GetTableStructs(TableName, ClassNameSpace, ClassDesc);
                if (GenPreview)
                {
                    Messenger.Default.Send(request.Results, "UpdateText");
                    BuildText = request.Results;
                }
                if (SaveFile)
                {
                    if (SavePath == null)
                    {
                        System.Windows.Forms.MessageBox.Show("请选择保存目录！");
                    }
                    else
                        File.WriteAllText(SavePath + "\\" + TableName + ".cs", request.Results, Encoding.UTF8);
                }
                Manager.ShowDefault("生成成功!");
            }
            catch
            {
                System.Windows.MessageBox.Show("未能连接服务！");
            }
        }

        public void Copy()
        {
            if (BuildText != null)
            {
                System.Windows.Clipboard.SetDataObject(BuildText);
                Manager.ShowDefault("复制成功!");
            }
        }

        #endregion

        #endregion

    }
}
