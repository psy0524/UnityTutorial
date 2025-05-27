using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;

    public string hexCode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //this.GetComponent<Material>() = mat; // Material을 바꾸는 방식 X

        //this.GetComponent<MeshRenderer>().material = mat; // MeshRenderer에 접근해서 바꾸는 형식

        //this.GetComponent<MeshRenderer>().sharedMaterial = mat; // MeshRenderer에 접근해서 바꾸는 형식

        //this.GetComponent<MeshRenderer>().material.color = Color.green;

        //this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green; // 같은 Material의 색깔을 바꿈(종료해도 되돌아가지 않음)

        //this.GetComponent<MeshRenderer>().material.color = new Color(75f/255f, 65f/255f, 70f/255f, 255f/255f);

        mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if ( ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }
}
