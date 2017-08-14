using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
  class MonsterCreator
  {
    private static MonsterCreator instance;

    public static MonsterCreator Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new MonsterCreator();
        }
        return instance;
      }
    }

    public static JSONObject Initiate(Monster monster)
    {
      return null;
    }

    public static void Reset()
    {
      instance = null;
    }

  }
}
