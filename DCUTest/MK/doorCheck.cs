using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCUTest.MK
{
    class doorCheck
    {
        /// <summary>
        /// 获取门板现在的状态
        /// 需要返回门的现在状态
        /// 0 表示关闭
        /// 1表示门关闭
        /// 2表示门打开
        /// 通过获取门控器完全打开，门控器完全断开开关的状态 
        /// 具体通过电路图的状态获取
        /// </summary>
        public int getDoorCheck() {
            int back = 0;
            return back;
        }


        /// <summary>
        /// 门系统打开状态下的初始化功能
        /// 根据门系统功
        /// </summary>
        public void openDoorInit() {

        }

        /// <summary>
        /// 门系统关闭状态下的初始化功能
        /// 判断门系统状态后执行
        /// </summary>
        public void closeDoorInit()
        {

        }

        /// <summary>
        /// 关门逻辑
        /// 要求执行关门动作判断是否完完成关门动作
        /// </summary>
        public bool closeDoor() {
            bool bl =false;
            return bl;
        }


        /// <summary>
        /// 判断指定设备的状态
        /// 通过搜索指定设备判断设备时候在线
        /// 原则为发送查询指令以后 500ms 内没有设备相应即为设备不在线
        /// </summary>
        public bool  checkDevice(string address) {
            bool bl = false;
            return bl;
        }


         /// <summary>
         ///  打开门控器
         /// </summary>
         /// <param name="doorCL"></param>
        public void openDoorController(int doorCL) {

        }
        
    }
}
