using System;
using System.Collections.Generic;
using AutoMapper;
using MarsRover.Data.Mapper;
using MarsRover.Unity;
using Microsoft.Practices.Unity;

namespace MarsRover.UnitTest
{
    public class TestBase : IDisposable
    {
        protected IUnityContainer Container;
        protected Random Rand = new Random(DateTime.Now.Second);
        public void Setup()
        {
            AutoMapperConfig.Initialize();
            UnitySetup.RegisterComponents();
        }

        public void Dispose()
        {
        }



        protected T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        protected IList<int?> GetRandomNumberDates()
        {
            var list = new List<int?>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(Convert.ToInt32(new DateTime(1800, 1, 1).AddYears(Rand.Next(10, 300)).ToString("yyyyMMdd")));
            }
            return list;
        }

        protected IList<int> GetListOfNumbers(int size, int startRange = 1)
        {
            var list = new List<int>();
            for (var i = startRange; i <= (startRange + size); i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
