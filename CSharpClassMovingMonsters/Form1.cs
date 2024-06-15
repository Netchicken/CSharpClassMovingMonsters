using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpClassMovingMonsters.Business.AllPunters;

namespace CSharpClassMovingMonsters
{
    public partial class Form1 : Form
    {
        //instantiate an array of punters and monster
        private Monster[] monster = new Monster[4];
        private string Winner;

        Punter[] myPunter = new Punter[3];
        Punter singlePunter = new Howard();

        public Form1()
        {
            InitializeComponent();
            //give the punters and monsters some starting values
            monster[0] = new Monster { Length = 0, myPB = pb1, Name = "Agor" };
            //bind the picturebox to the image
            monster[0].myPB.BackgroundImage = Resource1.Agor;
            monster[1] = new Monster { Length = 0, myPB = pb2, Name = "Igor" };
            monster[1].myPB.BackgroundImage = Resource1.Igor;
            monster[2] = new Monster { Length = 0, myPB = pb3, Name = "Ogor" };
            monster[2].myPB.BackgroundImage = Resource1.Ogor;
            monster[3] = new Monster { Length = 0, myPB = pb4, Name = "Ugor" };
            monster[3].myPB.BackgroundImage = Resource1.Ugor;


            SetUpThePunters();

          //  SinglePunterSetupWithFactory();


            //myPunter[0] = new Punter { Bet = 0, Cash = 50, Monster = "", PunterName = "Howard", LabelWinner = lblWinner, MyColor = Color.BlueViolet};
            //myPunter[1] = new Punter { Bet = 0, Cash = 50, Monster = "", PunterName = "John", LabelWinner = lblWinner, MyColor = Color.Crimson };
            //myPunter[2] = new Punter { Bet = 0, Cash = 50, Monster = "", PunterName = "Susan", LabelWinner = lblWinner, MyColor = Color.DarkGreen };

        }

        //sets up the punters
        public void SetUpThePunters()
        {
            for (int i = 0; i < 3; i++)
            {
                myPunter[i] = Factory.GetAPunter(i);
                myPunter[i].LabelWinner = lblWinner;


            }


        }

        //public void SinglePunterSetupWithFactory()
        //{
        //    singlePunter = Factory.GetAPunter(1);

        //    var name = singlePunter.PunterName;
        //}



        //run the race
        private void btnStart_Click(object sender, EventArgs e)
        {
            RunRace();
        }

        private void RunRace()
        {
            bool end = false;
            var myrnd = new Random();

            while (end != true)
            {
                int distance = Form1.ActiveForm.Width - pb1.Width - 20;

                for (int i = 0; i < 4; i++)
                {
                    Application.DoEvents();
                    monster[i].myPB.Left += myrnd.Next(1, 5);

                    if (monster[i].myPB.Left > distance)
                    {
                        end = true;
                        Winner = monster[i].Name;
                        //  this.Text = Winner + " " + i.ToString();

                        FindTheWinner();
                    }
                }
            }
        }

        private void FindTheWinner()
        {
            lblWinner.Text = string.Empty;

            for (int j = 0; j < 3; j++)
            {
                if (myPunter[j].Monster == Winner)
                {
                    myPunter[j].Cash += myPunter[j].Bet;
                    myPunter[j].LabelWinner.ForeColor = Color.Black;

                    Form1.ActiveForm.BackColor = myPunter[j].MyColor;
                    myPunter[j].LabelWinner.Text += Winner + " and " + myPunter[j].PunterName + " won  and now has " + myPunter[j].Cash;
                }
                else
                {
                    myPunter[j].Cash -= myPunter[j].Bet;

                    myPunter[j].LabelWinner.Text += " " + myPunter[j].PunterName + " lost and now has " + myPunter[j].Cash + " ";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                monster[i].myPB.Left = 37;
                Winner = "Monsters Racing";
                // this.Text = Winner;
            }
        }

        private void btnBets_Click(object sender, EventArgs e)
        {
            //set some values for the bettors
            myPunter[0].Monster = "Agor";
            myPunter[1].Monster = "Ogor";
            myPunter[2].Monster = "Ugor";

            //how much have they bet?
            myPunter[0].Bet = 50;
            myPunter[1].Bet = 30;
            myPunter[2].Bet = 20;

            //myPunter[0].LabelWinner.ForeColor = Color.BlueViolet;
            //myPunter[1].LabelWinner.ForeColor = Color.Aquamarine;
            //myPunter[2].LabelWinner.ForeColor = Color.Crimson;


        }

        //click on the radiobutton to select a bettor
        private void AllRB_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton fakeRB = (RadioButton)sender;

            if (fakeRB.Checked == true)
            {
                //look for the anme of the person your clicked on 
                switch (fakeRB.Text)
                {
                    //instantiate that punter
                    case "Howard":
                        singlePunter = Factory.GetAPunter(0);
                        break;
                    case "Susan":
                        singlePunter = Factory.GetAPunter(1);
                        break;
                    case "John":
                        singlePunter = Factory.GetAPunter(2);
                        break;
                }

                SinglePunterSetup();
            }
        }
        public void SinglePunterSetup()
        {
            //set the value of the up down numeric
            udBet.Maximum = (decimal) singlePunter.Cash;
            udBet.Value = (decimal)singlePunter.Cash;
            SinglePunterCheckForBetValue();
            }

        private void udBet_ValueChanged(object sender, EventArgs e)
        {
            SinglePunterCheckForBetValue();
        }

        private void SinglePunterCheckForBetValue()
        {  
            //set the value of the bed the person has made
            singlePunter.Bet = (float) udBet.Value; 
            
            //long text check to see it works
            lblBettorName.Text = "My name is " + singlePunter.PunterName + " and I have $" + singlePunter.Cash + " to waste on the Monster. And I bet $" + singlePunter.Bet;
        }
    }
}
