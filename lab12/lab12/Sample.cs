using System;
namespace lab12
{
	//lab5
	public abstract class Aviation
    {
        protected string _name;

        public Aviation(string _name)
        {
            this._name = _name;
        }


        public virtual void GetName()
        {
            Console.WriteLine("Name:" + _name);
        }
        public abstract int GetCapacity();
        public abstract int GetCarrying();
        public abstract int GetDistance();
        public abstract void Display();
    }
    public class PassangerPlane : Aviation
    {
        public int passangerCapacity;
		public int age;

        public int Age
		{
			get
			{
				return age;
			}
		}

		public int PassangerCapacity
        {
            get
            {
                return age;
            }
        }

        public PassangerPlane(int passangerCapacity, string _name) : base(_name)
        {
            this.passangerCapacity = passangerCapacity;
        }

        public override void GetName()
        {
            Console.WriteLine($"Passanger plane: {_name}");
        }

        public override int GetCapacity()
        {
            return passangerCapacity;
        }

        public override int GetCarrying()
        {
            throw new NotImplementedException();
        }

        public override int GetDistance()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;
            PassangerPlane c = (PassangerPlane)obj;
            return c.GetCapacity() == GetCapacity();

        }

        public override void Display()
        {
            Console.WriteLine($"Passanger capacity: {passangerCapacity}   Name:{_name} Type: {this.GetType()}");
        }

        public void Method_1(string a)
        {

        }

        public void Method_2(string a)
        {

        }
    }

   

    interface IName1
    {
        void GetName();
    }
    interface IName2
    {
        void GetName();
    }
    sealed class TU134 : PassangerPlane, IName1, IName2
    {
        int age { get; set; }
        static int counter = 0;

        public TU134(int age, int passangerCapacity, string _name) : base(passangerCapacity, _name)
        {
            this.age = age;
            counter++;
        }

        void IName1.GetName()
        {
            Console.WriteLine("I'm going to IName1");
        }
        void IName2.GetName()
        {
            Console.WriteLine("I'm going to IName2");
        }

        public override void Display()
        {
            Console.WriteLine($"Age: {age}   Passanger Capacity: {passangerCapacity}    Name: {_name}");
        }
    }
}
