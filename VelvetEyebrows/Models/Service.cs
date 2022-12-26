using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace VelvetEyebrows.Models;
public partial class Service : INotifyPropertyChanged
{

    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public int DurationInSeconds { get; set; }

    public string? Description { get; set; }

    public double? Discount { get; set; }

    public virtual ICollection<ServicePhoto> ServicePhotos { get; } = new ObservableCollection<ServicePhoto>();

    public event PropertyChangedEventHandler? PropertyChanged;

    public string? mainImagePath;
    public string? MainImagePath
    {
        get => mainImagePath;
        set
        {
            mainImagePath = value;
            notifyPropertyChanged(nameof(MainImagePath));
        }
    }

    private void notifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public decimal CostWithDiscount
    {
        get
        {
            return Cost * (1 - (decimal)Discount);
        }
    }
    public double DurationInMunites
    {
        get
        {
            return (double)(DurationInSeconds / 60);
        }
    }

    public virtual ICollection<ClientService> ClientServices { get; } = new List<ClientService>();
}
