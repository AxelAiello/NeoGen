using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace AssemblyCSharp
{
  public class CreatureViewerController : MonoBehaviour
  {

    public GameObject ContentPanel;
    public GameObject CreaturePrefab;
    public GameObject PlaceholderPrefab;

    private CharacterListController script;
    private GameObject View;
    // private bool selected;

    // public CharacterModel model { get; set; } // ???

    // Use this for initialization

    void Start()
    {

      View = Instantiate(PlaceholderPrefab, PlaceholderPrefab.transform.position, PlaceholderPrefab.transform.rotation) as GameObject;
      View.transform.SetParent(ContentPanel.transform, false);

      GameObject characterList = GameObject.Find("CreaturesContainer");
      // script = characterList.GetComponent<CharacterListController>();
      // selected = false;

    }

    public void ChangeCreature(CharacterModel newCreature)
    {
      Debug.Log("Changing view : Destroying old view");
      Destroy(View);
      Debug.Log("Changing view : Creating new view");


      View = Instantiate(CreaturePrefab, CreaturePrefab.transform.position, CreaturePrefab.transform.rotation) as GameObject;

      CreatureViewerItemController controller = View.GetComponent<CreatureViewerItemController>();

      controller.Name.text = newCreature.CharacterName;
      controller.Description.text = newCreature.Caracteristic.ToString();
      controller.Icon.sprite = newCreature.CharacterIcon;

      controller.GoButton.onClick.AddListener(delegate
        {
          GoToPlay();
        }
      );

      View.transform.SetParent(ContentPanel.transform, false);
    }




    public void GoToPlay()
    {
      Debug.Log("GO TO PLAY");
			SceneManager.LoadScene("Scenes/ChooseDeckScene");
    }
    // Update is called once per frame
    void Update()
    {

    }



  }
}
