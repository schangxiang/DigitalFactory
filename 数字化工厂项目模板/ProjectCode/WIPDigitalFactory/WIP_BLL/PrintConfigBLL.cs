using System;
using System.Collections.Generic;
using System.Data;
using WIP_common;
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary> 
    /// 打印配置业务处理类 
    /// </summary> 
    public partial class PrintConfigBLL
    {
        private readonly PrintConfigDAL printConfigDAL = new PrintConfigDAL();

        #region Add

        /// <summary> 
        /// 增加一条打印配置数据 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns>插入的最新主键值</returns> 
        public int Add(PrintConfigEntity model)
        {
            model.createTime = model.lastModifyTime = DateTime.Now;
            model.delFlag = false;
            return printConfigDAL.Add(model);
        }

        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条打印配置数据 
        /// </summary> 
        /// <param name="model">要更新的打印配置实体</param> 
        /// <returns>是否更新成功</returns> 
        public bool Update(PrintConfigEntity model)
        {
            model.lastModifyTime = DateTime.Now;
            return printConfigDAL.Update(model);
        }

        #endregion

        #region Enable

        /// <summary> 
        /// 禁启用打印配置表数据 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <param name="delFlag">禁用1/启用0</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        public bool Enable(string printType, string delFlag, string lastModifier)
        {
            return printConfigDAL.Enable(printType, delFlag, lastModifier);
        }

        #endregion

        #region QueryList(Page)

        /// <summary> 
        /// 获得打印配置数据列表(分页) 
        /// </summary> 
        /// <param name="model">分页数据</param> 
        /// <returns>打印配置分页数据</returns> 
        public PageResultModel<PrintConfigModel> GetModelListForPage(QueryPrintConfigParam model)
        {
            DataSet ds = printConfigDAL.GetListForPage(model);
            List<PrintConfigModel> list = DataTableToList(ds.Tables[0]);
            int total = Convert.ToInt32(ds.Tables[1].Rows[0]["COUNT"]);
            PageResultModel<PrintConfigModel> result = new PageResultModel<PrintConfigModel>();
            result.total = total;
            result.rows = list;
            return result;
        }

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个打印配置实体 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns>打印配置实体</returns> 
        public PrintConfigEntity GetModel(string printType)
        {

            return printConfigDAL.GetModel(printType);
        }

        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该打印配置记录 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns></returns> 
        public bool Exists(string printType, int? id = null)
        {
            return printConfigDAL.Exists(printType, id);
        }

        #endregion

        #region Common

        /// <summary> 
        /// 获得打印配置数据列表 
        /// </summary> 
        private List<PrintConfigModel> DataTableToList(DataTable dt)
        {
            List<PrintConfigModel> modelList = new List<PrintConfigModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PrintConfigModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PrintConfigModel();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    model.printType = dataRow["printType"].ToString();
                    model.printTypeName = dataRow["printTypeName"].ToString();
                    model.printerName = dataRow["printerName"].ToString();
                    model.printTemplete = dataRow["printTemplete"].ToString();
                    model.printTempleteName = dataRow["printTempleteName"].ToString();
                    model.printArea = dataRow["printArea"].ToString();
                    model.printAreaName = dataRow["printAreaName"].ToString();
                    if (dataRow["delFlag"].ToString() != "")
                    {
                        if ((dataRow["delFlag"].ToString() == "1") || (dataRow["delFlag"].ToString().ToLower() == "true"))
                        {
                            model.delFlag = true;
                        }
                        else
                        {
                            model.delFlag = false;
                        }
                    }
                    model.creator = dataRow["creator"].ToString();
                    if (dataRow["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dataRow["createTime"].ToString());
                    }
                    model.lastModifier = dataRow["lastModifier"].ToString();
                    if (dataRow["lastModifyTime"].ToString() != "")
                    {
                        model.lastModifyTime = DateTime.Parse(dataRow["lastModifyTime"].ToString());
                    }



                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

    }
}
