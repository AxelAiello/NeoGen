using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Threading;
namespace AssemblyCSharp
{
  public class MonsterSelector : MonoBehaviour
  {

    ServerAccess server;
    ParseJSON parse;
    List<Monster> monsterList;

    public bool listJob { get; set; }
    // Use this for initialization


    void Start()
    {
      listJob = false;
      Debug.Log("Trying to initialize the connection");
      server = ServerAccess.Instance;
      parse = new ParseJSON();
      Debug.Log("Response");
			server.Sender(parse.InitialisationUser(TemporalPerso.getToken(), "1v1").ToString());
    }

    // Update is called once per frame
    void Update()
    {
      if (!listJob)
      {
        Debug.Log("update");
        string val = server.Reciever();
        if (val != "")
        {
          Debug.Log(val);
          parse.ReadJSON((JSONObject)JSON.Parse(val));
          monsterList = MonsterList.Instance.monsters;
          listJob = true;
        }
      }
    }




  }
}
