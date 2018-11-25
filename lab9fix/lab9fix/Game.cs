using System;
namespace lab9fix
{
	public class Game
    {
        private int _health;

        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public delegate void e(Game x);
        public event e Damage;
        public event e Heal;


        public Game(int h)
        {
            Health = h;
        }
        public void HealthDown(Game x)
        {
            Damage(x);
        }
        public void HealthUp(Game x)
        {
            Heal(x);
        }
    }

}
