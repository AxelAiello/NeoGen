using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AssemblyCSharp
{
  public class CharacterListController : MonoBehaviour
  {

    public Sprite[] CharactersIcon;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;


    public Monster Selected { get; set; }
    MonsterSelector script;
    bool renderJob = false;

    List<CharacterModel> Characters;

    // Use this for initialization
    void Start()
    {
      //First nothing is selected
      Selected = null;
      
      Characters = new  List<CharacterModel>();
      script = GameObject.Find("Scripts").GetComponent<MonsterSelector>();
      MonsterCatalog.Instance.Load();

       foreach (Monster m in MonsterList.Instance.monsters)
      { 
         Characters.Add(new CharacterModel((Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath(m.Image, typeof(Sprite)),
                                                    m.Name,
                                                    new Caracteristics(m.ID, m.MapPhysical, m.MapGenetics)));
        }


    }


    // Update is called once per frame
    void Update()
    {
      if (script.listJob == true && !renderJob)
      {

 
        foreach (Monster m in MonsterList.Instance.monsters)
        {
          Debug.Log("PATH TO IMAGE" + m.Image);
          CharacterModel model = new CharacterModel((Sprite)UnityEditor.AssetDatabase.LoadAssetAtPath(m.Image, typeof(Sprite)),
                                                   m.Name,
                                                   new Caracteristics(m.ID, m.MapPhysical, m.MapGenetics));

          Characters.Add(model);
          Debug.Log(model);
        }
        foreach (CharacterModel c in Characters)
        {

          GameObject newChar = Instantiate(ListItemPrefab, ListItemPrefab.transform.position, ListItemPrefab.transform.rotation) as GameObject;
          CharacterListItemController controller = newChar.GetComponent<CharacterListItemController>();

          //Créer le component
          newChar.AddComponent<EventTrigger>();
          //
          AddEventTriggerListener(
            newChar.GetComponent<EventTrigger>(),
            EventTriggerType.PointerClick,
            c);

          controller.Name.text = c.CharacterName;
          controller.Icon.sprite = c.CharacterIcon;
          controller.Description.text = c.Caracteristic.ToString();

          newChar.transform.SetParent(ContentPanel.transform, false);
          //newChar.transform.parent = ContentPanel.transform;
          newChar.transform.localScale = Vector3.one;

        }
        renderJob = true;
      }
    }


    private void AddEventTriggerListener(EventTrigger trigger,
                                               EventTriggerType eventType,
                                               CharacterModel sender)
    {
      EventTrigger.Entry entry = new EventTrigger.Entry();
      entry.eventID = eventType;
      // entry.callback = new EventTrigger.TriggerEvent();
      entry.callback.AddListener((eventData) => { ChooseCharacter(sender); });
      //entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
      trigger.triggers.Add(entry);
    }


    public void ChooseCharacter(CharacterModel selectedcharacter)
    {
      Debug.Log("Selected ! GG ");
      Debug.Log(selectedcharacter.CharacterName);
      CreatureViewerController viewer = GameObject.Find("CreatureViewer").GetComponent<CreatureViewerController>();
      Debug.Log("ListController");
      Debug.Log(selectedcharacter.CharacterName);

      viewer.ChangeCreature(selectedcharacter);

    }

    public void OnDestroy()
    {
     // ServerAccess.Instance.StopConnection();
    }




  }
 

}