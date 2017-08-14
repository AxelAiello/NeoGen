using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AssemblyCSharp
{
  class GenCaracteristicComputer
  {

    private static readonly float Cap = 10f;

    public Dictionary<CaracteristicGen, int>  ComputeGenetics(Dictionary<CaracteristicPhys, int> physical)
    {
      Dictionary<CaracteristicGen, int> genetics = new Dictionary<CaracteristicGen, int>();


      Dictionary<CaracteristicPhys, float> normalisedPhysical = NormaliseValues(physical);

      float inflator = ComputeInflator(Summup(normalisedPhysical));

      Dictionary<CaracteristicPhys, float> inflatedValues = InflatedInputs(normalisedPhysical,inflator);

      KeyValuePair<CaracteristicGen, int> force = ComputeForce(inflatedValues);
      KeyValuePair<CaracteristicGen, int> vitesse = ComputeVitesse(inflatedValues);
      KeyValuePair<CaracteristicGen, int> robustesse = ComputeRobustesse(inflatedValues);
      KeyValuePair<CaracteristicGen, int> degats = ComputeDegats(inflatedValues);
      KeyValuePair<CaracteristicGen, int> temperature = ComputeTemperature(inflatedValues);


      genetics.Add(force.Key, force.Value);
      genetics.Add(vitesse.Key, vitesse.Value);
      genetics.Add(robustesse.Key, robustesse.Value);
      genetics.Add(degats.Key, degats.Value);
      genetics.Add(temperature.Key, temperature.Value);


      return genetics;
    }

    private KeyValuePair<CaracteristicGen,int> ComputeForce(Dictionary<CaracteristicPhys, float> inflatedValues)
    {
      float fres = 0f;
      foreach(KeyValuePair<CaracteristicPhys,float> x in inflatedValues)
      {
        float value = x.Value; 
        if (Single.IsNaN(value))
        {
          Debug.Log("value is nan too"); value = 0.2f;
        }
        switch (x.Key)
        {
          case CaracteristicPhys.MaturiteSexuelle :
            fres += (0.35f * value); 
            break;
          case CaracteristicPhys.Poids: 
            fres +=  (0.125f *value *(-1)); 
            break;
          case CaracteristicPhys.Taille :
            fres += (0.325f * value * (1));  
            break;
          case CaracteristicPhys.Nutrition :
            fres += (0.275f * 1 *value); 
            break;
          case CaracteristicPhys.Fertilite :
            fres += (0.125f * (-1) * value);  
            break;
          case CaracteristicPhys.EsperanceDeVie:
            fres += (0.25f * (1) * value);
            break;

        }
      }
      if (fres < 0) fres = 0;
      return new KeyValuePair<CaracteristicGen, int>(CaracteristicGen.Force, 
                                                                                Convert.ToInt32(
                                                                                  Math.Round(
                                                                                    (decimal)(fres * Cap), 
                                                                                    MidpointRounding.AwayFromZero)));
    }

    private KeyValuePair<CaracteristicGen, int> ComputeRobustesse(Dictionary<CaracteristicPhys, float> inflatedValues)
    {
      float fres = 0f;
      foreach (KeyValuePair<CaracteristicPhys, float> x in inflatedValues)
      {
        float value = x.Value;
        if (Single.IsNaN(value))
        {
          Debug.Log("value is nan too"); value = 0.2f;
        }
        switch (x.Key)
        {
          //The later they mature, the weaker they are
          case CaracteristicPhys.MaturiteSexuelle:
            fres += (0.2f * (-1) * value);
            break; 
          case CaracteristicPhys.Poids:
            fres += (0.3f * (1) * value);
            break;
          case CaracteristicPhys.Taille:
            fres += (0.1f * (-1) * value);
            break;
          case CaracteristicPhys.Nutrition:
            fres += (0.4f * 1 * value);
            break;
          case CaracteristicPhys.Fertilite:
            fres += (0.1f * (1) * value);
            break;
          case CaracteristicPhys.EsperanceDeVie:
            fres += (0.3f * (1) * value);
            break;
        }
      }

      if (fres < 0) fres = 0;
      return new KeyValuePair<CaracteristicGen, int>(CaracteristicGen.Robustesse, Convert.ToInt32(
                                                                                  Math.Round(
                                                                                    (decimal)(fres * Cap), 
                                                                                    MidpointRounding.AwayFromZero)));
    }

    private KeyValuePair<CaracteristicGen, int> ComputeVitesse(Dictionary<CaracteristicPhys, float> inflatedValues)
    {
      float fres = 0f;
      foreach (KeyValuePair<CaracteristicPhys, float> x in inflatedValues)
      {
        float value = x.Value;
        if (Single.IsNaN(value))
        {
          value = 0.2f;
        }
        switch (x.Key)
        {
          //The later they mature, the weaker they are
          case CaracteristicPhys.MaturiteSexuelle:
            fres += (0.1f * (-1) * value);
            break;
          case CaracteristicPhys.Poids:
            fres += (0.5f * (1) * value);
            break;
          case CaracteristicPhys.Taille:
            fres += (0.3f * (-1) * value);
            break;
          case CaracteristicPhys.Nutrition:
            fres += (0.2f * 1 * value);
            break;
        }
      }

      if (fres < 0) fres = 0;
      return new KeyValuePair<CaracteristicGen, int>(CaracteristicGen.Vitesse, Convert.ToInt32(
                                                                                  Math.Round(
                                                                                    (decimal)(fres * Cap),
                                                                                    MidpointRounding.AwayFromZero)));
    }

    private KeyValuePair<CaracteristicGen, int> ComputeDegats(Dictionary<CaracteristicPhys, float> inflatedValues)
    {
      float fres = 0f;
      foreach (KeyValuePair<CaracteristicPhys, float> x in inflatedValues)
      {
        float value = x.Value;
        if (Single.IsNaN(value))
        {
          value = 0.2f;
        }
        switch (x.Key)
        {
          case CaracteristicPhys.Poids:
            fres += (0.3f * value * (1));
            break;
          case CaracteristicPhys.Taille:
            fres += (0.2f * value * (1));
            break;
          case CaracteristicPhys.Nutrition:
            fres += (0.275f * 1 * value);
            break;
          case CaracteristicPhys.Fertilite:
            fres += (0.0f * (-1) * value);
            break;
          case CaracteristicPhys.EsperanceDeVie:
            fres += (0.0f * (1) * value);
            break;

        }
      }
      if (fres < 0) fres = 0;
      return new KeyValuePair<CaracteristicGen, int>(CaracteristicGen.Degats,
                                                                                Convert.ToInt32(
                                                                                  Math.Round(
                                                                                    (decimal)(fres * Cap),
                                                                                    MidpointRounding.AwayFromZero)));
    }

    private KeyValuePair<CaracteristicGen, int> ComputeTemperature(Dictionary<CaracteristicPhys, float> inflatedValues)
    {
      return new KeyValuePair<CaracteristicGen, int>(CaracteristicGen.Temperature_Ideale, UnityEngine.Random.Range(-30,60));
    }

    //Utility functions
    private Dictionary<CaracteristicPhys, float> NormaliseValues(Dictionary<CaracteristicPhys, int> physical)
    {
      Dictionary<CaracteristicPhys, float> x = new Dictionary<CaracteristicPhys, float>();
      foreach(KeyValuePair<CaracteristicPhys,int> p in physical)
      {
        Debug.Log("Normalising Value "+p.Key+" "+((float)p.Value) / 100);
        x.Add(p.Key, ((float)p.Value) / 100);
        
      }
      return x;
    }


    private float Summup(Dictionary<CaracteristicPhys, float> normalisedPhysical)
    {
      float sum = 0;
      foreach(KeyValuePair<CaracteristicPhys,float> np in normalisedPhysical)
      {
        sum += np.Value;
      }
      return sum;
    }

    ///<summary>
    /// A simple methode to calculate the inflator. The inflator is needed to assure
    /// that the values to be calculated will not be overpowered or too weak for a given monster.
    /// </summary>
    /// <param name=cap>the cap chosen for the inflation</param>
    /// <param name=totalsum>the total sum of the normalised inputs</param>
    private float ComputeInflator(float totalsum, float cap= 5.0f)
    { 
      return cap / totalsum;
    }
    private Dictionary<CaracteristicPhys, float> InflatedInputs(Dictionary<CaracteristicPhys, float> normalisedPhysical, float inflator)
    {
      Dictionary<CaracteristicPhys, float> inflatedInputs = new Dictionary<CaracteristicPhys, float>();
      foreach(KeyValuePair<CaracteristicPhys, float> normalisedvalue in normalisedPhysical)
      {
        Debug.Log("Inflating values" + normalisedvalue.Value);
        inflatedInputs.Add(normalisedvalue.Key, inflator * normalisedvalue.Value);
      }
      return inflatedInputs;
    }
  }
}
