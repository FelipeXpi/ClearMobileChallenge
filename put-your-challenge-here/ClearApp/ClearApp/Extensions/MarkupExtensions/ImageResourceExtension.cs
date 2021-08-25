using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ClearApp.Extensions {
    [Preserve(true, true)]
    [ContentProperty(nameof(Source))]
    public sealed class ImageResourceExtension : IMarkupExtension {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null) return null;

            return ImageSource.FromResource(Source);
        }
    }
}
