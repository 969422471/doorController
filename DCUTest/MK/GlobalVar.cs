using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCUTest.MK
{
    class GlobalVar
    {

        private static class Nested
        {
            public static GlobalVar instance = new GlobalVar();
        }

        /**
         * 获取DataTransceiverOfMVB对象
         * @return DataTransceiverOfMVB
         */

        public static GlobalVar getInstance()
        {
            return Nested.instance;
        }

        public static  Dictionary<string, string> diMap = new Dictionary<string, string>();
        public static Dictionary<string, string> doMap = new Dictionary<string, string>();
        private static byte[] m_SendCMD = new byte[8];
        //private static int Index = 0;

        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="msg"></param>
        public delegate void HandleInterfaceUpdataDelegate(byte[] msg);
        private HandleInterfaceUpdataDelegate interfaceUpdataHandle;

        public bool lj = false;
        /// <summary>
        /// 查询
        /// </summary>
        public void InQuire()
        {
            //获取当前界面中所有地址

            try
            {

                SendCMD(1, 0, RelayType.INQUIRE);
                SendCMD(2, 0, RelayType.INQUIRE);
                SendCMD(3, 0, RelayType.INQUIRE);
            }
            catch { }
        }
        /// <summary>
        /// 设备启动函数
        /// </summary>
        public void PowerON(Int16 Address, int uLine)
        {
            SendCMD(Address, uLine, RelayType.ON);
        }
        /// <summary>
        /// 设备关闭
        /// </summary>
        public void PowerOFF(Int16 Address, int uLine)
        {
            SendCMD(Address, uLine, RelayType.OFF);
        }
        /// <summary>
        /// 向指定端口发送指令
        /// </summary>
        /// <param name="_Address"></param>
        /// <param name="_Line"></param>
        /// <param name="_type"></param>
        private void SendCMD(short _Address, int _Line, RelayType _type)
        {
            byte[] tempCMD = new byte[8];
            tempCMD = Relay.CreateCMD(_Address, _Line, _type);
            clientSendMsg(tempCMD);

        }
        //写一个发送信息到服务端的方法
        public void clientSendMsg(byte[] txtCMsg)
        {
            //获取文本框txtCMsg输入的内容
            //string strClientSendMsg = txtCMsg;
            //将输入的内容字符串转换为机器可以识别的byte数组
            //byte[] arrClientSendMsg = System.Text.Encoding.UTF8.GetBytes(strClientSendMsg);
            //调用客户端套接字发送byte数组
            socketClient.Send(txtCMsg);
        }
        /// <summary> 
        /// 

        private void SetDevState(byte[] statemsg)
        {
            // 遍历1到8个按钮的状态
            int i = 1;
            for (i = 1; i <= 8; i++)
            {
                if (statemsg[1] == 1)
                {                 
                    doMap["OneBtn_ItemDO" + i] = Relay.GetState(statemsg, i)+"";
                    diMap["OneBtn_ItemDI" + i] = Relay.GetInputState(statemsg, i) + "";    
                }

                if (statemsg[1] == 2)
                {
                    doMap["TwoBtn_ItemDO" + i] = Relay.GetState(statemsg, i) + "";
                    diMap["TwoBtn_ItemDI" + i] = Relay.GetInputState(statemsg, i) + "";
                }
                if (statemsg[1] == 3)
                {
                    doMap["ThrBtn_ItemDO" + i] = Relay.GetState(statemsg, i) + "";
                    diMap["ThrBtn_ItemDI" + i] = Relay.GetInputState(statemsg, i) + "";
                   
                }

            }
        }


        /// <summary>
        ///  初始化dido
        ///  zqh 2018.08.26
        /// </summary>
        public void initMap() {

            doMap.Clear();
            diMap.Clear();
            for (int i=1;i<9;i++) {
       
                doMap.Add("OneBtn_ItemDO" + i,"0");
                doMap.Add("TwoBtn_ItemDO" + i, "0");
                doMap.Add("ThrBtn_ItemDO" + i, "0");

                diMap.Add("OneBtn_ItemDI" + i, "0");
                diMap.Add("TwoBtn_ItemDI" + i, "0");
                diMap.Add("ThrBtn_ItemDI" + i, "0");
            }
        }


        //终止
        private void Abort()
        {
            //终止线程
            threadClient.Abort();
            //关闭socket
            socketClient.Close();
        }

        private void timer_INQUIRE_Tick(object sender, EventArgs e)
        {
            InQuire();
        }
        /// <summary>
        /// 网络连接部分
        /// </summary>
        private Socket socketClient = null;
        Thread threadClient = null;
        public bool Connect(string IP, string Port)
        {
            // 初始化map
            initMap();
            try
            {
                //定义一个套字节监听  包含3个参数(IP4寻址协议,流式连接,TCP协议)
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddress = IPAddress.Parse(IP);
                //将获取的ip地址和端口号绑定到网络节点endpoint上
                IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse(Port));
                //注意: 这里是客服端套接字连接到Connect网络节点 不是Bind
                socketClient.Connect(endpoint);
                //new一个新线程 调用下面的接受服务端发来信息的方法RecMsg
                threadClient = new Thread(RecMsg);
                //将窗体线程设置为与后台同步
                threadClient.IsBackground = true;
                //启动线程
                threadClient.Start();
                interfaceUpdataHandle = new HandleInterfaceUpdataDelegate(SetDevState);
                lj = true; // 链接成功
                return true;
            }
            catch (Exception err)
            {
                lj = false; // 链接失败
                return false;
                //MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        ////网络连接 消息接收
        //定义一个接受服务端发来信息的方法
        void RecMsg()
        {
            while (true) //持续监听服务端发来的消息
            {
                //客户端 定义一个1M的byte数组空间
                byte[] arrRecMsg = new byte[8];
                //定义byte数组的长度
                int length = socketClient.Receive(arrRecMsg);
                if (length == 8)
                {
                    SetDevState(arrRecMsg);
                    // 实际上使用线程代理在调用 SetDevState的函数，相当SetDevState(arrRecMsg)，但是不能用SetDevState(arrRecMsg);
                  //  this.Invoke(interfaceUpdataHandle, arrRecMsg);
                }
                //arrRecMsg 接收到的物理数据
                //将byte数组转换为人可以看懂的字符串
                //string strRecMsg = System.Text.Encoding.UTF8.GetString(arrRecMsg, 0, length);

            }
        }
    }
}
