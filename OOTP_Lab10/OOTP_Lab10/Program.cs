using System;
using System.Collections.Generic;
using OOTP_Lab10.Properties;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace OOTP_Lab10
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            
            var web0 = "webhelp.org";
            var web1 = "network.net";
            var web2 = "geras.com";
            var web3 = "hypertrast.me";
            var web4 = "online.gb";
            var web5 = "fast.live";
            var storeCollection = new WebStoreCollection<string>(new List<string>()) {web0, web1, web2};
            
            storeCollection.Display += storeCollection.DisplayInLine;
            
            storeCollection.Add(web3);
            storeCollection.Add(web4);
           
            if(storeCollection.Remove(web3))
                Console.WriteLine($"Удален элемент {web3}");
            
            storeCollection.DisplayInLine();
            
            var index = storeCollection.IndexOf(web2);
            if(index != -1)
                Console.WriteLine($"Элемент {web2} найден, его индекс {index}");
            
            /////// 2 ////////
            var concdict = new ConcurrentDictionary<int, string>();
            Console.WriteLine($"Строка добавлена или обновлена: {concdict.GetOrAdd(1, web5)}");
            Console.WriteLine(concdict.TryAdd(2, web0) ? "Элемент добавлен" : "Элемент с таким ключом уже есть");
            Console.WriteLine(concdict.TryAdd(7, web1) ? "Элемент добавлен" : "Элемент с таким ключом уже есть");
            Console.WriteLine(concdict.TryAdd(9, web2) ? "Элемент добавлен" : "Элемент с таким ключом уже есть");
            Console.WriteLine(concdict.TryAdd(12,web3) ? "Элемент добавлен" : "Элемент с таким ключом уже есть");
            Console.WriteLine(concdict.TryAdd(12,web5) ? "Элемент добавлен" : "Элемент с таким ключом уже есть");
            
            concdict.AddOrUpdate(12, web3, (i, s) => web5);
            concdict.AddOrUpdate(5, web3, (i, s) => web4);

            
            foreach (var variable in concdict)
            {
                Console.WriteLine($"Ключ:{variable.Key.ToString()} Значение: {variable.Value}");
            }

            string value;
            Console.WriteLine(concdict.TryRemove(100, out value) ? $"Элемент {value} удален" : "Элемент с таким ключом не найден");
            Console.WriteLine(concdict.TryRemove(2, out value)   ? $"Элемент {value} удален" : "Элемент с таким ключом не найден");
            
            var linkedString = new LinkedList<string>();

            foreach (var variable in concdict)
            {
                linkedString.AddLast(variable.Value);
            }
            
            Console.Write("LinkedList: ");
            foreach (var variable in linkedString)
            {
                Console.Write($"{variable} ");
            }
            Console.WriteLine();
            Console.WriteLine(linkedString.Contains(web1) ? $"Элемент {web1} найден" : "Элемент с таким ключом не найден");
            Console.WriteLine(linkedString.Contains(web0) ? $"Элемент {web0} найден" : "Элемент с таким ключом не найден");
            
            //// 3 /////
            ObservableCollection<string> observableString = new ObservableCollection<string>();
            observableString.CollectionChanged += ObservableStringEvent;
            observableString.Add(web0);
            observableString.Add(web1);
            observableString.Add(web2);
            observableString.Remove(web2);
        }
        
        private static void ObservableStringEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:       
                    string newString = e.NewItems[0] as string;
                    Console.WriteLine($"Добавлена новая строка: {newString}");
                    break;
                
                
                case NotifyCollectionChangedAction.Remove:
                    string oldString = e.OldItems[0] as string;
                    Console.WriteLine($"Удалена строка: {oldString}");
                    break;
            }
        }
    }
}