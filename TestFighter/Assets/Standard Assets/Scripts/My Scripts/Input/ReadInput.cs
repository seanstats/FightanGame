using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ReadInput : MonoBehaviour {
	//just the path to the folder with character movesets
	const string  PATH = "./Assets/Movesets/";
	
	//FileStream for reading character movesets from file
	FileStream fin;
	
	//string representing current character's name to find file
	string m_currentCharacter = "";
	
	//character moveset filepath = PATH + currentCharacter
	string m_characterPath = PATH;
	
	
	//deadzone
	public float m_deadzone = 1f;
	
	//input list
	Queue<char> m_inputs;
	
	//to prevent multiple reads when necessary
	private char m_currentAttack = '0';	//0 = no attack
	private char m_lastDirect = '5';
	private char m_currentDirect = '5';
	
	// Use this for initialization
	void Start () {
		//set a character (default?)
		
		//set max input string to 3x360 + 2 buttons
		m_inputs = new Queue<char>(26);
	}
	
	void Update () {
		//Read directional input
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		
		if(horizontal < m_deadzone)
		{
			if(vertical < m_deadzone)
			{
				//1
				//print("1");
				m_currentDirect = '1';
			}
			else if(vertical > m_deadzone)
			{
				//7
				//print("7");
				m_currentDirect = '7';
			}
			else //vertical = within deadzone
			{
				//4
				//print("4");
				m_currentDirect = '4';
			}
		}
		else if(horizontal > m_deadzone)
		{
			if(vertical < m_deadzone)
			{
				//3
				//print("3");
				m_currentDirect = '3';
			}
			else if(vertical > m_deadzone)
			{
				//9
				m_currentDirect = '9';
			}
			else //vertical = within deadzone
			{
				//6
				//print("6");
				m_currentDirect = '6';
			}
		}
		else //horizontal = within deadzone
		{
			if(vertical < m_deadzone)
			{
				//2
				//print("2");
				m_currentDirect = '2';
			}
			else if(vertical > m_deadzone)
			{
				//8
				//print("8");
				m_currentDirect = '8';
			}
			/*else //vertical = within deadzone
			{
				//5
				//print("5");
				m_currentDirect = '5';
			}*/
		}
		
		//Read button input
		if(Input.GetButtonDown("ControllerA"))
		{
			//A
			print("Light Kick\n");
			m_currentAttack = 'A';
		}
		else if(Input.GetButtonDown("ControllerB"))
		{
			//B
			print("Medium Kick");
			m_currentAttack = 'B';
		}
		else if(Input.GetAxisRaw("ControllerRightTrigger") > 0)
		{
			//Right Trigger
			print("Heavy Kick");
			m_currentAttack = 'C';
		}
		else if(Input.GetButtonDown("ControllerX"))
		{
			//X
			print("Light Punch");
			m_currentAttack = 'D';
		}
		else if(Input.GetButtonDown("ControllerY"))
		{
			//Y
			print("Medium Punch");
			m_currentAttack = 'E';
		}
		else if(Input.GetButtonDown("ControllerRightBumper"))
		{
			//Right Bumper
			print("Heavy Punch");
			m_currentAttack = 'F';
		}
		else
		{
			m_currentAttack = '0';
		}
		
		//check directional input
		if(m_currentDirect != m_lastDirect)
		{
			//add to inputs list
			m_inputs.Enqueue(m_currentDirect);
			
			//set last to current
			m_lastDirect = m_currentDirect;
		}
		
		//check attack input
		if(m_currentAttack != '0')
		{
			
		}
	}
	
	
	//Function: SetCharacter
	//Input
	//	string newCharacter :: Name of the Character you wish to use
	//		Ex: I pass in character name "Bob" so there must be a file in the folder set in PATH named "Bob.txt"
	//Output: string
	//	If successful, changes value of characterPath to new one, returns true
	//	If unsuccessful, characterPath remains unchanged, returns false
	public bool SetCharacter(string newCharacter)
	{
		//check if character file exists
		string newCharacterPath;
		newCharacterPath = GetNewPathFromCharacterName(newCharacter);
		
		if(!File.Exists(newCharacterPath))
		{
			Debug.LogError("Character " + newCharacter + " does not exist");
			return false;
		}
		
		//check if old filestream is open (implying there is already a character set)
		if(fin != null)
		{
			//if open, close it and get a new one
			fin.Close();
			fin.Dispose();
		}
		
		//change character name to new one
		m_characterPath = newCharacterPath;
		
		//open new filestream based on new name
		fin = new FileStream(newCharacterPath, System.IO.FileMode.Open);
		
		//that should do it
		return true;
	}
	
	private string GetNewPathFromCharacterName(string newCharacter)
	{
		return System.IO.Path.Combine(PATH, (newCharacter+".txt"));
	}
}
