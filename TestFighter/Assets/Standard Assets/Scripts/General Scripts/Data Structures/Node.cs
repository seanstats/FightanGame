using UnityEngine;
using System.Collections;

public class Node<T> {
	
	private T m_data;
	public T Data
	{
		get
		{
			return m_data;
		}
		set
		{
			m_data = value;
		}
	}
	
	public Node<T> next;
	
	public Node(T init)
	{
		m_data = init;
	}
	
}
