using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public enum CaracteristicPhys
	{
		[Description("Poids")]
		Poids,
		[Description("Taille")]	
		Taille,
		[Description("Nutrition")]
		Nutrition,
		[Description("Fertilite")]
		Fertilite,
		[Description("EsperanceDeVie")]
		EsperanceDeVie,
		[Description("MaturiteSexuelle")]
		MaturiteSexuelle,
	}

	public static class EnumParse {
		private static Dictionary<string, CaracteristicPhys> dicoCaracteristicPhys = new Dictionary<string, CaracteristicPhys>{
			{"Poids", CaracteristicPhys.Poids},
			{"Taille", CaracteristicPhys.Taille},
			{"Nutrition", CaracteristicPhys.Nutrition},
			{"Fertilite", CaracteristicPhys.Fertilite},
			{"EsperanceDeVie", CaracteristicPhys.EsperanceDeVie},
			{"MaturiteSexuelle", CaracteristicPhys.MaturiteSexuelle}
		};

		private static Dictionary<string, CaracteristicGen> dicoCaracteristicGen = new Dictionary<string, CaracteristicGen>{
			{"Vitesse", CaracteristicGen.Vitesse},
			{"Force", CaracteristicGen.Force},
			{"Degats", CaracteristicGen.Degats},
			{"Robustesse", CaracteristicGen.Robustesse},
			{"Temperature_Ideale", CaracteristicGen.Temperature_Ideale},
		};

		public static Dictionary<string, CaracteristicPhys> getdicoCaracteristicPhys() {
			return dicoCaracteristicPhys;
		}

		public static CaracteristicPhys GetValueCaracteristicPhys(string description) {
			return dicoCaracteristicPhys[description];
		}

		public static CaracteristicGen GetValueCaracteristicGen(string description) {
			return dicoCaracteristicGen[description];
		}
	}

}

