//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 

namespace WAQS.ComponentModel
{
    public partial class PatternErrorInfo : ErrorInfo
    {
    	public const string PatternErrorCode = "Pattern";
    
    	public PatternErrorInfo(string propertyName, string pattern)
    		: base(propertyName, PatternErrorCode)
    	{
    		Pattern = pattern;
    	}
    
    	public override string Message
    	{
    		get 
    		{
    			string message = string.Format("Pattern error ({0})", Pattern);
    			SetMessage(ref message);
    			return message;
    		}
    	}
    	partial void SetMessage(ref string message);
    
    	public string Pattern { get; private set; }
    }
}