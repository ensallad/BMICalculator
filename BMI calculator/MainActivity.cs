using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace BMI_calculator
{
    [Activity(Label = "BMI calculator", MainLauncher = true, Icon = "@drawable/startIconHappyScale")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string imageName = "";
            TextView textOutput;
            textOutput = FindViewById<TextView>(Resource.Id.resultText);
            Button calcButton = FindViewById<Button>(Resource.Id.calcBtn);
            FindViewById<Button>(Resource.Id.calcBtn).Click += (o, e) =>
            {
                var weightNumber = (FindViewById<EditText>(Resource.Id.weightAdder));
                var heightNumber = (FindViewById<EditText>(Resource.Id.heightAdder));


                string weightInString = weightNumber.Text.ToString();
                string heightInString = heightNumber.Text.ToString();

                if (weightInString != "")
                {
                    if (heightInString != "")
                    {
                        decimal userWeight = decimal.Parse(weightNumber.Text.ToString());
                        decimal userHeight = decimal.Parse(heightNumber.Text.ToString());
                        decimal decVar = 0.01m;
                        if (userHeight != 0)
                        {
                            decimal userHeightModified = (userHeight * decVar);
                            decimal userHeightToCalc = userHeightModified * userHeightModified;
                            decimal bmi = userWeight / userHeightToCalc;
                            float bmiFloat = (float)bmi;
                            string bmiOutput = bmiFloat.ToString();
                            string weightText = "";
                            if (bmiFloat < 18.5)
                            {
                                weightText = " you are underweight";
                                imageName = "sadScale";
                            }

                            else if (bmiFloat >= 18.5 && bmiFloat <= 24.9)
                            {
                                weightText = " you have a normal weight";
                                imageName = "happyScale";
                            }

                            else if (bmiFloat >= 25 && bmiFloat <= 30)
                            {
                                weightText = " you are overweight";
                                imageName = "wonderingScale";
                            }

                            else
                            {
                                weightText = " you are obese";
                                imageName = "angryScale";
                            }

                            //textOutput.Text = "Your BMI is " + bmiOutput + "," + weightText;
                            string dialogText = "Your BMI is " + bmiOutput + "," + weightText;
                            FragmentTransaction transaction = FragmentManager.BeginTransaction();
                            dialogSign signDialog = new dialogSign();

                            signDialog.SendMessageToFragmentGreen(dialogText, imageName);

                            signDialog.Show(transaction, "dialogFragment");

                        }
                    };
                    //här under är den
                };
            };

            }
    }
}


