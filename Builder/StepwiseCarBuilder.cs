using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public interface ISpecifyCarType
    {
        public ISpecifyWheelSize OfType(CarType carType);
    }

    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheelSizeOf(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class Car
    {
        public CarType CarType;
        public int WheelSize;
    }

    internal class StepwiseCarBuilder
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
        {
            private Car car = new Car();

            public ISpecifyWheelSize OfType(CarType carType)
            {
                car.CarType = carType;
                return this;
            }

            public IBuildCar WithWheelSizeOf(int size)
            {
                switch (car.CarType)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size <15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.CarType}.");
                }
                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }

        public ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
}
