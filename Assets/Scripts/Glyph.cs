using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : MonoBehaviour
{
    public bool activated;
    public string symbol;

    Renderer rend;

    public Material baseMat;
    public Material selectedMat;

    public Address address;

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        symbol = this.name;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        /*!!!DHD USE ONLY!!!*/
        if (address.addressList.Count <= 6) /*TODO: if the address has 7 glyphs, disable all glyphs, and only allow the big red button (maybe with a highlight?)*/
        {
            if (!activated)
            {
                rend.material = selectedMat;

                address.addressList.Add(symbol);

                #region per DHD button press, play a sound related to that button press
                switch (address.addressList.Count)
                {
                    case 1: /*play sound 1*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 2: /*play sound 2*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 3: /*play sound 3*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 4: /*play sound 4*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 5: /*play sound 5*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 6: /*play sound 6*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                    case 7: /*play sound 7*/
                        FindObjectOfType<AudioManager>().Play($"dhd_usual_{address.addressList.Count}");
                        break;
                }
                #endregion

            }
            else
            {
                rend.material = baseMat;
                address.addressList.Remove(symbol);
            }
        }
        else
        {
            /*do i need this?*/
        }

        if (!activated && symbol == "BigRedButton")
        {
            /*onces the BigRedButton has been pressed, activate the gate aka Create the wormhole or clear the addressList*/
            if (address.addressList.Count < 6)
            {
                address.addressList.Clear();

                /*TODO: foreach glyph that is activated, reset the mat to baseMat*/
            }
        }
        activated = !activated;

        //
    }
}