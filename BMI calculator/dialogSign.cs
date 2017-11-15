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

namespace BMI_calculator
{

    class dialogSign: DialogFragment
    {
        MainActivity mainObj = new MainActivity();
        TextView textDialogSign;
        ImageView imageDialog;
        string message;
        string imageName;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //base.OnCreateView(inflater, container, savedInstanceState);
            //var view = inflater.Inflate(Resource.Layout.dialogSign, container, false);
            //var rootView = inflater.Inflate(Resource.Layout.dialogSign, container, false);
            //// I just assume the button is in HomePermainan
            //textDialogSign = rootView.FindViewById<TextView>(Resource.Id.dialogResultText);
            //return view;

            View rootView = inflater.Inflate(Resource.Layout.dialogSign, container, false);
            textDialogSign = rootView.FindViewById<TextView>(Resource.Id.dialogResultText);
            imageDialog = rootView.FindViewById<ImageView>(Resource.Id.imageDisplay);

            textDialogSign.Text = message;
                     
            if (imageName == "wonderingScale")
            {
                imageDialog.SetImageResource(Resource.Drawable.wonderingScale);
            }
            else if(imageName == "sadScale")
            {
                imageDialog.SetImageResource(Resource.Drawable.sadScale);
            }
            else if (imageName == "happyScale")
            {
                imageDialog.SetImageResource(Resource.Drawable.happyScale);
            }
            else if (imageName == "angryScale")
            {
                imageDialog.SetImageResource(Resource.Drawable.angryScale);
            }

            return rootView;
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialogAnimation;
        }

        public void SendMessageToFragmentGreen(string value, string imageTitle)
        {
            message = value;
            imageName = imageTitle;
        }

        //public void GetMessage(string value)
        //{
        //    message = value;
        //    textDialogSign.Text = message;
        //}


    }
}