using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
    public interface Comunicate
    {
        string AskServer(string type, List<string> options);
    }
}
