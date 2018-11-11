using System;
using AutoMapper;
using MarsRover.Data.Mapper;
using MarsRover.Unity;

namespace MarsRover.IntegrationTest
{
    public class TestBase : IDisposable
    {

        public void Setup()
        {
            AutoMapperConfig.Initialize();
            UnitySetup.RegisterComponents();
        }

        public void Dispose()
        {
        }
    }
}
