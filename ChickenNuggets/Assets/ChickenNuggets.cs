using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using System.Text.RegularExpressions;

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
    if (!moduleSolved)
    {
      if (Nuggie == Nuggies[0])
      {
        StartCoroutine(FuckMcShit());
      }
      else if (Nuggie == Nuggies[1])
      {
        CondonGenerator += 6;
        Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
      }
      else if (Nuggie == Nuggies[2])
      {
        CondonGenerator += 9;
        Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
      }
      else if (Nuggie == Nuggies[3])
      {
        CondonGenerator += 20;
        Debug.LogFormat("[Chicken Nuggets #{0}] Your current number is now {1}.", moduleId, CondonGenerator);
      }
    }
  }
  void NuggiesEnd(KMSelectable Nuggie){
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, Nuggie.transform);
    if (!moduleSolved)
    {
      if (Nuggie == Nuggies[0])
      {
        StopAllCoroutines();
        if (truefalse == true && Simp == true)
        {
          moduleSolved = true;
          GetComponent<KMBombModule>().HandlePass();
          Debug.LogFormat("[Chicken Nuggets #{0}] The number is impossible to make, and you determined that. Module disarmed.", moduleId, CondonGenerator);
          Audio.PlaySoundAtTransform("AwesomeSex", transform);
        }
        else if (truefalse == false && CondonGenerator == Boobies)
        {
          moduleSolved = true;
          GetComponent<KMBombModule>().HandlePass();
          Debug.LogFormat("[Chicken Nuggets #{0}] You inputted the right number. Module disarmed.", moduleId, CondonGenerator);
          Audio.PlaySoundAtTransform("AwesomeSex", transform);
        }
        else if (truefalse == true && Simp == false)
        {
          Debug.LogFormat("[Chicken Nuggets #{0}] You said the number was impossible to make, but I say it's not. Strike, burger consumer.", moduleId, CondonGenerator);
          Audio.PlaySoundAtTransform("wokgowekgoiwekgwegwegw", transform);
          GetComponent<KMBombModule>().HandleStrike();
          elapsed = 0f;
          truefalse = false;
          CondonGenerator = 0;
          StartCoroutine(GenerateMcNumeros());
        }
        else
        {
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
      case 1: case 2: case 3: case 4: case 5: case 7: case 8: case 10: case 11: case 13: case 14: case 16: case 17: case 19: case 22: case 23: case 25: case 28: case 31: case 34: case 37: case 43:
      Simp = true;
      break;
    }
    Debug.LogFormat("[Chicken Nuggets #{0}] The target number is {1}.", moduleId, Boobies);
    McBlowjob.text = Boobies.ToString();
    yield return null;
  }

    //twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} press 6 9 20 <s/sub/submit> [Presses the buttons on the bottom in order from left to right and then presses the top one] | !{0} drown [Holds down the top button and releases it after a second]";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*drown\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            Nuggies[0].OnInteract();
            yield return new WaitForSeconds(1f);
            Nuggies[0].OnInteractEnded();
            yield break;
        }
        if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) || Regex.IsMatch(command, @"^\s*sub\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant) || Regex.IsMatch(command, @"^\s*s\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            Nuggies[0].OnInteract();
            yield return new WaitForSeconds(0.1f);
            Nuggies[0].OnInteractEnded();
            yield break;
        }
        string[] parameters = command.Split(' ');
        if (Regex.IsMatch(parameters[0], @"^\s*press\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (parameters.Length == 1)
            {
                yield return "sendtochaterror Please specify which buttons to press!";
                yield break;
            }
            string[] valids = { "s", "sub", "submit", "6", "9", "20" };
            for (int i = 1; i < parameters.Length; i++)
            {
                if (!valids.Contains(parameters[i].ToLower()))
                {
                    yield return "sendtochaterror The specified button to press '" + parameters[i] + "' is invalid!";
                }
            }
            for (int i = 1; i < parameters.Length; i++)
            {
                if (parameters[i].EqualsIgnoreCase("s") || parameters[i].EqualsIgnoreCase("sub") || parameters[i].EqualsIgnoreCase("submit"))
                {
                    Nuggies[0].OnInteract();
                    yield return new WaitForSeconds(0.1f);
                    Nuggies[0].OnInteractEnded();
                }
                else if (parameters[i].EqualsIgnoreCase("6"))
                {
                    Nuggies[1].OnInteract();
                }
                else if (parameters[i].EqualsIgnoreCase("9"))
                {
                    Nuggies[2].OnInteract();
                }
                else if (parameters[i].EqualsIgnoreCase("20"))
                {
                    Nuggies[3].OnInteract();
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        if (Simp)
        {
            Nuggies[0].OnInteract();
            while (elapsed < duration) { yield return true; yield return new WaitForSeconds(0.1f); }
            Nuggies[0].OnInteractEnded();
        }
        else
        {
            string[] vals;
            string temp = "";
            switch (Boobies)
            {
                case 0: temp = "0 0 0"; break;
                case 6: temp = "1 0 0"; break;
                case 9: temp = "0 1 0"; break;
                case 12: temp = "2 0 0"; break;
                case 15: temp = "1 1 0"; break;
                case 18: temp = "3 0 0"; break;
                case 20: temp = "0 0 1"; break;
                case 21: temp = "2 1 0"; break;
                case 24: temp = "4 0 0"; break;
                case 26: temp = "1 0 1"; break;
                case 27: temp = "0 3 0"; break;
                case 29: temp = "0 1 1"; break;
                case 30: temp = "5 0 0"; break;
                case 32: temp = "2 0 1"; break;
                case 33: temp = "1 3 0"; break;
                case 35: temp = "1 1 1"; break;
                case 36: temp = "6 0 0"; break;
                case 38: temp = "3 0 1"; break;
                case 39: temp = "5 1 0"; break;
                case 40: temp = "0 0 2"; break;
                case 41: temp = "2 1 1"; break;
                case 42: temp = "7 0 0"; break;
                case 44: temp = "4 0 1"; break;
                case 45: temp = "3 3 0"; break;
                case 46: temp = "1 0 2"; break;
                case 47: temp = "0 3 1"; break;
                case 48: temp = "8 0 0"; break;
                case 49: temp = "0 1 2"; break;
                case 50: temp = "6 0 1"; break;
                case 51: temp = "7 1 0"; break;
                case 52: temp = "2 0 2"; break;
                case 53: temp = "1 3 1"; break;
                case 54: temp = "0 6 0"; break;
                case 55: temp = "1 1 2"; break;
                case 56: temp = "6 0 1"; break;
                case 57: temp = "5 3 0"; break;
                case 58: temp = "3 0 2"; break;
                case 59: temp = "5 1 1"; break;
                case 60: temp = "0 0 3"; break;
                case 61: temp = "2 1 2"; break;
                case 62: temp = "7 0 1"; break;
                case 63: temp = "6 3 0"; break;
                case 64: temp = "4 0 2"; break;
                case 65: temp = "6 1 1"; break;
                case 66: temp = "1 0 3"; break;
                case 67: temp = "3 1 2"; break;
                case 68: temp = "8 0 1"; break;
                case 69: temp = "7 3 0"; break;
                case 70: temp = "5 0 2"; break;
                case 71: temp = "7 1 1"; break;
                case 72: temp = "2 0 3"; break;
                case 73: temp = "4 1 2"; break;
                case 74: temp = "8 0 1"; break;
                case 75: temp = "8 3 0"; break;
                case 76: temp = "6 0 2"; break;
                case 77: temp = "8 1 1"; break;
                case 78: temp = "3 0 3"; break;
                case 79: temp = "5 1 2"; break;
                case 80: temp = "9 0 1"; break;
                case 81: temp = "9 3 0"; break;
                case 82: temp = "7 0 2"; break;
                case 83: temp = "9 1 1"; break;
                case 84: temp = "4 0 3"; break;
                case 85: temp = "6 1 2"; break;
                case 86: temp = "10 0 1"; break;
                case 87: temp = "10 3 0"; break;
                case 88: temp = "8 0 2"; break;
                case 89: temp = "10 1 1"; break;
                case 90: temp = "5 0 3"; break;
                case 91: temp = "7 1 2"; break;
                case 92: temp = "11 0 1"; break;
                case 93: temp = "11 3 0"; break;
                case 94: temp = "9 0 2"; break;
                case 95: temp = "11 1 1"; break;
                case 96: temp = "6 0 3"; break;
                case 97: temp = "8 1 2"; break;
                case 98: temp = "12 0 1"; break;
                case 99: temp = "12 3 0"; break;
                case 100: temp = "0 0 5"; break;
                case 101: temp = "2 1 4"; break;
                case 102: temp = "7 0 3"; break;
                case 103: temp = "6 3 2"; break;
                case 104: temp = "4 0 4"; break;
                case 105: temp = "7 7 0"; break;
                case 106: temp = "1 0 5"; break;
                case 107: temp = "3 1 4"; break;
                case 108: temp = "8 0 3"; break;
                case 109: temp = "0 1 5"; break;
                case 110: temp = "5 0 4"; break;
                case 111: temp = "8 7 0"; break;
                case 112: temp = "2 0 5"; break;
                case 113: temp = "4 1 4"; break;
                case 114: temp = "9 0 3"; break;
                case 115: temp = "8 3 2"; break;
                case 116: temp = "6 0 4"; break;
                case 117: temp = "9 7 0"; break;
                case 118: temp = "3 0 5"; break;
                case 119: temp = "5 1 4"; break;
                case 120: temp = "0 0 6"; break;
                case 121: temp = "9 3 2"; break;
                case 122: temp = "7 0 4"; break;
                case 123: temp = "0 7 3"; break;
                case 124: temp = "4 0 0"; break;
                case 125: temp = "6 1 4"; break;
                case 126: temp = "1 0 6"; break;
                case 127: temp = "0 3 3"; break;
                case 128: temp = "8 0 4"; break;
                case 129: temp = "1 7 3"; break;
                case 130: temp = "5 0 5"; break;
                case 131: temp = "7 1 4"; break;
                case 132: temp = "2 0 4"; break;
                case 133: temp = "1 3 3"; break;
                case 134: temp = "9 0 4"; break;
                case 135: temp = "2 7 3"; break;
                case 136: temp = "6 0 5"; break;
                case 137: temp = "8 1 4"; break;
                case 138: temp = "3 0 4"; break;
                case 139: temp = "2 3 3"; break;
                case 140: temp = "0 0 7"; break;
                case 141: temp = "3 7 3"; break;
                case 142: temp = "7 0 5"; break;
                case 143: temp = "9 1 4"; break;
                case 144: temp = "4 0 4"; break;
                case 145: temp = "3 3 3"; break;
                case 146: temp = "1 0 7"; break;
                case 147: temp = "4 7 3"; break;
                case 148: temp = "8 0 5"; break;
                case 149: temp = "0 1 5"; break;
                case 150: temp = "5 0 4"; break;
                case 151: temp = "4 3 3"; break;
                case 152: temp = "2 0 7"; break;
                case 153: temp = "5 7 3"; break;
                case 154: temp = "0 6 5"; break;
                case 155: temp = "1 1 5"; break;
                case 156: temp = "6 0 4"; break;
                case 157: temp = "5 3 3"; break;
                case 158: temp = "3 0 7"; break;
                case 159: temp = "6 7 3"; break;
                case 160: temp = "0 0 8"; break;
                case 161: temp = "2 1 5"; break;
                case 162: temp = "7 0 4"; break;
                case 163: temp = "6 3 3"; break;
                case 164: temp = "4 0 7"; break;
                case 165: temp = "7 7 3"; break;
                case 166: temp = "1 0 8"; break;
                case 167: temp = "3 1 5"; break;
                case 168: temp = "8 0 4"; break;
                case 169: temp = "7 3 3"; break;
                case 170: temp = "5 0 7"; break;
                case 171: temp = "8 7 3"; break;
                case 172: temp = "2 0 8"; break;
                case 173: temp = "4 1 5"; break;
                case 174: temp = "9 0 4"; break;
                case 175: temp = "8 3 3"; break;
                case 176: temp = "6 0 7"; break;
                case 177: temp = "9 7 3"; break;
                case 178: temp = "3 0 8"; break;
                case 179: temp = "5 1 5"; break;
                case 180: temp = "0 0 9"; break;
                case 181: temp = "9 3 3"; break;
                case 182: temp = "7 0 7"; break;
                case 183: temp = "0 7 4"; break;
                case 184: temp = "4 0 3"; break;
                case 185: temp = "6 1 5"; break;
                case 186: temp = "1 0 9"; break;
                case 187: temp = "0 3 8"; break;
                case 188: temp = "8 0 7"; break;
                case 189: temp = "1 7 4"; break;
                case 190: temp = "5 0 3"; break;
                case 191: temp = "7 1 5"; break;
                case 192: temp = "2 0 9"; break;
                case 193: temp = "1 3 8"; break;
                case 194: temp = "9 0 7"; break;
                case 195: temp = "2 7 4"; break;
                case 196: temp = "6 0 8"; break;
                case 197: temp = "8 1 5"; break;
                case 198: temp = "3 0 9"; break;
                case 199: temp = "2 3 8"; break;
                case 200: temp = "0 0 10"; break;
            }
            vals = temp.Split(' ');
            for (int j = 1; j < 4; j++)
            {
                for (int i = 0; i < int.Parse(vals[j-1]); i++)
                {
                    Nuggies[j].OnInteract();
                    yield return new WaitForSeconds(0.1f);
                }
            }
            Nuggies[0].OnInteract();
            yield return new WaitForSeconds(0.1f);
            Nuggies[0].OnInteractEnded();
        }
    }
}
