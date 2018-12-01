using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class CameraController : MonoBehaviour
    {
        public float CameraSpeed = 20f;
        public float MousePixelBorder = 10f;
        public float ScrollSpeed = 10f;

        public float MapSize = 10f;
        public float MinY = 3f;
        public float MaxY = 20f;

        private void Update()
        {
            var cameraPosition = this.transform.position;
            var mouse = Input.mousePosition;

            if (Input.GetKey("w") || mouse.y >= Screen.height - MousePixelBorder)
            {
                cameraPosition.z += CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s") || mouse.y <= MousePixelBorder)
            {
                cameraPosition.z -= CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a") || mouse.x <= MousePixelBorder)
            {
                cameraPosition.x -= CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d") || mouse.x >= Screen.width - MousePixelBorder)
            {
                cameraPosition.x += CameraSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            cameraPosition.y -= scroll * 1000 * Time.deltaTime;

            cameraPosition.x = Mathf.Clamp(cameraPosition.x, -MapSize, MapSize);
            cameraPosition.z = Mathf.Clamp(cameraPosition.z, -MapSize, MapSize);

            cameraPosition.y = Mathf.Clamp(cameraPosition.y, MinY, MaxY);

            //Vector 3 is an value type, not reference type, so it have to be set back to transform
            this.transform.position = cameraPosition;

        }

    }
}
