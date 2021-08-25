using ClearApp.Models;
using ClearApp.ViewModels.Pages;
using System.Collections.ObjectModel;
using Xunit;

namespace ClearAppTests.ViewModels
{
    public class OrdersPageViewModelTest : BaseTestableViewModel
    {
        private OrdersPageViewModel ordersPageViewModel;
        private ObservableCollection<Order> fakeSource;

        public OrdersPageViewModelTest() : base()
        {
            CreateViewModel();
            CreateFakeSource();
        }

        [Fact]
        public void ShouldGetApiCollectionAfterConstructor()
        {
            Assert.NotNull(ordersPageViewModel.ApiOrderCollection);
        }

        [Fact]
        public void ShouldGetApiCollectionAndUpdateItemsSourceAfterConstructor()
        {
            Assert.NotNull(ordersPageViewModel.ItemsSource);
            Assert.Equal(OrdersPageViewModel.ITEMS_PER_LOADING, ordersPageViewModel.SkippedItems);
        }

        [Fact]
        public void ShouldNotGetNextItemsWhenScrollThresholdReachedAndItemsSourceLimitReached()
        {
            Assert.Equal(OrdersPageViewModel.ITEMS_PER_LOADING, ordersPageViewModel.SkippedItems);

            ordersPageViewModel.ThresholdReachedCommand.Execute(null);
            Assert.Equal(OrdersPageViewModel.ITEMS_PER_LOADING, ordersPageViewModel.SkippedItems);
        }

        [Fact]
        public void ShouldGetNextItemsWhenScrollThresholdReached()
        {
            ordersPageViewModel.ItemsSource = fakeSource;
            Assert.Equal(OrdersPageViewModel.ITEMS_PER_LOADING, ordersPageViewModel.SkippedItems);

            var expectedSkipped = OrdersPageViewModel.ITEMS_PER_LOADING * 2;
            ordersPageViewModel.ThresholdReachedCommand.Execute(null);
            Assert.Equal(expectedSkipped, ordersPageViewModel.SkippedItems);
        }

        private void CreateViewModel()
        {
            ordersPageViewModel = new OrdersPageViewModel(_apiService.Object);
        }

        private void CreateFakeSource()
        {
            fakeSource = new ObservableCollection<Order>();
            for (var i = 0; i < 120; i++)
            {
                fakeSource.Add(new Order() { Name = "teste" });
            }
        }
    }
}
