﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class BotSpeak : MonoBehaviour
{
	[SerializeField]
	private GameObject audioOutput;
	[SerializeField]
	private GameObject text;

	private Queue<string> sentence;

	public void Say(string sent)
	{
		GetComponent<MeshRenderer>().enabled = true;
		var speakor = audioOutput.GetComponent<TextToSpeech>();
		speakor.StartSpeaking(sent);
		text.GetComponent<TextMesh>().text = sent;
	}

	private string ProcessString(string input)
	{
		int count = 0;
		string output = string.Empty;
		foreach (char c in input)
		{
			if (count > 18)
			{
				count = 0;
				output += '\n';
			}
			if (c == '\n')
			{
				count = 0;
				output += c;
				continue;
			}
			output += c;
			count++;
		}
		return output;
	}
}