using System;

public interface IBird
{
    Egg Lay();
}

public class Chicken : IBird
{
    public Chicken()
    {
    }
    
    public Egg Lay(){
        return new Egg(()=>new Chicken());
    }
}

public class Egg
{
    private bool hatched = false;

    Func<IBird> hatchFunction = null;

    public Egg(Func<IBird> createBird)
    {
        hatchFunction = createBird;
    }

    public IBird Hatch()
    {
        if(!hatched){
            hatched = true;
            return hatchFunction != null?hatchFunction():null;
        }

        throw new InvalidOperationException();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
      var chicken1 = new Chicken();
      var egg = chicken1.Lay();
     var childChicken = egg.Hatch();
     egg.Hatch();
    }
}