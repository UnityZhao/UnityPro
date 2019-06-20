using HedgehogTeam.EasyTouch;
using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonViewControl : MonoBehaviour
{
    //获取到场景中的Joystick
    public Rigidbody rigidbody;
    public ETCJoystick joysticka;
    //获取场景中的Button
    public ETCButton controlETCButton;
    public PuppetMaster puppetMaster;

    private void Start()
    {
        //EasyTouch自己的静态方法，通过摇杆的名字去查找哪个摇杆
        joysticka = ETCInput.GetControlJoystick("Joystick");
        controlETCButton = ETCInput.GetControlButton("Button");
        rigidbody = GetComponent<Rigidbody>();
        puppetMaster = transform.parent.Find("PuppetMaster").GetComponent<PuppetMaster>();
        // UnityEngine.Events.UnityAction listener = OnButtonClick;
        // controlETCButton.onDown.AddListener(listener);
        controlETCButton.onDown.AddListener(() => { OnHandAddForce(); });
        joysticka.OnPressUp.AddListener(() => { OnJoystickPressUp(); });
        joysticka.OnPressLeft.AddListener(() => { OnJoystickPressLeft(); });
        joysticka.OnPressRight.AddListener(() => { OnJoystickPressRight(); });
        joysticka.OnPressDown.AddListener(() => { OnJoystickPressDown(); });
    }

    private void OnHandAddForce()
    {
        foreach (var muscle in puppetMaster.muscles)
        {
            Debug.Log("muscles: " + muscle.joint.name);
            //muscle.joint.GetComponent<Rigidbody>().AddForce(0, 0, 100000);
        }
        Debug.Log("muscles: " + puppetMaster.muscles[11].joint.name);
        puppetMaster.muscles[11].joint.GetComponent<Rigidbody>().AddForce(0, 0, 1000000);
    }

    private void OnJoystickTouch()
    {

    }

    void OnJoystickPressUp()
    {
        rigidbody.AddForce(0, 0, 10);
    }

    void OnJoystickPressLeft()
    {
        rigidbody.AddForce(-10, 0, 0);
    }

    void OnJoystickPressRight()
    {
        rigidbody.AddForce(10, 0, 0);
    }

    void OnJoystickPressDown()
    {
        rigidbody.AddForce(0, 0, -10);
    }

    void Update()
    {
        //Debug.Log("speed: " + new Vector3(joysticka.axisX.axisValue, joysticka.axisY.axisValue, 0) * Time.deltaTime * 5);
        ////这是通过Translate移动的方法，我们可以看出controlETCJoystick.axisX.axisValue代表X方向的轴向，后者则是Y轴方向
        //this.transform.Translate(new Vector3(joysticka.axisX.axisValue, 0, joysticka.axisY.axisValue)  * Time.deltaTime * 5, Space.Self);
    }

}