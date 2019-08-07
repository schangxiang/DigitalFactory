using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;


namespace WIP_IDAL
{
    /// <summary> 
    /// 异常信息表数据访问类 
    /// </summary> 
    public interface IExceptionInfoDAL
    {



        /// <summary> 
        /// 增加一条异常信息表数据 
        /// </summary> 
        /// <param name="model">要插入的异常信息表实体</param> 
        /// <returns>插入生成的最新主键值</returns> 
        int Add(ExceptionInfoEntity model);



        /// <summary> 
        /// 增加一条异常信息表数据 
        /// </summary> 
        /// <param name="model">要插入的异常信息表实体</param> 
        /// <returns>插入生成的最新主键值</returns> 
        int AddWithKey(ExceptionInfoEntity model);


    }
}


