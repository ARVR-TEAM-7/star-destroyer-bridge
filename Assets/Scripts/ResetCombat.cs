using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCombat : MonoBehaviour
{
    [SerializeField] private ShipMovement[] shipsToReset;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ResetShips());
    }


    private IEnumerator ResetShips()
    {
        while (true)
        {
            yield return new WaitForSeconds(26);
            foreach (ShipMovement ship in shipsToReset)
            {
                ship.ResetTransform();
            }
        }
    }
}
