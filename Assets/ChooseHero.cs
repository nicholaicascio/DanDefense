using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ChooseHero : MonoBehaviour
{

    //public GameObject characterSelect;
    public GameObject btn1;
    public GameObject btn2;

    public void PickHero(int hero)
    {
        NetworkManager.singleton.GetComponent<NetworkCustom>().chosenCharacter = hero;
        //characterSelect.SetActive(false);
        btn1.SetActive(false);
        btn2.SetActive(false);
    }
}