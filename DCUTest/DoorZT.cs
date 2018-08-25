using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace DCUTest
{
    class DoorZT
    {

        // 初始化模块
        // 恢复模块的初始化状态
        public void setMKBegain() {

        }

        // 打开门
        public int  OpenDoor()
        {

            return 0;
        }

        // 关闭门
        public int closeDoor()
        {

            return 0;
        }

        // 返回三种状态
        // 0 表示门关闭
        // 1 表示门打开
        // 2 表示门在中间位置
        // 3 表示门在运动中 该功能通过门点击动作继电器反馈
        public int getDoor()
        {

            return 0;
        }

        // 设置Do为1
        public int setOne(int address,int point)
        {

            return 0;
        }
        // 设置Do为0
        public int setZero(int address, int point)
        {

            return 0;
        }

        // 
        // 设置Do为0
        public Dictionary<string,string> getDI2Map(int address, int point)
        {
            Dictionary<string, string> map =null ;
            return map;
        }

    }
}
