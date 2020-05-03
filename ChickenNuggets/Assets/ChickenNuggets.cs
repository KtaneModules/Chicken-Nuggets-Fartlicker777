using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class ChickenNuggets : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Nuggies;
    public GameObject Commie;
    public Material[] McDonalds;
    public TextMesh McBlowjob;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int COMMIE = 0;
    int Boobies = 0;
    bool Simp = false;
    bool truefalse = false;
    int CondonGenerator = 0;
    float elapsed = 0f;
    float duration = 1f;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Nuggie in Nuggies) {
                    Nuggie.OnInteract += delegate () { NuggiesPress(Nuggie); return false; };
          }
        foreach (KMSelectable Nuggie in Nuggies) {
                    Nuggie.OnInteractEnded += delegate () { NuggiesEnd(Nuggie);};
          }
    }
    void Start () {
      StartCoroutine(GenerateMcNumeros());
      COMMIE = UnityEngine.Random.Range(0,101);
      if (COMMIE == 69) {
        Commie.GetComponent<MeshRenderer>().material = McDonalds[1];
      }
	}
  void NuggiesPress(KMSelectable Nuggie){
    Nuggie.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Nuggie.transform);
    if (Nuggie == Nuggies[0]) {
      StartCoroutine(FuckMcShit());
    }
    else if (Nuggie == Nuggies[1]) {
      CondonGenerator += 6;
      Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
    }
    else if (Nuggie == Nuggies[2]) {
      CondonGenerator += 9;
      Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
    }
    else if (Nuggie == Nuggies[3]) {
      CondonGenerator += 20;
      Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
    }
  }
  void NuggiesEnd(KMSelectable Nuggie){
    if (Nuggie == Nuggies[0]) {
      StopAllCoroutines();
      if (truefalse == true && Simp == true) {
        GetComponent<KMBombModule>().HandlePass();
        Debug.LogFormat("[Chicken Nuggets #{0}] The number is impossible to make, and you determined that. Module disarmed.", moduleId, CondonGenerator);
        Audio.PlaySoundAtTransform("AwesomeSex", transform);
      }
      else if (truefalse == false && CondonGenerator == Boobies) {
        GetComponent<KMBombModule>().HandlePass();
        Debug.LogFormat("[Chicken Nuggets #{0}] You inputted the right number. Module disarmed.", moduleId, CondonGenerator);
        Audio.PlaySoundAtTransform("AwesomeSex", transform);
      }
      else if (truefalse == true && Simp == false) {
        Debug.LogFormat("[Chicken Nuggets #{0}] You said the number was impossible to make, but I say it's not. Strike, burger consumer.", moduleId, CondonGenerator);
        Audio.PlaySoundAtTransform("wokgowekgoiwekgwegwegw", transform);
        GetComponent<KMBombModule>().HandleStrike();
        elapsed = 0f;
        truefalse = false;
        CondonGenerator = 0;
        StartCoroutine(GenerateMcNumeros());
      }
      else {
        Debug.LogFormat("[Chicken Nuggets #{0}] You inputted the wrong number. Strike, fries slurper.", moduleId, CondonGenerator);
        Audio.PlaySoundAtTransform("wokgowekgoiwekgwegwegw", transform);
        GetComponent<KMBombModule>().HandleStrike();
        elapsed = 0f;
        truefalse = false;
        CondonGenerator = 0;
        StartCoroutine(GenerateMcNumeros());
      }
    }
  }
  IEnumerator FuckMcShit(){
    while (elapsed < duration){
      yield return null;
      elapsed += Time.deltaTime;
    }
    truefalse = true;
  }
  IEnumerator GenerateMcNumeros(){
    Boobies = UnityEngine.Random.Range(0,201);
    switch (Boobies) {
      case 1: case 2: case 3: case 4: case 5: case 7: case 8: case 9: case 10: case 11: case 13: case 14: case 16: case 17: case 19: case 22: case 23: case 25: case 28: case 31: case 34: case 37: case 43:
      Simp = true;
      break;
    }
    Debug.LogFormat("[Chicken Nuggets #{0}] The target number is {1}.", moduleId, Boobies);
    McBlowjob.text = Boobies.ToString();
    yield return null;
  }
}
