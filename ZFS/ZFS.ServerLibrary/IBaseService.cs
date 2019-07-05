using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ZFSData;

namespace ZFS.ServerLibrary
{

    [ServiceContract]
    public partial interface IBaseService
    {
        #region 用户接口

        /// <summary>
        /// 根据账户获取账户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetModelByAccount(string account);

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account">账号</param>
        [OperationContract]
        Task<byte[]> Logout(string account);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> Login(string account, string password);

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetAuthority(string account);


        /// <summary>
        /// 条件查询数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetModelsByUser(byte[] search);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetPagingModelsByUser(int pageIndex, int pageSize,
            byte[] whereLambda, bool Asc = false);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> DeleteEntityByUser(byte[] entity);

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateEntityByUser(byte[] entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> AddEntityByUser(byte[] entity);

        /// <summary>
        /// 检查模型是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> ExistEntityByUser(byte[] entity);


        #endregion
    }

    public partial interface IBaseService
    {
        #region 菜单接口

        /// <summary>
        /// 获取菜单树
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetMenuTrees();

        /// <summary>
        /// 新增更新模块
        /// </summary>
        /// <param name="tb_Menus"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateMenus(byte[] MenusBytes);

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetModelsByMenu(byte[] search);

        /// <summary>
        /// 查询菜单列表-分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetPagingModelsByMenu(int pageIndex, int pageSize,
            byte[] whereLambda, bool Asc = false);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> DeleteEntityByMenu(byte[] entity);

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateEntityByMenu(byte[] entity);

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> AddEntityByMenu(byte[] entity);

        /// <summary>
        /// 检查菜单是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> ExistEntityByMenu(byte[] entity);

        #endregion
    }

    public partial interface IBaseService
    {
        #region 组接口

        /// <summary>
        /// 获取用户组集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetGroups(string search);

        /// <summary>
        /// 获取指定组用户
        /// </summary>
        /// <param name="groupCode">组代码</param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetGroupUsers(string groupID);

        /// <summary>
        /// 获取指定组所含权限
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetGroupFuncs(string groupCode);

        /// <summary>
        ///  更新用户组权限
        /// </summary>
        /// <param name="group"></param>
        /// <param name="userList"></param>
        /// <param name="funcList"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateGroupFunc(byte[] group, byte[] userList, byte[] funcList);

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> RemovebyGroup(int id);


        /// <summary>
        /// 条件查询数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetModelsByGroup(byte[] search);

        /// <summary>
        /// 获取组-分页
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetPagingModelsByGroup(int pageIndex, int pageSize,
            byte[] whereLambda, bool Asc = false);

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> DeleteEntityByGroup(byte[] entity);

        /// <summary>
        /// 更新组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateEntityByGroup(byte[] entity);

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> AddEntityByGroup(byte[] entity);

        /// <summary>
        /// 检查模型是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> ExistEntityByGroup(byte[] entity);

        #endregion
    }

    public partial interface IBaseService
    {
        #region 字典接口

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetDictionarys();

        /// <summary>
        /// 查询字典数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetModelsByDic(byte[] whereLambda);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetPagingModelsByDic(int pageIndex, int pageSize,
            byte[] whereLambda, bool Asc = false);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> DeleteEntityByDic(byte[] entity);

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateEntityByDic(byte[] entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> AddEntityByDic(byte[] entity);

        /// <summary>
        /// 检查模型是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> ExistEntityByDic(byte[] entity);

        #endregion
    }

    public partial interface IBaseService
    {
        #region 代码生成器接口

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetUvs();

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetTableStatus(string tableName, string nameSpace, string desc);



        #endregion
    }

    public partial interface IBaseService
    {
        #region 字典接口

        Task<byte[]> GetDicTypes();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> GetPagingModelsByDicType(int pageIndex, int pageSize,
            byte[] whereLambda, bool Asc = false);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> DeleteEntityByDicType(byte[] entity);

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> UpdateEntityByDicType(byte[] entity);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> AddEntityByDicType(byte[] entity);

        /// <summary>
        /// 检查模型是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<byte[]> ExistEntityByDicType(byte[] entity);

        #endregion
    }

}
