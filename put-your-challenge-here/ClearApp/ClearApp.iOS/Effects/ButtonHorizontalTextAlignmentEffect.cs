using ClearApp;
using ClearApp.iOS.Effects;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(Constants.COMPANY_NAME)]
[assembly: ExportEffect(typeof(ButtonHorizontalTextAlignmentEffect), nameof(ButtonHorizontalTextAlignmentEffect))]
namespace ClearApp.iOS.Effects
{
    public class ButtonHorizontalTextAlignmentEffect : PlatformEffect
    {
        #region Fields

        private const string EFFECT_NAME = "HorizontalTextAlignment";

        private UIControlContentHorizontalAlignment horizontalTextAlignment;

        #endregion

        protected override void OnAttached()
        {
            try
            {
                var button = Control as UIButton;
                button.HorizontalAlignment = horizontalTextAlignment = UIControlContentHorizontalAlignment.Left;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (!(Control is UIButton button)) return;

            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == EFFECT_NAME)
                {
                    if (button.HorizontalAlignment == horizontalTextAlignment)
                    {
                        button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                    }
                    else
                    {
                        button.HorizontalAlignment = horizontalTextAlignment;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

            }
        }
    }
}