namespace WIP_Models
{
    /// <summary>
    /// 邮箱实体类
    /// </summary>
    public class MailModel
    {
        /// <summary>
        /// 邮箱标题
        /// </summary>
        public string MailSubject { get; set; }

        /// <summary>
        /// 邮箱内容
        /// </summary>
        public DescribeModel Describe { get; set; }

        /// <summary>
        /// 邮箱附件
        /// </summary>
        public string File_Path { get; set; }

    }

}
