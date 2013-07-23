using UnityEngine;
using System.Collections;
using System.IO;

public class Movemaker : MonoBehaviour {
	
	enum GUIstate {ChoosingCharacter, EditingMoves};
	private GUIstate state = GUIstate.ChoosingCharacter;
	
	string filePath = @".\Assets\Movesets";
	string[] movesetFiles;
	string currentCharacterName;
	
	//math
	private int buttonHeight = 25;
	private int buttonWidth = 50;
	
	// Use this for initialization
	void Start () {
		//find all current movelists
		movesetFiles = Directory.GetFiles(filePath, "*.txt");
		for(int i = 0; i < movesetFiles.Length; i++)
		{
			print(movesetFiles[i]);
		}
		
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(state == GUIstate.ChoosingCharacter)
		{
			//GUILayout.BeginArea(Rect(0, 0, buttonWidth, buttonHeight));
			//GUILayout.EndArea();
		}
	}
	
	private bool AddNewCharacter(string characterName)
	{
		//TODO: maybe do some checks for spaces and capital letters or something
		
		string characterFileName = characterName + ".txt";
		characterFileName = System.IO.Path.Combine(filePath, characterFileName);
		
		//check if character already exists
		for(int i = 0; i < movesetFiles.Length; i++)
		{
			if(characterFileName.Equals(movesetFiles[i]))
			{
				//character already exists
				Debug.LogWarning("Character name entered already exists. Was not added.");
				return false;
			}
		}
		
		//character must not exist yet, create new file for it
		System.IO.File.Create(characterFileName);
		
		return true;
	}
}
