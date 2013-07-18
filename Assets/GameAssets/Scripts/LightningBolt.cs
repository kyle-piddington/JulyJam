/*
	This script is placed in public domain. The author takes no responsibility for any possible harm.
	Contributed by Jonathan Czeck
*/
using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
    public playerShieldScript shield;
    public Vector3 target;
    private float theta;
    private float phi;
    private float thetaRot;
    private float phiRot;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
    private float totalTime;
	public Light startLight;
	public Light endLight;
 
	Perlin noise;
	float oneOverZigs;
	
	private Particle[] particles;
	
	void Start()
	{
        totalTime = Random.Range(0.25f, 0.90f);
		oneOverZigs = 1f / (float)zigs;
		particleEmitter.emit = false;
        theta = Mathf.PI / 2;
        phi = Random.Range(0, Mathf.PI * 2);
        thetaRot = Random.Range(-0.05f, 0.05f);
        phiRot = Random.Range(-0.005f, 0.005f);
		particleEmitter.Emit(zigs);
		particles = particleEmitter.particles;
	}
	
	void Update ()
	{
		if (noise == null)
			noise = new Perlin();
		
		float timex = Time.time * speed * 1;
		float timey = Time.time * speed * 1;
		float timez = Time.time * speed * 1;

        phi += phiRot; //Rotate around
        theta += thetaRot;
        target = new Vector3(Mathf.Cos(theta) * Mathf.Sin(phi) , Mathf.Sin(theta)* Mathf.Sin(phi) , Mathf.Cos(phi) );
        //Debug.Log(target.magnitude);
        target *= shield.rad / 2;
        
        //Debug.Log(Vector3.Distance(transform.position,target));
        //Debug.Log(shield.rad / 2);
		for (int i=0; i < particles.Length; i++)
		{
			Vector3 position = Vector3.Lerp(Vector3.zero, target, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
										noise.Noise(timey + position.x, timey + position.y, timey + position.z),
										noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			position += (offset * scale * ((float)i * oneOverZigs))+shield.transform.position;
			
			particles[i].position = position;
            particles[i].color = Color.white;
			particles[i].energy = 1f;
            
           
		}
		
		particleEmitter.particles = particles;
		
		if (particleEmitter.particleCount >= 2)
		{
			if (startLight)
				startLight.transform.position = particles[0].position;
			if (endLight)
				endLight.transform.position = particles[particles.Length - 1].position;
		}
	}	
}