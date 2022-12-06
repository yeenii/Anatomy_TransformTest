using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScripting : MonoBehaviour
{
    //Anatomy Model
    public GameObject [] model= new GameObject[100]; //Skin - 0, Lung - 1
        
    //OrgScale 
    float[,] orgScale = { { 968F, 3400F, 516F },{604F,648F,378F } }; //org model scale
    float[,] mScale = { { 484.65F, 1700.9F, 258.33F },{ 302.15f, 324.03F, 189.75F} }; //unity model scale 
    float[,] tScale= new float[2,3]; //���� ������ ���� 

    //OrgPosition
    float[,] Position = { { -242.325F, 850.45F, 129.165F },{ -233F, 1215F, 129F } };
 

    // Start is called before the first frame update
    void Start()
    {
        Rotation(); //���� ������ 

        MakeRate(); //���� ���ϴ� �޼���
        TargetScale(); 
        TargetPosition();
    }

    public void Rotation() //���� 
    {
        //�ʱⰪ 
        model[0].transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
        model[1].transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }

    public void TargetPosition()
    {
        for (int i = 0; i < model.Length; i++)
        {
            model[i].transform.position = new Vector3(Position[i, 0] * tScale[i, 0], Position[i, 1] * tScale[i, 1], Position[i, 2] * tScale[i, 2]);
        }
        //obj1.transform.position = new Vector3(Position[0, 0] * tScale[0, 0], Position[0, 1] * tScale[0, 1], Position[0, 2] * tScale[0, 2]);
        //obj2.transform.position = new Vector3(Position[1, 0] * tScale[1, 0], Position[1, 1] * tScale[1, 1], Position[1, 2] * tScale[1, 2]);
    }

    public void TargetScale()
    {
        //scale
        for (int i = 0; i < model.Length; i++)
        {
            model[i].transform.localScale = new Vector3(tScale[i, 0], tScale[i, 2], tScale[i, 1]);
        }
        //obj1.transform.localScale = new Vector3(tScale[0, 0], tScale[0, 2], tScale[0, 1]);
        //obj2.transform.localScale = new Vector3(tScale[1, 0], tScale[1, 2], tScale[1, 1]);
    }

    public void MakeRate() //���� ���ϴ� �޼���
    {      

        int i,k;
        float[,] orgNum = new float[2, 3];
        float[,] mNum = new float[2, 3];

        for (k = 0; k < 2; k++)
        {
            for (i = 0; i < 3; i++)
            {
                //���� ������ ��� -> ����� ��ȯ 
                if (mScale[k,i] < 0)
                    mScale[k,i] = -mScale[k,i];

                if (orgScale[k,i] < 0)
                    orgScale[k,i] = -orgScale[k,i];

                //cnt : ��� ������������ ���ϱ� ���� 
                int j;
                int cnt = 1;

                if (orgScale[k,i] >= mScale[k,i]) //num1�� num2���� ū ��� 
                {
                    for (j = 1; j <= orgScale[k,i]; j++)
                    {
                        if (orgScale[k,i] % j == 0 && mScale[k,i] % j == 0)
                            cnt++;

                    }
                }
                else
                {
                    for (j = 1; j <= mScale[k,i]; j++)
                    {
                        if (orgScale[k,i] % j == 0 && mScale[k,i] % j == 0)
                            cnt++;

                    }
                }

                //��ʽ� ���ϱ� 
                if (cnt == 1)
                {
                    orgNum[k,i] = orgScale[k,i];
                    mNum[k,i] = mScale[k,i];
                }
                else
                {
                    for (j = 1; j <= orgScale[k,i]; j++)
                    {
                        if (orgScale[k,i] % j == 0 && mScale[k,i] % j == 0)
                        {
                            orgNum[k,i] = orgScale[k,i] / j;
                            mNum[k,i] = mScale[k,i] / j;
                        }

                    }
                }

                //���� ���ϱ�  
                tScale[k,i] = mNum[k,i] * 1 / orgNum[k,i];

            } //for�� i end
        } // for�� k end
        

    }

}
