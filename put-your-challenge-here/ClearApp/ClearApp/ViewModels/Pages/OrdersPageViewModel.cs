using ClearApp.Abstractions;
using ClearApp.Extensions;
using ClearApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ClearApp.ViewModels.Pages
{
    public class OrdersPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        public const int ITEMS_PER_LOADING = 25;

        private readonly IApiService _apiService;

        private IEnumerable<Order> apiOrderCollection;
        private int skippedItems;
        private bool isBusy;

        #endregion

        #region Properties

        public ICommand ThresholdReachedCommand =>
            new Command(ThresholdReachedCommandExecute);

        public IEnumerable<Order> ApiOrderCollection
        {
            get => apiOrderCollection;
            set
            {
                apiOrderCollection = value;
                LoadNextOrderCollection();
            }
        }

        public ObservableCollection<Order> ItemsSource { get; set; }

        public int SkippedItems
        {
            get => skippedItems;
            set => skippedItems = value;
        }

        public bool IsBusy {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public OrdersPageViewModel(IApiService apiService)
        {
            _apiService = apiService;

            ItemsSource = new ObservableCollection<Order>();
            GetApiOrderCollectionAsync().SafeFireAndForget();
        }

        #endregion

        #region Private Methods

        private void ThresholdReachedCommandExecute(object sender)
        {
            if (SkippedItems >= ItemsSource.Count) return;
            LoadNextOrderCollection();
        }

        private async Task GetApiOrderCollectionAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                ApiOrderCollection = await _apiService.GetOrdersAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao buscar as ordens da api: {e.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void SetOrderCollection(int skip, int take)
        {
            SkippedItems += ITEMS_PER_LOADING;
            ApiOrderCollection
                .Skip(skip)
                .Take(take)
                .ForEach((order) =>
                {
                    if (order == null) return;
                    ItemsSource.Add(order);
                });
        }

        private void LoadNextOrderCollection() =>
            SetOrderCollection(SkippedItems, ITEMS_PER_LOADING);

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
