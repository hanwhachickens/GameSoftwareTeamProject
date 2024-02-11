﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpriteSwapTarget5 : MonoBehaviour
{
	// The name of the sprite sheet to use
	public string SpriteSheetName;

	// The name of the currently loaded sprite sheet
	private string LoadedSpriteSheetName;

	// The dictionary containing all the sliced up sprites in the sprite sheet
	private Dictionary<string, Sprite> spriteSheet;

	// The Unity sprite renderer so that we don't have to get it multiple times
	private SpriteRenderer spriteRenderer;
	public Sprite[] sprites;

	// Use this for initialization
	private void Start()
	{
		// Get and cache the sprite renderer for this game object
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.LoadSpriteSheet();
	}

	// Runs after the animation has done its work
	private void LateUpdate()
	{


		// Swap out the sprite to be rendered by its name
		// Important: The name of the sprite must be the same!
		this.spriteRenderer.sprite = this.spriteSheet[this.spriteRenderer.sprite.name];
	}

	// Loads the sprites from a sprite sheet
	private void LoadSpriteSheet()
	{
		// Load the sprites from a sprite sheet file (png). 
		// Note: The file specified must exist in a folder named Resources
		//var sprites = Resources.LoadAll<Sprite>(this.SpriteSheetName);
		
		this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);


	}
}