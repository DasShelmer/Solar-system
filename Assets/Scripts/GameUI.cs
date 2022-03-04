using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameUI : MonoBehaviour {

    public float CoefOfPlanetsSpeed = 1, TrailWidth = 1;

    public float DescryptsWidth = 400, DescryptsHeight = 600;

    GameObject Mercury;
    GameObject Venus;
    GameObject Earth;
    GameObject Mars;
    GameObject Jupiter;
    GameObject Saturn;
    GameObject Uranus;
    GameObject Neptune;
    GameObject Sun;

    GameObject LastHitObj;

    Vector3 a1;

    Ray ray;
    RaycastHit rHit;

    

    bool MercuryText;
    bool VenusText;
    bool EarthText;
    bool MarsText;
    bool JupiterText;
    bool SaturnText;
    bool UranusText;
    bool NeptuneText;
    bool SunText;

    string Descrpt8Sun;
    string Descrpt8Mercury;
    string Descrpt8Venus;
    string Descrpt8Earth;
    string Descrpt8Mars;
    string Descrpt8Jupiter;
    string Descrpt8Saturn;
    string Descrpt8Uranus;
    string Descrpt8Neptune;

    string GUI8Planets_speed;
    string GUI8Camera_speed;
    string GUI8Cam_Teleport;
    string GUI8To_Mercury;
    string GUI8To_Venus;
    string GUI8To_Earth;
    string GUI8To_Mars;
    string GUI8To_Jupiter;
    string GUI8To_Saturn;
    string GUI8To_Uran;
    string GUI8To_Neptune;
    string GUI8TrailWight;
    string GUI8Quit;
    public string[] tr;

    void Start ()
    {
        LastHitObj = GameObject.Find("Sun");
        
        tr = File.ReadAllLines("Config.cfg");

        Descrpt8Sun = tr[0].Remove(0,12).Replace("`", "\n");
        Descrpt8Mercury = tr[1].Remove(0,"Descrpt:Mercury=".Length).Replace("`", "\n");
        Descrpt8Venus = tr[2].Remove(0, "Descrpt:Venus=".Length).Replace("`", "\n");
        Descrpt8Earth = tr[3].Remove(0, "Descrpt:Earth=".Length).Replace("`", "\n");
        Descrpt8Mars = tr[4].Remove(0, "Descrpt:Mars=".Length).Replace("`", "\n");
        Descrpt8Jupiter = tr[5].Remove(0, "Descrpt:Jupiter=".Length).Replace("`", "\n");
        Descrpt8Saturn = tr[6].Remove(0, "Descrpt:Saturn=".Length).Replace("`", "\n");
        Descrpt8Uranus = tr[7].Remove(0, "Descrpt:Uranus=".Length).Replace("`", "\n");
        Descrpt8Neptune = tr[8].Remove(0, "Descrpt:Neptune=".Length).Replace("`", "\n");

        GUI8Planets_speed = tr[9].Remove(0, "GUI:Planets_speed=".Length);
        GUI8Camera_speed = tr[10].Remove(0, "GUI:Camera_speed=".Length);
        GUI8Cam_Teleport = tr[11].Remove(0, "GUI:Cam_Teleport=".Length);
        GUI8To_Mercury = tr[12].Remove(0, "GUI:To_Mercury=".Length);
        GUI8To_Venus = tr[13].Remove(0, "GUI:To_Venus=".Length);
        GUI8To_Earth = tr[14].Remove(0, "GUI:To_Earth=".Length);
        GUI8To_Mars = tr[15].Remove(0, "GUI:To_Mars=".Length);
        GUI8To_Jupiter = tr[16].Remove(0, "GUI:To_Jupiter=".Length);
        GUI8To_Saturn = tr[17].Remove(0,"GUI:To_Saturn=".Length);
        GUI8To_Uran = tr[18].Remove(0, "GUI:To_Uran=".Length);
        GUI8To_Neptune = tr[19].Remove(0, "GUI:To_Neptune=".Length);
        GUI8TrailWight = tr[20].Remove(0, "GUI:Trail_Wight=".Length);
        GUI8Quit = tr[21].Remove(0, "GUI:Quit=".Length);

        DescryptsHeight = Convert.ToSingle(tr[22].Remove(0, "DescryptsHeight=".Length));
        DescryptsWidth = Convert.ToSingle(tr[23].Remove(0, "DescryptsWidht=".Length));
        transform.GetComponent<Camera>().fieldOfView = Convert.ToSingle(tr[24].Remove(0, "FOV=".Length));

        Screen.SetResolution(Convert.ToInt32(tr[26].Remove(0, "ScreenWidth=".Length)), Convert.ToInt32(tr[27].Remove(0, "ScreenHeight=".Length)), Convert.ToBoolean(tr[25].Remove(0, "FullScreen=".Length)));

    }
	
	void FixedUpdate () {
        if (Mercury == null || Venus == null || Earth == null || Mars == null || Jupiter == null || Uranus == null || Neptune == null || Sun == null)
        {
            Mercury = GameObject.Find("CenterOfGravityToMercury/Mercury");
            Venus = GameObject.Find("CenterOfGravityToVenus/Venus");
            Earth = GameObject.Find("CenterOfGravityToEarth/Earth");
            Mars = GameObject.Find("CenterOfGravityToMars/Mars");
            Jupiter = GameObject.Find("CenterOfGravityToJupiter/Jupiter");
            Saturn = GameObject.Find("CenterOfGravityToSaturn/Saturn");
            Uranus = GameObject.Find("CenterOfGravityToUranus/Uranus");
            Neptune = GameObject.Find("CenterOfGravityToNeptune/Neptune");
            Sun = GameObject.Find("CenterOfGravityToSun/Sun");
        }

       
        



        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rHit, Mathf.Infinity))
            {
                LastHitObj = rHit.transform.gameObject;
                if (rHit.transform.name == "Mercury")
                {
                    ClearPlanetsText();
                    MercuryText = true;
                }
                if (rHit.transform.name == "Venus")
                {
                    ClearPlanetsText();
                    VenusText = true;
                }
                if (rHit.transform.name == "Earth")
                {
                    ClearPlanetsText();
                    EarthText = true;
                }
                if (rHit.transform.name == "Mars")
                {
                    ClearPlanetsText();
                    MarsText = true;
                }
                if (rHit.transform.name == "Jupiter")
                {
                    ClearPlanetsText();
                    JupiterText = true;
                }
                if (rHit.transform.name == "Uranus")
                {
                    ClearPlanetsText();
                    UranusText = true;
                }
                if (rHit.transform.name == "Saturn")
                {
                    ClearPlanetsText();
                    SaturnText = true;
                }
                if (rHit.transform.name == "Neptune")
                {
                    ClearPlanetsText();
                    NeptuneText = true;
                }
                if (rHit.transform.name == "Sun")
                {
                    ClearPlanetsText();
                    SunText = true;
                }
            }
        }






    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 217, Screen.height-20, 400, 20), GUI8Camera_speed);
        gameObject.GetComponent<Moving>().CamSpeed = GUI.HorizontalSlider(new Rect(Screen.width-111, Screen.height-15, 100, 30), gameObject.GetComponent<Moving>().CamSpeed, 1.0F, 800.0F);

        GUI.Label(new Rect(5, Screen.height - 20, 400, 20), GUI8Planets_speed);
        CoefOfPlanetsSpeed = GUI.HorizontalSlider(new Rect(116, Screen.height - 15, 100, 30), CoefOfPlanetsSpeed, 0.0F, 150.0F);

        GUI.Label(new Rect(Screen.width/2-60, Screen.height - 20, 400, 20), GUI8TrailWight);
        TrailWidth = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 50, Screen.height - 15, 100, 30), TrailWidth, 1.0F, 50.0F);

        if (GUI.Button(new Rect(Screen.width - 85, 5, 80, 20), GUI8Quit))
        {
            Application.Quit();
        }

        #region Camera Teleport
        GUI.Box(new Rect(5, 10, 150, 260), GUI8Cam_Teleport);
        if (GUI.Button(new Rect(15, 35, 130, 20), GUI8To_Mercury))
        {
            transform.position= Mercury.transform.position;
        }

        if (GUI.Button(new Rect(15, 65, 130, 20), GUI8To_Venus))
        {
            transform.position = Venus.transform.position;
        }

        if (GUI.Button(new Rect(15, 95, 130, 20), GUI8To_Earth))
        {
            transform.position = Earth.transform.position;
        }

        if(GUI.Button(new Rect(15, 125, 130, 20), GUI8To_Mars))
        {
            transform.position = Mars.transform.position;
        }

        if (GUI.Button(new Rect(15, 155, 130, 20), GUI8To_Jupiter))
        {
            transform.position = Jupiter.transform.position;
        }

        if (GUI.Button(new Rect(15, 185, 130, 20), GUI8To_Saturn))
        {
            transform.position = Saturn.transform.position;
        }

        if (GUI.Button(new Rect(15, 215, 130, 20), GUI8To_Uran))
        {
            transform.position = Uranus.transform.position;
        }

        if (GUI.Button(new Rect(15, 245, 130, 20), GUI8To_Neptune))
        {
            transform.position = Neptune.transform.position;
        }
        #endregion

        
        a1 = Camera.main.WorldToScreenPoint(LastHitObj.transform.position);
        if (Vector3.Angle(transform.forward, LastHitObj.transform.position - transform.position) < 95)
        {
            if (MercuryText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Mercury);
            }
            if (VenusText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Venus);
            }
            if (EarthText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Earth);
            }
            if (MarsText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Mars);
            }
            if (JupiterText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Jupiter);
            }
            if (SaturnText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Saturn);
            }
            if (UranusText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Uranus);
            }
            if (NeptuneText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Neptune);
            }
            if (SunText)
            {
                GUI.TextArea(new Rect(a1.x, Screen.height - a1.y, DescryptsWidth, DescryptsHeight), Descrpt8Sun);
            }
        }

    }

    public void ClearPlanetsText()
    {
        MercuryText = false;
        VenusText = false;
        EarthText = false;
        MarsText = false;
        JupiterText = false;
        SaturnText = false;
        UranusText = false;
        NeptuneText = false;
        SunText = false;
    }
}
