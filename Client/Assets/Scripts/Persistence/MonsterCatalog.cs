using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AssemblyCSharp
{
  public class MonsterCatalog 
  {
    public static MonsterCatalog catalog;

    public List<Monster> monsters;

    public MonsterCatalog()
    {
      monsters = new List<Monster>();
    }

    public static MonsterCatalog Instance
    {
      get
      {
        if (catalog == null)
        {
          catalog = new MonsterCatalog();
        }
        return catalog;
      }
    }

    /*  public void  Awake()
      {
        if(catalog == null)
        {
          DontDestroyOnLoad(gameObject);
          catalog = this;
        }else if(catalog != this)
        {
          Destroy(gameObject);
        }
      }
      */

    public void Save()
    {
     
      BinaryFormatter bf = new BinaryFormatter();
     
      if (!File.Exists(Application.persistentDataPath + "playerMonsterCatalog.dat"))
      {
        File.Create(Application.persistentDataPath + "playerMonsterCatalog.dat").Dispose();
      }

      FileStream file = File.Open(Application.persistentDataPath + "playerMonsterCatalog.dat", FileMode.Open);

      PlayerData data = new PlayerData()
      {
        monsters = MonsterList.Instance.monsters
      };

      bf.Serialize(file, data);
      file.Close();

    }

    public void Load()
    {
      if (File.Exists(Application.persistentDataPath + "playerMonsterCatalog.dat"))
      {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "playerMonsterCatalog.dat",
                              FileMode.Open);

        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();

        monsters = data.monsters;
        MonsterList.Instance.monsters = monsters;
      }
    }

  }
}