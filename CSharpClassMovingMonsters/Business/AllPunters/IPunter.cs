using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    interface IPunter
    {

        string PunterName { get; set; }
        string Monster { get; set; }
        Single Cash { get; set; }
        Single Bet { get; set; }
        Label LabelWinner { get; set; }

        Color MyColor { get; set; }

        string FavoriteDrink { get; set; }

        int WildCard { get; set; }

    }
}
