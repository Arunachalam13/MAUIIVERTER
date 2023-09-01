using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace MAUIIVERTER.MVVM.ViewModels
{
    //Fody --> used instead of INotifyPropertyChanged
    public class ConverterViewModel : INotifyPropertyChanged
    {
        private string _quantityName;
        private string _currentFromMeasure;
        private string _currentToMeasure;
        private double _fromValue = 1;
        private double _toValue = 1;

        //private ObservableCollection<string> _quantityType;
        public string QuantityName 
        {
            get => _quantityName;
            set
            {
                _quantityName = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }

        public string CurrentFromMeasure 
        {
            get => _currentFromMeasure;
            set
            {
                _currentFromMeasure = value;
                OnPropertyChanged();
            }
        }
        public string CurrentToMeasure 
        {
            get => _currentToMeasure;
            set
            {
                _currentToMeasure = value;
                OnPropertyChanged();
            }
        }
        public double FromValue
        {
            get => _fromValue;
            set
            {
                _fromValue = value;
                OnPropertyChanged();
            }
        }
        public double ToValue 
        {
            get => _toValue;
            set
            {
                _toValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReturnCommand => new Command(() =>
        {
            Convert();
        });

        public event PropertyChangedEventHandler PropertyChanged;

        public void Convert()
        {
            var result = UnitConverter.ConvertByName(FromValue, QuantityName,
                CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }

        public ConverterViewModel(string quantityName)
        {
            QuantityName = quantityName;
            FromMeasures = LoadMeasure();
            ToMeasures = LoadMeasure();
            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
            Convert();
        }

        private ObservableCollection<string> LoadMeasure()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuantityName)
                .UnitInfos
                .Select(u => u.Name)
                .ToList();
            return new ObservableCollection<string>(types);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
