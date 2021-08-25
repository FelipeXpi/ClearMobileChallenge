using System;

namespace ClearApp.Models {
    public sealed class Order {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Type { get; set; }

        public string Side { get; set; }

        public string Module { get; set; }

        public string Status { get; set; }

        public string Quantity { get; set; }

        public string Logo { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
