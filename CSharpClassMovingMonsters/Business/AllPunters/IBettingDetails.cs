using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    //forces you to be consistant aqcross all of your classes
    interface IBettingDetails
    {
        int Won { get; set; }
        int Lost { get; set; }

        //method
        int TotalBets();



    }
}
