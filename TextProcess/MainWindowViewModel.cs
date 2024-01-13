using Domain.Classes;
using Domain.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TextProcess.Commands;
using TextProcess.Services;

namespace TextProcess
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ITestProcessService _TestProcessService;

        #endregion

        #region Constructors

        public MainWindowViewModel(ITestProcessService testProcessService)
        {
            _TestProcessService = testProcessService;
            Thread.Sleep(2000);
            Initialize();
        }

        #endregion

        #region Properties

        public string TextToOrder { get; set; }

        public string TextToAnalyze { get; set; }

        private string _OrderedText;
        public string OrderedText
        {
            get => _OrderedText;
            set
            {
                _OrderedText = value;
                OnPropertyChanged(nameof(OrderedText));
            }
        }

        private ObservableCollection<OrderType> _OrderTypesAvailable = new ObservableCollection<OrderType>();
        public ObservableCollection<OrderType> OrderTypesAvailable 
        {
            get => _OrderTypesAvailable;             
        }

        private OrderType _OrderTypeSelected;
        public OrderType OrderTypeSelected
        {
            get => _OrderTypeSelected;
            set
            {
                _OrderTypeSelected = value;
                OnPropertyChanged(nameof(OrderTypeSelected));
            }
        }

        private TextStatistics _Statistics = new TextStatistics();
        public TextStatistics Statistics
        {
            get => _Statistics;
            set
            {
                _Statistics = value;
                OnPropertyChanged(nameof(Statistics));
            }
        }

        #endregion

        #region Commands

        private ICommand _OrderCommand;        

        public ICommand OrderCommand 
        { 
            get
            {
                if(_OrderCommand == null)
                {
                    _OrderCommand = new RelayCommand(OrderCommandExecute);
                }
                return _OrderCommand;
            }
        }

        private async void OrderCommandExecute(object obj)
        {
            OrderedText = await _TestProcessService.GetOrderedText(TextToOrder, OrderTypeSelected);            
        }

        private ICommand _AnalyzeCommand;

        public ICommand AnalyzeCommand
        {
            get
            {
                if (_AnalyzeCommand == null)
                {
                    _AnalyzeCommand = new RelayCommand(AnalyzeCommandExecute);
                }
                return _AnalyzeCommand;
            }
        }

        private async void AnalyzeCommandExecute(object obj)
        {
            Statistics = await _TestProcessService.GetStatistics(TextToAnalyze);
        }

        #endregion

        #region Private methods

        private async Task Initialize()
        {
            var orderOptions = await _TestProcessService.GetOrderOptions();
            foreach(OrderType orderOption in orderOptions)
            {
                OrderTypesAvailable.Add(orderOption);
            }            
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion

    }
}
