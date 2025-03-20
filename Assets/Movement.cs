using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class Movement : MonoBehaviour
{

    public Transform Cube1, Cube2, Cube3, Cube4, Cube5;
    public float MS = 2.5f;

    void Start()
    {

        SetColor();

        StartCoroutine(MoveSequence1(Cube1, 2f));
        StartCoroutine(MoveSequence1(Cube2, 3f));
        StartCoroutine(MoveSequence1(Cube3, 4f));
        StartCoroutine(MoveSequence1(Cube4, 5f));
        StartCoroutine(MoveSequence1(Cube5, 6f));

        StartCoroutine(MoveSequence2());

    }

    private void SetColor()
    {

        Cube1.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color")) { color = Color.green };
        Cube2.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color")) { color = Color.blue };
        Cube3.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color")) { color = Color.yellow };
        Cube4.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color")) { color = Color.cyan };
        Cube5.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Color")) { color = Color.black };

    }

    private IEnumerator MoveSequence1(Transform Cube, float duration)
    {

        float aTime = 0f;

        while (aTime < duration)
        {

            Cube.Translate(Vector3.forward * MS * Time.deltaTime);
            aTime += Time.deltaTime;
            yield return null;

        }


    }

    private IEnumerator MoveSequence2()
    {

        yield return MoveTask(Cube1, 2f);
        yield return MoveTask(Cube2, 2f);
        yield return MoveTask(Cube3, 2f);
        yield return MoveTask(Cube4, 2f);
        yield return MoveTask(Cube5, 2f);

    }

    private async Task MoveTask(Transform Cube, float duration)
    {

        float aTime = 0f;

        while (aTime < duration)
        {

            Cube.Translate(Vector3.forward * MS *Time.deltaTime);
            aTime += Time.deltaTime;
            await Task.Yield();

        }

    }

}
