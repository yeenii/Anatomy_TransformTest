using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScripting : MonoBehaviour
{

    TransformLink tl;

    float[,] tScale= new float[2,3]; //비율 데이터 저장 

    // Start is called before the first frame update
    void Start()
    {
        tl = GameObject.Find("TransformManager").GetComponent<TransformLink>();

        Rotation(); //각도 데이터 
        MakeRate(); //비율 구하는 메서드
        TargetScale(); 
        TargetPosition();
    }

    public void Rotation() //각도 
    {
        for (int i = 0; i < tl.model.Length; i++)
        {
            tl.model[i].transform.rotation = Quaternion.Euler(new Vector3(tl.Rotation[i,0], tl.Rotation[i,1], tl.Rotation[i,2]));
        }

        //초기값 
        tl.model[0].transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
        tl.model[1].transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
    }

    public void TargetPosition()
    {
        for (int i = 0; i < tl.model.Length; i++)
        {
            tl.model[i].transform.position = new Vector3(tl.Position[i, 0] * tScale[i, 0], tl.Position[i, 1] * tScale[i, 1], tl.Position[i, 2] * tScale[i, 2]);
        }
        //obj1.transform.position = new Vector3(Position[0, 0] * tScale[0, 0], Position[0, 1] * tScale[0, 1], Position[0, 2] * tScale[0, 2]);
        //obj2.transform.position = new Vector3(Position[1, 0] * tScale[1, 0], Position[1, 1] * tScale[1, 1], Position[1, 2] * tScale[1, 2]);
    }

    public void TargetScale()
    {
        //scale
        for (int i = 0; i < tl.model.Length; i++)
        {
            tl.model[i].transform.localScale = new Vector3(tScale[i, 0], tScale[i, 2], tScale[i, 1]);
        }
        //obj1.transform.localScale = new Vector3(tScale[0, 0], tScale[0, 2], tScale[0, 1]);
        //obj2.transform.localScale = new Vector3(tScale[1, 0], tScale[1, 2], tScale[1, 1]);
    }

    public void MakeRate() //비율 구하는 메서드
    {      

        int i,k;
        float[,] orgNum = new float[2, 3];
        float[,] mNum = new float[2, 3];

        for (k = 0; k < 2; k++)
        {
            for (i = 0; i < 3; i++)
            {
                //값이 음수인 경우 -> 양수로 변환 
                if (tl.mScale[k,i] < 0)
                    tl.mScale[k,i] = -tl.mScale[k,i];

                if (tl.orgScale[k,i] < 0)
                    tl.orgScale[k,i] = -tl.orgScale[k,i];

                //cnt : 몇번 나누어지는지 구하기 위해 
                int j;
                int cnt = 1;

                if (tl.orgScale[k,i] >= tl.mScale[k,i]) //num1이 num2보다 큰 경우 
                {
                    for (j = 1; j <= tl.orgScale[k,i]; j++)
                    {
                        if (tl.orgScale[k,i] % j == 0 && tl.mScale[k,i] % j == 0)
                            cnt++;

                    }
                }
                else
                {
                    for (j = 1; j <= tl.mScale[k,i]; j++)
                    {
                        if (tl.orgScale[k,i] % j == 0 && tl.mScale[k,i] % j == 0)
                            cnt++;

                    }
                }

                //비례식 구하기 
                if (cnt == 1)
                {
                    orgNum[k,i] = tl.orgScale[k,i];
                    mNum[k,i] = tl.mScale[k,i];
                }
                else
                {
                    for (j = 1; j <= tl.orgScale[k,i]; j++)
                    {
                        if (tl.orgScale[k,i] % j == 0 && tl.mScale[k,i] % j == 0)
                        {
                            orgNum[k,i] = tl.orgScale[k,i] / j;
                            mNum[k,i] = tl.mScale[k,i] / j;
                        }

                    }
                }

                //비율 구하기  
                tScale[k,i] = mNum[k,i] * 1 / orgNum[k,i];

            } //for문 i end
        } // for문 k end
        

    }

}
