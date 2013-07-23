using UnityEngine;
using System.Collections;
using System.IO;

public class ReadInput : MonoBehaviour {
	//just the path to the folder with character movesets
	const string  PATH = "./Assets/Movesets/";
	
	//FileStream for reading character movesets from file
	FileStream fin;
	
	//string representing current character's name to find file
	string currentCharacter = "";
	
	//character moveset filepath = PATH + currentCharacter
	string characterPath = PATH;
	
	
	// Use this for initialization
	void Start () {
		//set a character (default?)
	}
	
	void Update () {
		//Read directional input
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		if(horizontal < 0)
		{
			if(vertical < 0)
			{
				//1
				print("1");
			}
			else if(vertical > 0)
			{
				//7
				print("7");
			}
			else //vertical = 0
			{
				//4
				print("4");
			}
		}
		else if(horizontal > 0)
		{
			if(vertical < 0)
			{
				//3
				print("3");
			}
			else if(vertical > 0)
			{
				//9
				print("9");
			}
			else //vertical = 0
			{
				//6
				print("6");
			}
		}
		else //horizontal = 0
		{
			if(vertical < 0)
			{
				//2
				print("2");
			}
			else if(vertical > 0)
			{
				//8
				print("8");
			}
			/*else //vertical = 0
			{
				//5
				print("5");
			}*/
		}
		
		//Read button input
		if(Input.GetButtonDown("ControllerA"))
		{
			//A
			print("Light Kick\n");
		}
		else if(Input.GetButtonDown("ControllerB"))
		{
			//B
			print("Medium Kick");
		}
		else if(Input.GetAxisRaw("ControllerRightTrigger") > 0)
		{
			//Right Trigger
			print("Heavy Kick");
		}
		else if(Input.GetButtonDown("ControllerX"))
		{
			//X
			print("Light Punch");
		}
		else if(Input.GetButtonDown("ControllerY"))
		{
			//Y
			print("Medium Punch");
		}
		else if(Input.GetButtonDown("ControllerRightBumper"))
		{
			//Right Bumper
			print("Heavy Punch");
		}
	}
	
	
	//Function: SetCharacter
	//Input
	//	string newCharacter :: Name of the Character you wish to use
	//		Ex: I pass in character name "Bob" so there must be a file in the folder set in PATH named "Bob.txt"
	//Output: string
	//	If successful, returns new value for characterPath
	//	If unsuccessful, returns unchanged characterPath
	public string SetCharacter(string newCharacter)
	{
		//check if character file exists
		string newCharacterPath = System.IO.Path.Combine(PATH, (newCharacter + ".txt"));
		if(!File.Exists(newCharacterPath))
		{
			Debug.LogError("
		}
		
		//check if old filestream is open (implying there is already a character set)
			//if open, close it
			//else, do nothing
		//change character name to new one
		//open new filestream based on new name
		
		//that should do it
	}
}
