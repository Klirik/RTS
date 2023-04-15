using UnityEngine;

namespace RTS.Inputs
{
    public class NavigationSystem : ITickable
    {
        public float Speed = 5f;
        public float BaseAcceleration = 3f;
        public float Acceleration = 10f;
        
        Camera camera = Camera.main;
        public void Tick()
        {
            Acceleration = Input.GetKey(KeyCode.LeftShift) ? BaseAcceleration : 1f;   
                
            if(Input.GetKey(KeyCode.A))
                camera.transform.position += Vector3.left * (Speed * Acceleration * Time.deltaTime);
            if(Input.GetKey(KeyCode.D))
                camera.transform.position += Vector3.right * (Speed * Acceleration * Time.deltaTime);
            if(Input.GetKey(KeyCode.W))
                camera.transform.position += Vector3.up * (Speed * Acceleration * Time.deltaTime);
            if(Input.GetKey(KeyCode.S))
                camera.transform.position += Vector3.down * (Speed * Acceleration * Time.deltaTime);
        }
    }
}