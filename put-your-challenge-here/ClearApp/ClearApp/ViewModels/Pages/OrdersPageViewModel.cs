using ClearApp.Abstractions;
using ClearApp.Extensions;
using ClearApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ClearApp.ViewModels.Pages
{
    public class OrdersPageViewModel : BasePageViewModel
    {
        #region Fields

        public const int ITEMS_PER_LOADING = 25;

        private readonly IApiService _apiService;

        private IEnumerable<Order> apiOrderCollection;
        private int skippedItems;

        #endregion

        #region Properties

        public ICommand OnAppearingCommand =>
            new Command(OnAppearingCommandExecute);

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

        #endregion

        #region Constructor

        public OrdersPageViewModel(IApiService apiService)
        {
            _apiService = apiService;

            ItemsSource = new ObservableCollection<Order>();
        }

        #endregion

        #region Private Methods

        private void OnAppearingCommandExecute(object sender) =>
            GetApiOrderCollectionAsync().SafeFireAndForget();

        private void ThresholdReachedCommandExecute(object sender)
        {
            if (SkippedItems >= ApiOrderCollection.Count()) return;
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

        #endregion
    }
}
