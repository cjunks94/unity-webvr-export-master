﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotation : MonoBehaviour {

      Quaternion rotation;
      void Awake()
      {
           rotation = transform.rotation;
      }
      void Update()
      {
            transform.rotation = rotation;
      }
}
