using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    class Susan : Punter
    {
        //this runs first
        public Susan()
        {
            PunterName = "Susan";
            Monster = "";
            Cash = 50;
            MyColor = Color.DarkBlue;
        }

        public int Won { get; set; }
        public int Lost { get; set; }
        public int TotalBets()
        {
            return Won + Lost;
        }


    }
}
