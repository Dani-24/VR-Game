using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Caldero")
        {
            GenerateDrops comp = transform.parent.parent.GetComponent<GenerateDrops>();
            if (comp != null) 
            {
                if (comp.isReset == true)
                {
                    Animator anim = other.GetComponent<Animator>();
                    if (anim != null)
                    {
                        anim.SetTrigger("Reset");
                    }
                    Transform potionsParent = GameObject.Find("Potions").transform;
                    foreach (Transform potion in potionsParent) 
                    {
                        GenerateDrops potionDrops = potion.GetComponent<GenerateDrops>();
                        if (potionDrops != null) 
                        {
                            potionDrops.dropCount = 0;
                        }
                    }
                }
                else 
                {
                    comp.dropCount++;
                    if (comp.dropCount <= comp.dropMax)
                    {
                        Animator anim = other.GetComponent<Animator>();
                        if (anim != null)
                        {
                            anim.SetTrigger("Good");
                        }

                        Transform potionsParent = GameObject.Find("Potions").transform;

                        int totalCounts = 0;
                        int totalMax = 0;

                        foreach (Transform potion in potionsParent)
                        {
                            GenerateDrops potionDrops = potion.GetComponent<GenerateDrops>();
                            if (potionDrops != null)
                            {
                                totalCounts += potionDrops.dropCount;
                                totalMax += potionDrops.dropMax;
                            }
                        }

                        if (totalCounts == totalMax)
                        {
                            //sfx.Play(); 
                            GameObject.Find("Piedritas").gameObject.GetComponent<ActiveStones>().ActiveStone();
                            GameObject.Find("SFXpuzle").gameObject.GetComponent<AudioSource>().Play();
                        }
                       //> GameObject.Find("Piedritas").gameObject.GetComponent<ActiveStones>().ActiveStone();
                    }
                    else
                    {
                        Animator anim = other.GetComponent<Animator>();
                        if (anim != null)
                        {
                            anim.SetTrigger("Bad");
                        }
                    }
                }
            }

            Destroy(gameObject);
        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
