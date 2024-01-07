using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UnderstandOverloads : MonoBehaviour
{
    //รูปแบบยังไม่overloads แต่สามารถใช้งานได้ปกติเเต่
    //ต้องจำชื่อfuncทั้งสองตัว ทั้งที่มันทำงานเหมือนกันคือการบวก
    public int AddNumber(int num1, int num2)
    {
        return num1 + num2;
    }

    public string AddString(string st1, string st2)
    {
        return st1 + st2;
    }

    //Overloads ชื่อfuncเหมือนกันเเต่ค่าที่ใช้ไม่เหมือนกัน
    //เพื่อไม่ต้องจำชื่อfuncหลายอย่าง
    //หรือเราใช้กันบ่อยๆเเต่ำม่สังเก็ดคือ translate
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    public string Add(string str1, string str2)
    {
        return str1 + str2;
    }

    private void Start()
    {
        transform.Translate(new Vector3(3, 3, 4));
    }
}
