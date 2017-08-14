using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
  public class MonsterRendererController : MonoBehaviour
  {

    public Sprite PlaceHolderImage;

    public Text CaracterName;
    public Text Description;
    public Image Image;


    private MonsterCreatureViewport controller;

    // Use this for initialization
    void Start()
    {
      Image.sprite = PlaceHolderImage;
    }

    void Awake()
    {
      controller = GameObject.Find("CreationPanel").GetComponent<MonsterCreatureViewport>();

    }

    // Update is called once per frame
    void Update()
    {
      CaracterName.text = controller.MonsterNameField.text;
      Description.text = controller.PlaceholderMonster.ToString();
    }
  }
}
