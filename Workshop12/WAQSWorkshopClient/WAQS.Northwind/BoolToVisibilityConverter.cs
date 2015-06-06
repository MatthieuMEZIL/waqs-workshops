//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WAQS.Controls.Converters
{
    public partial class BoolToVisibilityConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		bool boolValue = (bool)value;
    		if (parameter != null && ((string)parameter).ToLower() == "false")
    			boolValue = !boolValue;
    		return boolValue ? Visibility.Visible : Visibility.Collapsed;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
            object result = null;
            bool proceed = false;
            CustomConvertBack(value, targetType, parameter, culture, ref result, ref proceed);
            if (proceed || result != null)
            {
                return result;
            }
    
            throw new NotImplementedException();
        }
    
        partial void CustomConvertBack(object value, Type targetType, object parameter, CultureInfo culture, ref object result, ref bool proceed);
    }
}
