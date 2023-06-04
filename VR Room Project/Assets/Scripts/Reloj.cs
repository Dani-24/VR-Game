using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public RelojTrigger horas;
    public RelojTrigger minutos;

    public bool horaYMinutosCorrectos = false;

    private void Update()
    {
        if(horas.isTriggered && minutos.isTriggered)
        {
            horaYMinutosCorrectos = true;
        }
    }
}
