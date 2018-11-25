using System;

namespace lab12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			PassangerPlane plane = new PassangerPlane(100, "Plane_1");
			TU134 tU = new TU134(15, 100, "New TU134");

            Reflector.All(plane.GetType());

			Reflector.ShowAllMethods<PassangerPlane>(plane);
			Reflector.ShowAllFields<PassangerPlane>(plane);
			Reflector.ShowAllProperties<PassangerPlane>(plane);
			Reflector.ShowAllInterfaces<TU134>(tU);

            string myStr="12345";
            Reflector.FindMethodsByParam(plane.GetType(), myStr.GetType());

            Reflector.Method(plane.GetType(), "Equals");

			Console.ReadKey();
        }
    }
}
