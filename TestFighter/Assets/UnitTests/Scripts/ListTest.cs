using UnityEngine;
using System.Collections;

public class ListTest : MonoBehaviour {
	public struct DataStruct
	{
		public int first;
		public int second;
	};
	List<DataStruct> myList1;
	
	DataStruct classStruct;
	
	// Use this for initialization
	void Start () {
		bool succeeded = false;
		
		myList1 = new List<DataStruct>();
		
		DataStruct methodStruct;
		
		classStruct.first = 111;
		classStruct.second = 222;
		
		methodStruct.first = 1;
		methodStruct.second = 2;
		
		//add first item to list correctly
		succeeded = myList1.AddAtIndex(0, classStruct);
		if(succeeded)
		{
			print("Adding at index 0 to empty list succeeded!");
			print(myList1.GetAt(0).Data.first);
			//print(myList1.GetAt(0).next.Data.first);	//should cause error
		}
		else
		{
			print("Adding at index 0 to empty list failed!");
			return;
		}
		
		//add second item to list correctly
		succeeded = myList1.AddAtIndex(1, methodStruct);
		if(succeeded)
		{
			print("Adding at index 1 to list (size: " + myList1.m_size + ") succeeded!");
			print(myList1.GetAt(1).Data.first);
			print(myList1.GetAt(0).Data.first);
		}
		else
		{
			print("Adding at index 1 to list (size: " + myList1.m_size + ") failed!");
			return;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
