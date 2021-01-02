using System;
using System.IO;
using System.Text;
using OOTP_Lab12.Properties;

namespace OOTP_Lab12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter outFile = new StreamWriter("..\\..\\out.txt", false,System.Text.Encoding.Default);
            Reflector reflector  = new Reflector();
            Car car1 = new Car(60, "Volkswagen");
            //a. Определение имени сборки, в которой определен класс;
            outFile.WriteLine("a. Определение имени сборки, в которой определен класс;");
            Console.WriteLine(reflector.GetNameClass(typeof(Car)));
            Console.WriteLine(reflector.GetNameClass(typeof(User)));
            outFile.WriteLine(reflector.GetNameClass(typeof(Car)).ToString());
            outFile.WriteLine(reflector.GetNameClass(typeof(User)).ToString());
            
            //b. есть ли публичные конструкторы;
            outFile.Write("b. есть ли публичные конструкторы: ");
            Console.Write("b. есть ли публичные конструкторы: ");
            Console.WriteLine(reflector.getCostructor(typeof(Car)));
            Console.WriteLine(reflector.getCostructor(typeof(User)));
            outFile.Write("количество публичных конструкторов: ");
            Console.Write("количество публичных конструкторов: ");
            outFile.WriteLine(reflector.GetConstructorsLenght(typeof(Car)));
            outFile.WriteLine(reflector.GetConstructorsLenght(typeof(User)));
            Console.WriteLine(reflector.GetConstructorsLenght(typeof(Car)));
            Console.WriteLine(reflector.GetConstructorsLenght(typeof(User)));
            
            //c. извлекает все общедоступные публичные методы класса (возвращает IEnumerable<string>);
            outFile.WriteLine("c. извлекает все общедоступные публичные методы класса ");
            Console.WriteLine("c. извлекает все общедоступные публичные методы класса ");
            var methods = reflector.GetAllMetods(typeof(Car));
            var methodsuser = reflector.GetAllMetods(typeof(User));
                foreach (var user in methodsuser)
                foreach (var method in methods)
                {
                    outFile.WriteLine(method);
                    Console.WriteLine(method);
                }
                foreach (var method in methods)
                {
                 outFile.WriteLine(method);
                 Console.WriteLine(method);
                }
            //e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);
            outFile.WriteLine("e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);");
            Console.WriteLine("e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);");
            var interfaces = reflector.GetAllInterfaces(typeof(Car));
            foreach (var inInterface in interfaces)
            {
                outFile.WriteLine(inInterface);
                Console.WriteLine(inInterface);
            }
            var interfacesUser = reflector.GetAllInterfaces(typeof(User));
            foreach (var inInterface in interfacesUser)
            {
                outFile.WriteLine(inInterface);
                Console.WriteLine(inInterface);
            }
            
            //f. выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра
            //(имя класса передается в качестве аргумента);
            outFile.WriteLine("f.  выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра");
            Console.WriteLine("f.  выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра");
            var type = "Int32";// Console.ReadLine();
            var parametres = reflector.GetTypesMethodsArg(typeof(Car),type);
            var parametresuser = reflector.GetTypesMethodsArg(typeof(User),type);
            foreach (var parametre in parametres)
            {
                outFile.WriteLine(parametre);
                Console.WriteLine(parametre);
            }
            foreach (var parametre in parametresuser)
            {
                outFile.WriteLine(parametre);
                Console.WriteLine(parametre);
            }
            /*g. метод Invoke, который вызывает метод класса, при этом значения
            для его параметров необходимо 1) прочитать из текстового файла
            (имя класса и имя метода передаются в качестве аргументов) 2)
            сгенерировать, используя генератор значений для каждого типа.
            Параметрами метода Invoke должны быть : объект, имя метода,
            массив параметров.*/
            outFile.WriteLine(car1.GetType());
            outFile.Close();
            var fin = new StreamReader("..\\..\\new.txt",System.Text.Encoding.Default);
            string classname = fin.ReadLine();
            string paramname = fin.ReadLine();
            Random random = new Random();
            reflector.Invoke(car1, paramname, new object[]{random});
            var a =  reflector.Create(typeof(Car));
            Console.WriteLine(typeof(Car));

        }
    }
}