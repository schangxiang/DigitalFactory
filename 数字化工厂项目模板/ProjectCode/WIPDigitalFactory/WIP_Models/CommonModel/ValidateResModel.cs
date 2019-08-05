namespace WIP_Models
{
    /// <summary>
    /// 验证结果实体类
    /// </summary>
    public class ValidateResModel
    {
        /// <summary>
        ///  是否验证通过
        /// </summary>
        public bool IsValidate { get; set; }

        /// <summary>
        /// 验证提示结果
        /// </summary>
        public string ValidateMsg { get; set; }

    }
}
