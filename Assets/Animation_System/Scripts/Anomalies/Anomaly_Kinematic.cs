using PlayerCharacter;
using Unity.VisualScripting;
using UnityEngine;

public class Anomaly_Kinematic : Anomaly
{
    private Transform _orignalTransform;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _orignalTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();           
    }
    public override void Manifest(Player player)
    {
        AlterObject();
        base.Manifest(player);   
    }

    public override void Fix(Player player)
    {
        base.Fix(player);

        gameObject.transform.position = _orignalTransform.position;
        gameObject.transform.rotation = _orignalTransform.rotation;
    }

    public override void AlterObject()
    {
        float randX = Random.Range(-1, 1) * 200f;
        float randY = Random.Range(0.2f, 1) * 200f;
        float randZ = Random.Range(-1, 1) * 200f;

        if (randX + randZ == 0)
            randX = 200f;

        _rigidbody.AddForce(new Vector3(randX, randY, randZ));
    }
}