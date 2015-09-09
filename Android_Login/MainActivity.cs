using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace Android_Login
{
    [Activity(Label = "Android_Login", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mButtonSignUp;
        private ProgressBar mProgressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mButtonSignUp = FindViewById<Button>(Resource.Id.buttonSignUp);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            mButtonSignUp.Click += mButtonSignUp_Click;
        }

        void mButtonSignUp_Click(object sender, EventArgs e)
        {
            //Pull up dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignUp signUpDialog = new DialogSignUp();
            signUpDialog.Show(transaction, "Dialog Fragment");

            signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
        }

        void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;
            //Simulated thread
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();

        }

        private void ActLikeARequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { mProgressBar.Visibility = ViewStates.Invisible; });
        }
    }
}

