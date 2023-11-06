using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Metot_Desing
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    public class LoggerFactory:ILoggerFactory // Fabrika Olarak Düşün Sana Hangi Loglmayı üretsin 
        {
            public ILogger CreateLoger()
            {
                return new HKloger();
            }
        }
        public class LoggerFactory2 : ILoggerFactory // Fabrika Olarak Düşün Sana Hangi Loglmayı üretsin 
        {
            public ILogger CreateLoger()
            {
                return new ZBloger();
            }
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLoger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class HKloger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with HKloger");
        }
    }
    public class ZBloger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ZBloger!!!!");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory) // Customer Çağırldığında bana bir Fabrika ver demiş olucak 
        {
            _loggerFactory = loggerFactory;// Gelen Fabrikayı Atamış olduk 
        }
        public void Save()
        {
            Console.WriteLine("Save!!");
            ILogger logger = _loggerFactory.CreateLoger();// Gelen Fabrika Neyle Çalışıyorsa Bize Onu ver Dedik yani Ulaşmaya çalışıyoruz
            logger.Log();// Ve Ulaştık 
        }
    }
}
