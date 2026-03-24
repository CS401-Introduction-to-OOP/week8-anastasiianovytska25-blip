public abstract class DeliveryItem
{
    public string TrackingNumber { get ; }
    public double Weight { get ; }
    public DeliveryItem (string trackingNumber, double weight)
    {
        TrackingNumber = trackingNumber ;
        Weight = weight ;
    }
    public abstract double CalculateCost () ;
    public virtual void PrintInfo ()
    {
        Console.WriteLine($"Track : {TrackingNumber} | Weight : { Weight }") ;
    }
}

public  class Letter(string TrackingNumber, double Weight) : DeliveryItem(TrackingNumber, Weight)
{
    public override double CalculateCost()
    {
        return 15 + (Weight * 10);
    }
}

public  class Parcel(string TrackingNumber, double Weight, string Dimensions ) : DeliveryItem(TrackingNumber, Weight)
{
    public string Dimensions { get; } = Dimensions;
    public override double CalculateCost()
    {
        return 50 + (Weight * 25);
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($" Dimentsions : {Dimensions}");
    }
}

public class CargoContainer<T> where T : DeliveryItem
{
    private List<T> items = new List<T>();
    public void AddItem(T item)
    {
        items.Add(item) ;
        Console.WriteLine ($" Added : {item.TrackingNumber}" ) ;
    }
    public double GetTotalCost()
    {
       double res = 0; 
        foreach (var item in items)
        {
            res += item.CalculateCost();
        }

        return res;
    }
    
}

class Program
{
    static void Main(string[] args)
    {
      var item1 = new Letter("1", 0.2);
      var item2 = new Letter("2", 0.3);
      var item3 = new Parcel("3", 35, "30x20x15");
      var item4 = new Parcel("4", 80,"40x10x25");
      item1.PrintInfo();
      item3.PrintInfo();
      CargoContainer<DeliveryItem> myCargo = new CargoContainer<DeliveryItem>();
      myCargo.AddItem(item1);
      myCargo.AddItem(item2);
      myCargo.AddItem(item3);
      myCargo.AddItem(item4);
      Console.WriteLine($"Total cost: {myCargo.GetTotalCost()}");

    }
}

