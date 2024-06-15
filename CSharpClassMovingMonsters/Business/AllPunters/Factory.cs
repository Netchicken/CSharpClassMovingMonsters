using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClassMovingMonsters.Business.AllPunters
{
    public static class Factory
    {
        //Descides which class we want to instantiate
        //1,2,3
        public static Punter GetAPunter(int id)
        {
            switch (id)
            {
                case 0:
                    return new Howard();
                case 1:
                    return new Susan();
                case 2:
                    return new John();

                default: return null;

            }

        }

    }
}
