using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;
using WIP_IDAL;
using WIP_DALFactory;
using System.Net.Mail;
using SysManager.Common.Utilities;

namespace WIP_BLL
{
    public class Mail : IMail
    {
        private string namespaceName = "WIP_BLL.Mail";
        private string _categoryId = MailCategory.缺省;//默认是缺省的邮件类型
        private string _recipientsAddressRange = "";
        private MailBaseData _MailBaseData = null;

        public Mail(string categoryId)
        {
            _categoryId = categoryId;
        }

        public void MailSending(string MailSubject, string Describe, string File_Path)
        {
            #region 数据获取

            try
            {
                _recipientsAddressRange = MailRuleBLL.GetInstance().GetMailPersonListRetStr(_categoryId);

                List<MailBaseData> mailBaseDataList = WIPDataAccess.CreateDAL<ICommonDAL>("CommonDAL").GetMailBaseData();
                if (mailBaseDataList == null || mailBaseDataList.Count == 0)
                {
                    throw new Exception("没有找到邮箱基础数据");
                }
                if (mailBaseDataList.Count > 1)
                {
                    throw new Exception(string.Format("配置的邮箱基础数据大于1条，请检查数据!查到的条数是{0}条", mailBaseDataList.Count.ToString()));
                }
                _MailBaseData = mailBaseDataList[0];
            }
            catch (Exception ex)
            {
                IDictionary<string, object> logDict = new Dictionary<string, object>();
                logDict.Add("MailSubject", MailSubject);
                logDict.Add("Describe", Describe);

                ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<IDictionary<string, object>>(namespaceName, "MailSending", logDict, "", "");
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);
            }


            #endregion

            if (string.IsNullOrEmpty(_recipientsAddressRange) || _MailBaseData == null) // 如果基础数据没有获取到，就不发邮件
                return;
            this.PostMail(_MailBaseData, _recipientsAddressRange, MailSubject, Describe.ToString(), "");
        }

        private void PostMail(MailBaseData _MailBaseData, string recipientsAddressRange,
            string MailSubject, string Describe, string File_Path)
        {
            MailSubject = MailSubject + " (" + WIPCommon.ForamtCurDateTime() + ")";//任务名称
            Describe += "<br/><br/>";
            Describe += "消息来自主机：" + WIPCommon.GetHostName() + "<br/>";
            Describe += "主机发生时间：" + WIPCommon.ForamtCurDateTime() + "<br/>";
            IDictionary<string, object> logDict = new Dictionary<string, object>();
            logDict.Add("recipientsAddressRange", recipientsAddressRange);
            logDict.Add("MailSubject", MailSubject);
            logDict.Add("Describe", Describe);
            logDict.Add("File_Path", File_Path);
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<IDictionary<string, object>>(namespaceName, "MailSending", logDict, "", "");
            try
            {
                if (File_Path == null)
                    File_Path = "";

                SMTPHelper.MailSending(_MailBaseData, _recipientsAddressRange, MailSubject, Describe.ToString(), "");
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);
            }
        }
    }
}
