using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{
		public List<Card> cards;
		public int po;
		public int xp;

		public Reward(List<Card> cards, int po, int xp) {
			this.cards = cards;
			this.po = po;
			this.xp = xp;
		}

	public Reward() {
		this.cards = new List<Card>();
		this.po = 0;
		this.xp = 0;
	}
}
