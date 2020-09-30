using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemController : MonoBehaviour
{
    Vector3 getItemPos;
    Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        Pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnUserAction()
    {
        getItemPos = GameObject.Find(PlayerController.IP).transform.position;
        Pos = getItemPos;
        this.gameObject.transform.position = Pos;
    }
}
