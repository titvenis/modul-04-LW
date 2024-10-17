public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class HumanWorker : IWorkable, IEatable, ISleepable
{
    public void Work()
    {
        // Логика работы
    }

    public void Eat()
    {
        // Логика питания
    }

    public void Sleep()
    {
        // Логика сна
    }
}

public class RobotWorker : IWorkable
{
    public void Work()
    {
        // Логика работы
    }
}

class Program
{
    static void Main()
    {
        HumanWorker human = new HumanWorker();
        RobotWorker robot = new RobotWorker();

        human.Work();
        human.Eat();
        human.Sleep();

        robot.Work();
    }
}
