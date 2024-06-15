using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpClassMovingMonsters
{
    class Monster
    {
        public string Name { get; set; }

        //How far the monster has travelled
        public int Length { get; set; }

        public PictureBox myPB { get; set; }

    }
}
