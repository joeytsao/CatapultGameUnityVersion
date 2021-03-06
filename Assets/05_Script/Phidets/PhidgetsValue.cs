using UnityEngine;
using System.Collections;
using Phidgets;

public class PhidgetsValue : MonoBehaviour {


    InterfaceKit ifKit;
    public int[] _PhidgetsValue;
    // Use this for initialization
    void Start()
    {
        //ifKit.close();
        ifKit = new InterfaceKit();
        ifKit.open();
        ifKit.waitForAttachment(1000);
        _PhidgetsValue = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        if (ifKit != null)
        {
            for (int i = 0; i <= 7; i++)
                _PhidgetsValue[i] = ifKit.sensors[i].Value;
        }

        //�O�D�P��
        if (_PhidgetsValue[0] > 100)
        {
            CatapultFire.fire = true;
        }
        else
            CatapultFire.fire = false;
        //�Z���P��
        GameManeger.script.distance = (999 -_PhidgetsValue[1])/25;
    }

    void OnDestroy()
    {
        ifKit.close();
    }


}
