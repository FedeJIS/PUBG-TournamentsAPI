using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tournament 
{
    [Serializable]
	public struct Attributes 
    {
		public string createdAt;
    }
    [Serializable]
    public struct Data
    {
			public string type;
			public string id;
            public Attributes attributes;
							
    }
    [Serializable]
    public struct Links{
                public string self;
    }

    [Serializable]
    public struct Meta{
                public string description;
    }

    public Data[] data;
    public Links links;
    public Meta meta;
  
}
