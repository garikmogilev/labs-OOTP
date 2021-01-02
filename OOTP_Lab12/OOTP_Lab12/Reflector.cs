using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace OOTP_Lab12
{
    public class Reflector
    {
        public string GetNameClass(Type T)
        {
            return T.Assembly.FullName;
        }

        public bool getCostructor(Type T)
        {
            ConstructorInfo[] constructorInfo = T.GetConstructors();
            return constructorInfo.Length != 0 ? true : false;
        }

        public int GetConstructorsLenght(Type T)
        {
            return T.GetConstructors().Length;
        }

        public IEnumerable<string> GetAllMetods(Type T)
        {
            var methods = from method in T.GetMethods() select method.Name;
            return methods;
        } 
        public IEnumerable<string> GetAllInterfaces(Type T)
        {
            var interfaces = from method in T.GetInterfaces() select method.Name;
            return interfaces;
        }
        public IEnumerable<string> GetTypesMethodsArg(Type T, string type)
        {
            var args = T.GetMethods();
            var resultMethods = from arg in args where 
                (from parametre in arg.GetParameters() select parametre.ParameterType.Name).Contains(type) select arg.Name;
            return resultMethods;
        }
        public void Invoke(object nameclass, string method, object[] array)
        { 
            Type myType = nameclass.GetType();
            object obj = Activator.CreateInstance(myType);
            MethodInfo meth = myType.GetMethod(method);
            Console.WriteLine(nameclass.GetType());
           
            MethodInfo methodInfo = nameclass.GetType().GetMethod(method);
            methodInfo?.Invoke(nameclass, array);
        }

        public object Create(Type T)
        {
            return Activator.CreateInstance(T);
        }
    }
}