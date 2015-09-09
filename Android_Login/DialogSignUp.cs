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

namespace Android_Login
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mFirstName;
        private string mEmailAddress;
        private string mPassword;

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }
        public string EmailAddress
        {
            get { return mEmailAddress; }
            set { mEmailAddress = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            EmailAddress = email;
            Password = password;
        }
    }
    class DialogSignUp : DialogFragment
    {
        private EditText mTextFirstName;
        private EditText mTextEmail;
        private EditText mTextPassword;
        private Button mButtonSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogSignUp, container, false);

            mTextFirstName = view.FindViewById<EditText>(Resource.Id.textFirstName);
            mTextEmail = view.FindViewById<EditText>(Resource.Id.textEmail);
            mTextPassword = view.FindViewById<EditText>(Resource.Id.textPassword);
            mButtonSignUp = view.FindViewById<Button>(Resource.Id.buttonSignUp);

            mButtonSignUp.Click += mButtonSignUp_Click;
            return view;
        }

        void mButtonSignUp_Click(object sender, EventArgs e)
        {
            //User clicks on button
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTextFirstName.Text, mTextEmail.Text, mTextPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.DialogAnimation; //Set the animation
        }
    }
}