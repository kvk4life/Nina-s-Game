﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heartscript : MonoBehaviour 
{
	public int[] hearts;
	public Sprite[] heartHud;
	public int h;
	public int maxLength;
	public Sprite halfHeart;
	public Sprite fullHeart;
	public GameObject[] spriteList;
	void Start () 
	{
		NewBar ();
		HudCheck ();
	}
	void HudCheck ()
	{
		for (int i = 0; i < maxLength; i++) 
		{
			spriteList[i].GetComponent<Image>().sprite = heartHud[i];
		}
	}
	
	
	public void NewBar()
	{
		hearts = new int[maxLength];
		heartHud = new Sprite[maxLength];
		
		for (int i = 0; i < maxLength; i++) 
		{
			hearts[i] = 2;
			heartHud[i] = fullHeart;
		}
		for (int i = 0; i <spriteList.Length; i++)
		{
			spriteList[i].SetActive(true);
		}
		for (int i = maxLength; i <spriteList.Length; i++)
		{
			spriteList[i].SetActive(false);
		}
	}
	
	public void LoseHeart (float loseAmount)
	{
		print ("Lose mij damage = " + loseAmount);
		
		for(int i = 0; i < loseAmount ; i++){
			
			if (hearts[h] >= 1) 
			{
				print ("aauw!");
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
	public void GainHeart(float gainAmount)
	{
		
		for(int i = 0; i < gainAmount ; i++)
		{
			
			if (hearts[h] <= 1) 
			{
				hearts[h] += 1;
			} 
			else 
			{
				h -= 1;
				hearts[h] += 1;
			}
			
			HeartCheck();
			
		}  
	}
	void HeartCheck ()
	{
		if (hearts [h] == 0) 
		{
			spriteList[h].GetComponent<Image>().sprite = null;
			spriteList[h].SetActive(false);
		}
		if (hearts [h] == 1) 
		{
			spriteList[h].GetComponent<Image>().sprite = halfHeart;
			spriteList[h].SetActive(true);
		}
		if (hearts [h] == 2) 
		{
			spriteList[h].GetComponent<Image>().sprite = fullHeart;
			spriteList[h].SetActive(true);
		}
	}
}