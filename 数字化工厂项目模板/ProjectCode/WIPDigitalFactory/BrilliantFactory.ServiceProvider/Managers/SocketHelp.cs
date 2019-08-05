using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.ServiceProvider.Managers
{
    public class SocketHelp
    {

        private string ServerIP; //IP
        private int port;   //端口
        private bool isExit = false;
        public TcpClient client;
        public BinaryReader br;
        public BinaryWriter bw;

        public SocketHelp(string serverIpAddress, int iPort)
        {
            ServerIP = serverIpAddress;
            port = iPort;
        }

        /// <summary>
        /// 打开socket连接
        /// </summary>
        public string Connection()
        {
            try
            {
                isExit = false;
                if (client != null && client.Connected == true)
                {
                    return null;
                }
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ServerIP), port);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void SetConnection()
        {
            //获取网络流
            NetworkStream networkStream = client.GetStream();
            //将网络流作为二进制读写对象
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
        }


        /// <summary>
        /// 写入PLC点位
        /// </summary>
        /// <param name="pointaddress">点位地址</param>
        /// <param name="pointvalue">点位值</param>
        /// <returns></returns>
        public string SendData(string pointaddress, string pointvalue)
        {
            if (string.IsNullOrEmpty(pointaddress) == false && string.IsNullOrEmpty(pointvalue) == false)
            {
                string conmgs = Connection();
                if (conmgs == null)
                {
                    try
                    {
                        SetConnection();
                        string mgs = pointaddress + "&" + pointvalue;
                        SendMessage(mgs);
                        //接收服务器回写的信息
                        return ReceiveData();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return conmgs;
                }
            }
            else
            {
                return "请输入点位名称和点位值！";
            }
        }
        public string ReceiveData()
        {
            string receiveString = null;
            while (isExit == false)
            {
                try
                {
                    //从网络流中读出字符串
                    //此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    receiveString = br.ReadString();
                    //服务器
                    if (receiveString == "serverexist")
                    {
                        closesocket();
                        return "serverexist";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(receiveString) == false)
                        {
                            if (receiveString == "succee")
                            {
                                return null;
                            }
                            else
                            {
                                return receiveString;
                            }
                        }
                    }

                }
                catch
                {
                    if (isExit == false)
                    {
                        return "与服务器失去连接";
                    }
                    break;
                }
            }
            return "请检查网络连接！";
        }

        private void closesocket()
        {

            isExit = true;
            br.Close();
            bw.Close();
            client.Close();
        }

        /// <summary>
        /// 发送数
        /// </summary>
        /// <param name="mgs">发送数据</param>
        /// <returns></returns>
        public string SendData(string mgs)
        {
            if (string.IsNullOrEmpty(mgs) == false)
            {
                string conmgs = Connection();
                if (conmgs == null)
                {
                    try
                    {
                        SetConnection();
                        SendMessage(mgs);
                        //接收服务器回写的信息
                        return ReceiveData();

                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return conmgs;
                }
            }
            else
            {
                return "请输入要发送的信息";
            }
        }


        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        /// <param name="message"></param>
        private bool SendMessage(string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                bw.Write(message);
                bw.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void CloseConnect()
        {
            SendMessage("clientexist");
            closesocket();
        }

    }
}
