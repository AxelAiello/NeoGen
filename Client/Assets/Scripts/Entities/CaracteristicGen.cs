using System;
using System.ComponentModel;
namespace AssemblyCSharp
{
	public enum CaracteristicGen
	{
		[Description("Vitesse")]
		Vitesse,
		[Description("Force")]
		Force,
		[Description("Degats")]
		Degats,
		[Description("Robustesse")]
		Robustesse,
		[Description("Temperature_Ideale")]
		Temperature_Ideale,
	}   
}

