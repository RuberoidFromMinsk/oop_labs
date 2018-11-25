using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9fix
{
    partial class Program
    {   
        static void Main(string[] args)
        {
            Game gamer_1 = new Game(100);
            Game gamer_2 = new Game(150);
            gamer_1.Damage += (x) =>
            {
				x.Health -= 2;
            };
            gamer_1.Heal += (x) =>
            {
                x.Health += 2;
            };
            gamer_2.Damage += (x) =>
            {
                x.Health -= 2;
            };
            gamer_2.Heal += (x) =>
            {
                x.Health += 2;
            };
			gamer_1.HealthUp(gamer_2);
			gamer_2.HealthDown(gamer_1);
			Console.WriteLine("Игрок 1: " + gamer_1.Health + " || Игрок 2: " + gamer_2.Health);

			Func<string, string> s = DeleteCommas;

            string str = "hello, world, www";
            str = s(str);
            s = UpperCase;
            str = s(str);
			s = DeleteProbel;
            str = s(str);
			s = DeleteLetterL;
            str = s(str);

            Action<string> st = AddPoint;
            st(str);

			Console.ReadKey();
        }
    }
}
//Operation del = Add;
//Operation del2 = new Operation(Add);