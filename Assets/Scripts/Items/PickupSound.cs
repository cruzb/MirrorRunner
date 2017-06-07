using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour {

	public AudioSource source;
	public AudioClip sound;

	public void PlayPickupSound() {
		source.clip = sound;
		source.Play();
	}
}
