using Android.App;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.Timers;
using System;

namespace Project1._2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView imageview;
        Button buttonStart, buttonStop;
        int[] imageTable = new int[7];
        int index;
        Timer timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            imageview = FindViewById<ImageView>(Resource.Id.imageView1);
            buttonStart = FindViewById<Button>(Resource.Id.ButtonStart);
            buttonStop = FindViewById<Button>(Resource.Id.ButtonStop);

            imageTable[0] = Resource.Drawable.pic1;
            imageTable[1] = Resource.Drawable.pic2;
            imageTable[2] = Resource.Drawable.pic3;
            imageTable[3] = Resource.Drawable.pic4;

            buttonStop.Enabled = false;
            buttonStart.Click += buttonStart_Clicked;
            buttonStop.Click += buttonStop_Clicked;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void buttonStart_Clicked(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapdsed;
            timer.Start();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }
        private void Timer_Elapdsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                if (index == imageTable.Length) index = 0;
                imageview.SetImageResource(imageTable[index++]);
            });
        }

        private void buttonStop_Clicked(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

    }
}