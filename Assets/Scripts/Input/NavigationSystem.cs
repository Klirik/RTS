using UnityEngine;

namespace RTS.Inputs
{
    public class NavigationSystem : ITickable
    {
        public float speed = 3f;
        public void Tick()
        {
            if(Input.GetKey(KeyCode.A))
                Camera.main.transform.position += Vector3.left * speed * Time.deltaTime;
            if(Input.GetKey(KeyCode.D))
                Camera.main.transform.position += Vector3.right * speed * Time.deltaTime;
            if(Input.GetKey(KeyCode.W))
                Camera.main.transform.position += Vector3.up * speed * Time.deltaTime;
            if(Input.GetKey(KeyCode.S))
                Camera.main.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}