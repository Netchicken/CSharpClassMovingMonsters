using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    class John : Punter
    {
        public John()
        {
            PunterName = "John";
            Monster = "";
            Cash = 100;
            MyColor = Color.Aquamarine;
            FavoriteDrink = "tea";
        }


    }
}
