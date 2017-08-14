using System.Collections;
using System.Collections.Generic;

using UnityEngine;
namespace AssemblyCSharp
{
  public class CharacterModel
  {

    public Sprite CharacterIcon;
    public string CharacterName;
    public Caracteristics Caracteristic;

    public CharacterModel(Sprite icon, string characterName, Caracteristics caracteristic)
    {
      CharacterIcon = icon;
      CharacterName = characterName;
      Caracteristic = caracteristic;
    }

    public override string ToString()
    {
      return "Monster : name = " + CharacterName + " strenght " + Caracteristic;
    }
  }
}