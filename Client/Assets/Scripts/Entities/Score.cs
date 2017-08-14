using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
	public string type;
	public int points;

	public Score(string type="Inconnu", int points=0) {
		this.type = type;
		this.points = points;
	}
}

