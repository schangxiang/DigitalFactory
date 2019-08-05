namespace WIP_Models
{
    /// <summary>
    /// 邮箱内容类
    /// </summary>
    public class DescribeModel
    {
        /// <summary>
        /// 异常信息
        /// </summary>
        public string exceptionMsg { get; set; }

        /// <summary>
        /// 异常的json数据
        /// </summary>
        public string exceptionData { get; set; }

        /// <summary>
        /// 源数据的json数据
        /// </summary>
        public string sourceData { get; set; }

    }
}
