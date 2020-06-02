using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
        public ParticleSystem particle;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("PARTICLE");
                if(particle.isPlaying){
                    particle.Stop(true, ParticleSystemStopBehavior.StopEmitting); 
                }
                particle.Play(true);
            }
        }
}
