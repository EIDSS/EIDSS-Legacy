using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EIDSS
{
    public class EidssAndroidHelpers
    {
        public static Dialog ErrorDialog(Activity context, string text)
        {
            var builder = new AlertDialog.Builder(context);
            builder.SetMessage(text);
            builder.SetCancelable(false);
            builder.SetPositiveButton(context.Resources.GetString(Resource.String.Ok), (sender, args) =>
            {
                var dialog = (AlertDialog)sender;
                dialog.Dismiss();
            });
            return builder.Create();
        }

        public static Dialog MessageDialog(Activity context, string text, EventHandler<DialogClickEventArgs> handler)
        {
            var builder = new AlertDialog.Builder(context);
            builder.SetMessage(text);
            builder.SetCancelable(false);
            builder.SetPositiveButton(context.Resources.GetString(Resource.String.Ok), handler);
            return builder.Create();
        }

        public static Dialog QuestionDialog(Activity context, string text, EventHandler<DialogClickEventArgs> handler_yes, EventHandler<DialogClickEventArgs> handler_no)
        {
            var builder = new AlertDialog.Builder(context);
            builder.SetMessage(text);
            builder.SetCancelable(false);
            builder.SetNegativeButton(context.Resources.GetString(Resource.String.No), handler_no);
            builder.SetPositiveButton(context.Resources.GetString(Resource.String.Yes), handler_yes);
            return builder.Create();
        }
    }
}