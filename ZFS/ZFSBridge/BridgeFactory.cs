using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.ServerBusiness;
using ZFSData.InterFace;
using ZFSData.InterFace.User;
using ZFSData.Manager;
using ZFSInterface.User;

namespace ZFSBridge
{
    /// <summary>
    /// 数据连接方式
    /// </summary>
    public enum BridgeType
    {
        ADO,
        Http,
        WebApi,
        Wcf,
    }

    /// <summary>
    /// 数据桥接工厂
    /// </summary>
    public class BridgeFactory
    {
        static BridgeFactory()
        {
            switch (bridgeType)
            {
                case BridgeType.ADO:
                    BridgeManager = new EntityFrameworkManager();
                    break;
                case BridgeType.Http:
                    break;
                case BridgeType.WebApi:
                    break;
                case BridgeType.Wcf:
                    BridgeManager = new WcfFrameworkManager();
                    break;
                default:
                    BridgeManager = new EntityFrameworkManager();
                    break;
            }
        }

        /// <summary>
        /// 桥接抽象层
        /// </summary>
        public static BridgeManager BridgeManager { get; private set; }

        /// <summary>
        /// 连接模式
        /// </summary>
        private static BridgeType bridgeType = BridgeType.Wcf;

    }
}
