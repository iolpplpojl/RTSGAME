using UnityEngine;

public interface IMagic
{
    public void execute();
}


public interface MagicParameter { }

public class MagicParameterPos : MagicParameter
{
    public Vector3 value;
}

public class MagicParameterTar : MagicParameter
{
    public GameObject value;
}

