using UnityEngine;
using System.Collections;

public class MicrophoneInput : MonoBehaviour {

	public float MicLoudness;
	private string _device;
	AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	void Start()
	{
//		if(_device == null) _device = Microphone.devices[1];
		if(_device == null) _device = Microphone.devices[0];

		_clipRecord = Microphone.Start(_device, true, 999, 44100);
	}

	void OnDestroy()
	{Microphone.End(_device);}

	float  LevelMax()
	{
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
//		int micPosition = Microphone.GetPosition(Microphone.devices[1])-(_sampleWindow+1); // null means the first microphone
		int micPosition = Microphone.GetPosition(Microphone.devices[0])-(_sampleWindow+1); // null means the first microphone

		if (micPosition < 0) return 0;
		_clipRecord.GetData(waveData, micPosition);
		// Getting a peak on the last 128 samples
		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}

	void Update()
	{
		MicLoudness = LevelMax ();
	}
}
