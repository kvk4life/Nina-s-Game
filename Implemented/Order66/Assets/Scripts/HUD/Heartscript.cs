using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heartscript : MonoBehaviour {

	public int[] hearts;
	public Sprite[] heartHud;
	public int h;
	public int maxLength;
	public Sprite halfHeart;
	public Sprite fullHeart;
	public GameObject[] spriteList;
	
	void Start () {
		hearts = new int[maxLength];
		heartHud = new Sprite[maxLength];
		for (int i = 0; i < maxLength; i++) {
			hearts[i] = 2;
			heartHud[i] = fullHeart;
		}
		HudCheck ();
	}
	
	void HudCheck (){
		for (int i = 0; i < maxLength; i++) {
			spriteList[i].GetComponent<SpriteRenderer> ().sprite = heartHud[i];
		}

	}

	void LoseHeart (){
		if (hearts[maxLength-1] > 0) {
			if (hearts[h] >= 1) {
				hearts[h] -= 1;
			} 
			else 
		{
				h += 1;
				hearts[h] -= 1;
			}
		}
		HeartCheck();
	}

	void GainHeart(){
		if (hearts[0] < 2) {
			if (hearts[h] <= 1) {
				hearts[h] += 1;
			} 
			else {
				h -= 1;
				hearts[h] += 1;
			}
		}
		HeartCheck();
	}

	void HeartCheck (){
		if (hearts [h] == 0) {
			heartHud[h] = null;
		}

		if (hearts [h] == 1) {
			heartHud[h] = halfHeart;
		}

		if (hearts [h] == 2) {
			heartHud[h] = fullHeart;
		}
	}
}