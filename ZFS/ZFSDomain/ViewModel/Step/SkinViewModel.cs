/*
   绑定视图：SkinWindow.xaml
   文件说明：皮肤设置业务层
*/
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZFS.Library;
using ZFSDomain.SysModule;

namespace ZFSDomain.ViewModel.Step
{
    /// <summary>
    /// 皮肤设置
    /// </summary>
    public class SkinViewModel : BaseHostDialogOperation
    {
        public SkinViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        public bool _IsChecked;

        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 样式集合
        /// </summary>
        public IEnumerable<Swatch> Swatches { get; }

        private RelayCommand<Swatch> _applyCommand;
        private RelayCommand _ToggleBaseCommand;

        public RelayCommand ToggleBaseCommand
        {
            get
            {
                if (_ToggleBaseCommand == null)
                {
                    _ToggleBaseCommand = new RelayCommand(() => ApplyBase());
                };
                return _ToggleBaseCommand;
            }
        }

        /// <summary>
        /// 设置样式命令
        /// </summary>
        public RelayCommand<Swatch> ApplyCommand
        {
            get
            {
                if (_applyCommand == null)
                {
                    _applyCommand = new RelayCommand<Swatch>(o => Apply(o));
                };
                return _applyCommand;
            }
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="swatch"></param>
        private void Apply(Swatch swatch)
        {
            SerivceFiguration.SetKin(swatch.Name);
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        /// <summary>
        /// 设置默认样式
        /// </summary>
        /// <param name="swatch"></param>
        public void ApplyDefault(string skinName)
        {
            var Swatch = Swatches.FirstOrDefault(t => t.Name.Equals(skinName));
            if (Swatch != null)
                new PaletteHelper().ReplacePrimaryColor(Swatch);
        }
        
        private void ApplyBase()
        {
            new PaletteHelper().SetLightDark(IsChecked);
        }

    }

}
