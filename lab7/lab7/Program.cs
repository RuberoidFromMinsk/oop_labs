using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
	public interface IGenericInterface<T>
    {
        void Add(T element);
        void Delete(T element);
        void Show();
    }

	interface IFileWorker<T>
    {
        void ReadFromFile(string filePath);
        void WriteToFile(string fileName);
    }

	public class CollectionType<T> : IGenericInterface<T>, IFileWorker<T> where T : class
    {

        private List<T> _collection;

        public List<T> Collection { get => _collection; set => _collection = value; }

        public CollectionType()
        {
            Collection = new List<T>();
        }

        public void Add(T element)
        {
            Collection.Add(element);
        }



        public void Delete(T element)
        {
            Collection.Remove(element);
        }



        public void Show()
        {
            foreach (var item in _collection)
            {
                Console.WriteLine(item);
            }
        }

        public void ReadFromFile(string filePath)
        {
            using (var sr = new StreamReader(filePath, false))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

        public void WriteToFile(string fileName)
        {
            using (var sr = new StreamWriter(fileName, false))
            {
                sr.WriteLine(this);
            }
        }

        public override string ToString()
        {
            var res = " ";

            foreach (var item in Collection)
            {
                res += item + " ";
            }

            return $"Collection property is : {res}";
        }
    }

	class UserClass
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }
        
        public UserClass(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Name : {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
			const string FileName = @"/home/andrew/Desktop/info.txt";

            var user1 = new UserClass("Andrew");
            var user2 = new UserClass("Dima");

            var collection1 = new CollectionType<UserClass>();

            ((IGenericInterface<UserClass>)collection1).Add(user1);

            ((IGenericInterface<UserClass>)collection1).Add(user2);

            ((IGenericInterface<UserClass>)collection1).Show();

            ((IGenericInterface<UserClass>)collection1).Delete(user1);

            ((IGenericInterface<UserClass>)collection1).Show();

            //var collection1 = new CollectionType<int>();

            //((IGenericInterface<int>)collection1).Add(1);
            //((IGenericInterface<int>)collection1).Add(2);
            //((IGenericInterface<int>)collection1).Show();
            //collection1.Add(2);

            //IGenericInterface<int> collectionForTest = collection1;

            //collectionForTest.Add(1);
            ///collectionForTest.Add(2);
            //collectionForTest.Show();
            //collectionForTest.Delete(1);
            //collectionForTest.Show();

            //var collection2 = new CollectionType<string>();

            //IGenericInterface<string> collectionForTest2 = collection2;

            //collectionForTest2.Add("Dima");
            //collectionForTest2.Add("Sasha");
            //collectionForTest2.Show();
            //collectionForTest2.Delete("Sasha");
            //collectionForTest2.Show();

            try
            {
				((IGenericInterface<UserClass>)collection1).Add(user1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.HelpLink, e.Message);


            }
            finally
            {
                Console.WriteLine("Finally");
            }

          

            collection1.WriteToFile(FileName);
            collection1.ReadFromFile(FileName);

			Console.ReadKey();
        }
    }
}
