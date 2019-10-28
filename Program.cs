using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var bmw = new Car(new BmwFactory());
            bmw.GetNameBody();
            bmw.GetNameMotor();
            bmw.GetNameCabin();

            var audi = new Car(new AudiFactory());
            audi.GetNameBody();
            audi.GetNameMotor();
            audi.GetNameCabin();
        }
    }

    #region Interfaces

    public interface ICarFactory
    {
        IBody CreateBody();
        IMotor CreateMotor();
        ICabin CreateCabin();
    }

    public interface IBody
    {
        string Name { get; }
    }

    public interface IMotor
    {
        string Name { get; }
    }

    public interface ICabin
    {
        string Name { get; }
    }

    #endregion

    #region BMW Car

    public class BmwFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new BmwBody();
        }

        public IMotor CreateMotor()
        {
            return new BmwMotor();
        }

        public ICabin CreateCabin()
        {
            return new BmwCabin();
        }
    }

    public class BmwBody : IBody
    {
        public string Name => "Кузов BMW";
    }

    public class BmwMotor : IMotor
    {
        public string Name => "Мотор BMW";
    }

    public class BmwCabin : ICabin
    {
        public string Name => "Салон BMW";
    }

    #endregion

    #region AUDI Car

    public class AudiFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new AudiBody();
        }

        public IMotor CreateMotor()
        {
            return new AudiMotor();
        }

        public ICabin CreateCabin()
        {
            return new AudiCabin();
        }
    }

    public class AudiBody : IBody
    {
        public string Name => "Кузов AUDI";
    }

    public class AudiMotor : IMotor
    {
        public string Name => "Мотор AUDI";
    }

    public class AudiCabin : ICabin
    {
        public string Name => "Салон AUDI";
    }

    #endregion

    public class Car
    {
        private IBody _body;
        private IMotor _motor;
        private ICabin _cabin;

        public Car(ICarFactory factory)
        {
            _body = factory.CreateBody();
            _motor = factory.CreateMotor();
            _cabin = factory.CreateCabin();
        }

        public void GetNameBody() => Console.WriteLine(_body.Name);
        public void GetNameMotor() => Console.WriteLine(_motor.Name);
        public void GetNameCabin() => Console.WriteLine(_cabin.Name);
    }
}
