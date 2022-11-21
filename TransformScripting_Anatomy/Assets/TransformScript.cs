using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript : MonoBehaviour
{
    public GameObject BodyObj;
    public GameObject ResObj;
    public GameObject CirObj;
    public GameObject DigObj;  
    public GameObject ExObj;
   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.localScale = new Vector3(1, 1, 1);

        Body();
        Respiratory();
        Circulatory();
        Digestive();
        Excretory();
    }

    public void Body() 
    {
        //1. Skin
        //position   
        BodyObj.transform.Find("Skin").Translate(new Vector3(-242.325f, 850.45f, 129.165f));
        //rotation
        BodyObj.transform.Find("Skin").rotation = Quaternion.Euler(new Vector3(90, 180, 0));
        //scale

        //2. Bone  
        BodyObj.transform.Find("Bone").Translate(new Vector3(-237.53f, 850.45f, 129.165f));
        BodyObj.transform.Find("Bone").rotation = Quaternion.Euler(new Vector3(90, 180, 0));

        //3. Muscle
        BodyObj.transform.Find("Muscle").Translate(new Vector3(-241.015f, 823.8f, 117.69f));
        BodyObj.transform.Find("Muscle").rotation = Quaternion.Euler(new Vector3(90, 180, 0));


    }

    public void Respiratory()
    {
        //Lung
        ResObj.transform.Find("Lung").Translate(new Vector3(-233, 1215, 129));
        ResObj.transform.Find("Lung").rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        //Bronchi
        ResObj.transform.Find("Bronchi").Translate(new Vector3(-254, 1252, 120));
        ResObj.transform.Find("Bronchi").rotation = Quaternion.Euler(new Vector3(90, 0, 180));

       

    }

    public void Circulatory()
    {       
        //Heart
        CirObj.transform.Find("Heart").Translate(new Vector3(-257, 1230, 149));
        CirObj.transform.Find("Heart").rotation = Quaternion.Euler(new Vector3(90, 0,0));
   
    }

    public void Digestive() 
    {
        
        //SmallIntestine
        DigObj.transform.Find("SmallIntestine").Translate(new Vector3(-226, 948, 113));
        DigObj.transform.Find("SmallIntestine").rotation = Quaternion.Euler(new Vector3(90, 0, 180));

        //LargeIntestine
        DigObj.transform.Find("LargeIntestine").Translate(new Vector3(-231, 906, 126));
        DigObj.transform.Find("LargeIntestine").rotation = Quaternion.Euler(new Vector3(90, 0, 180));

        //Stomach
        DigObj.transform.Find("Stomach").Translate(new Vector3(-151f, 1044, 134));
        DigObj.transform.Find("Stomach").rotation = Quaternion.Euler(new Vector3(71.661f, -158.743f, 39.562f));

        //Liver
        DigObj.transform.Find("Liver").Translate(new Vector3(-244, 1050, 119));
        DigObj.transform.Find("Liver").rotation = Quaternion.Euler(new Vector3(90, 0, 180));


    }

    public void Excretory()
    {
        //Kidney
        ExObj.transform.Find("Kidney").Translate(new Vector3(-245, 1102, 193.0977f));
        ExObj.transform.Find("Kidney").rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        //UrinaryBladder
        ExObj.transform.Find("UrinaryBladder").Translate(new Vector3(-222, 803, 157));
        ExObj.transform.Find("UrinaryBladder").rotation = Quaternion.Euler(new Vector3(90, 0, 0));


    }
}
