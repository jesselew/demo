using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace epos.Droid.Fragments
{
    public class MyDatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    {

        private Action<DateTime> _dateSelectedHandler = delegate { };
        private DateTime _defaultDate;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static MyDatePickerFragment NewInstance(DateTime defaultDate, Action<DateTime> onDateSelected)
        {
            var frag = new MyDatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            frag._defaultDate = defaultDate;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = _defaultDate;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month,
                                                           currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _dateSelectedHandler(selectedDate);
        }
    }
}