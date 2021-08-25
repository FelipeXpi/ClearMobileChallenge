using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ClearApp.Droid.Effects;
using GravityFlags = Android.Views.GravityFlags;
using DroidButton = Android.Widget.Button;
using ClearApp;
using System;

[assembly: ResolutionGroupName(Constants.COMPANY_NAME)]
[assembly: ExportEffect(typeof(ButtonHorizontalTextAlignmentEffect), nameof(ButtonHorizontalTextAlignmentEffect))]
namespace ClearApp.Droid.Effects
{
    public class ButtonHorizontalTextAlignmentEffect : PlatformEffect
    {
        #region Fields

        private const string EFFECT_NAME = "HorizontalTextAlignment";

        private GravityFlags gravity;

        #endregion

        #region Overrides

        protected override void OnAttached()
        {
            try
            {
                var button = Control as DroidButton;
                button.Gravity = gravity = GravityFlags.Start | GravityFlags.Center;
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
            if (!(Control is DroidButton button)) return;

            base.OnElementPropertyChanged(args);

            if (args.PropertyName == EFFECT_NAME)
            {
                if (button.Gravity == gravity)
                {
                    button.Gravity = GravityFlags.Center;
                }
                else
                {
                    button.Gravity = gravity;
                }
            }

        }

        #endregion
    }
}