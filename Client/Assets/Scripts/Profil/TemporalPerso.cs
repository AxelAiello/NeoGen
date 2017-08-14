using System;

namespace AssemblyCSharp
{
	public class TemporalPerso
	{
		static string PlayerToken = "Baal1234";
		public static void setToken(string token){
			PlayerToken = token + "1234";
		}
		public static string getToken(){
			return PlayerToken;
		}
	}
}

