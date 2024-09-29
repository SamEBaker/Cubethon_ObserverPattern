using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Rigidbody rb;
    public float timeStamp;
    public abstract void Execute();
}
class MoveLeft : Command
{
    private float force;

    public MoveLeft(Rigidbody rb, float force)
    {
        this.rb = rb;
        this.force = force;
    }

    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        rb.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

}

class MoveRight : Command
{
    private float force;

    public MoveRight(Rigidbody rb, float force)
    {
        this.rb = rb;
        this.force = force;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        rb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}



