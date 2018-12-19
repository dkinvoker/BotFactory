using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurvesController : MonoBehaviour {

    //public LineRenderer lineRenderer;
    private Transform point0, point1;
    private float pointShift;
    private GameObject parentPanel;
    public int numPoints=20;

    private List<Vector3> positions = new List<Vector3>();
    private List<Image> images = new List<Image>();
	// Use this for initialization
	void Start ()
    {
        parentPanel = transform?.parent?.parent?.parent?.parent?.parent?.gameObject;
        point0 = transform;
        point1 = this.GetComponent<JumpCommandInstanceBlock>()?.TargetBlock?.transform;

        pointShift = point0.GetComponent<RectTransform>().sizeDelta.x/2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (point0!=null && point1!=null)
        {
            CreatePoints();
            DrawLinearCurve();
        }
	}

    private void DrawLinearCurve()
    {
        for (int i = 1; i < numPoints+1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position);
        }

        for (int i = 0; i < positions.Count-1; i++)
        {
            images[i].transform.position = positions[i];

        }
        //lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p2)
    {
        Vector3 p1 = new Vector3();
        float dist = Mathf.Abs(p0.y - p2.y);
        p1.x = Mathf.Min(p0.x, p2.x) - (dist / 55) * 20;
        p1.y = (p0.y + p2.y) / 2;
        p1.z = (p0.z + p2.z) / 2;

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 vec = uu * p0;
        vec += 2 * u * t * p1;
        vec += tt * p2;

        vec.x -= pointShift;
        vec.z = -2;
        return vec;
    }

    private void CreatePoints()
    {
        if (positions.Count!=numPoints)
        {
            positions.Clear();
            for (int i = 0; i < numPoints; i++)
            {
                positions.Add(new Vector3());
            }
        }

        if (images.Count!=numPoints-1)
        {
            foreach (Image image in images)
            {
                Destroy(image.gameObject);
            }
            images.Clear();
            for (int i = 0; i < numPoints-1; i++)
            {
                GameObject NewObj = new GameObject(); //Create the GameObject
                Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
                NewObj.GetComponent<RectTransform>().SetParent(parentPanel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
                NewObj.SetActive(true); //Activate the GameObject

                NewObj.transform.position = new Vector3(0,0,0);
                int width = 10;
                NewImage.rectTransform.sizeDelta = new Vector2(width, width);
                NewImage.color = point0.GetComponent<Image>().color;

                images.Add(NewImage);
            }
        }
    }

}
