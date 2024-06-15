using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    class Howard : Punter
    {
        public Howard()
        {
            PunterName = "Howard";
            Monster = "";
            Cash = 20;
            MyColor = Color.SteelBlue;
        }

    }
}
