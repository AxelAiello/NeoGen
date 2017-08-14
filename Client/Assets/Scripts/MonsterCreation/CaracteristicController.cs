using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{

  public class CaracteristicController : MonoBehaviour
  {

    public Text SliderDescription;
    public Text CaracteristicValue;
    public Slider Slider;

    public string StringDescription { get; set; }
    private CaracteristicPhys Cartype;
    private readonly float MaxValue = 100;
    private readonly float MinValue = 0;


    // Use this for initialization
    void Start()
    {
      StringDescription = "Unnamed Caracteristic";

      Slider.maxValue = MaxValue; 
      Slider.minValue = MinValue;

      Slider.value = MaxValue / 2;

      OnSliderValueChanged();
      // SliderValue = GameObject.Find("CaracteristicSlider").GetComponent<Slider>();

      Slider.onValueChanged.AddListener(
        delegate { OnSliderValueChanged(); }  );
    }

    public void SetDescription(CaracteristicPhys caracteristicType )
    {
      Cartype = caracteristicType;
      StringDescription = caracteristicType.ToString();

      /*
       * switch (caracteristicType)
      {
			case CaracteristicPhys.Weight :
				StringDescription = "Weight";
          break;
			case CaracteristicPhys.Speed:
				StringDescription = "Speed";
          break;
            
        default:
          StringDescription = "UnnamedCaracteristic";
          break;
      }*/

      SliderDescription.text = StringDescription;
    }

    public  CaracteristicPhys  GetKeyValue()
    {
     // KeyValuePair<CaracteristicPhys, int> value = new KeyValuePair<CaracteristicPhys, int>(Cartype,Convert.ToInt32(Slider.value));
      return Cartype;
    }

    public int GetSliderValue()
    {
      return Convert.ToInt32(Slider.value);
    }

    void OnSliderValueChanged()
    {
      SliderDescription.text = StringDescription;
      CaracteristicValue.text = Slider.value.ToString("0");
    }


    // Update is called once per frame
    void Update()
    {

    }
  }
}
