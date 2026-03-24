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

