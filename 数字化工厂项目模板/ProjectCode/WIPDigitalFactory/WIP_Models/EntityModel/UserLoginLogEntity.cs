/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_Models.EntityModel
 * FileName：UdtWip_UserLoginLog
 * CurrentYear：2019
 * CurrentTime：2019/7/24 11:22:32
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/24 11:22:32 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 用户登录记录
    /// </summary>
    public class UserLoginLogEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? loginTime { get; set; }

        /// <summary>
        /// 登出时间
        /// </summary>
        public DateTime? logoutTime { get; set; }


        /// <summary>
        /// 删除标记
        /// </summary>
        public bool? delFlag { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string lastModifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? lastModifyTime { get; set; }
    }
}
