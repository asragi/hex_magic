using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RShake{

	const float DumpedTime = 0.05f; // 振幅減衰速さ係数
	const float AngularVelX = 1f;
	const float AngularVelY = 0.7f;
	const float eps = 0.03f;
	Vector3 delta;
	uint startFrame;
	float power; // 振幅

	uint Frame;
	// Use this for initialization
	public RShake () {
		delta = Vector3.zero;
		startFrame = 0;
		power = 0;
	}

	public void SetShake(float _power){
		delta = Vector3.zero;
		startFrame = Frame;
		power = _power;
	}

	/// <summary>
	/// 毎フレーム呼び出す. シェイクがある場合に偏差を与える.
	/// </summary>
	public Vector3 Delta(){
		Frame++;
		var dtime = Frame - startFrame;
		// 振幅
		var amplitude = power * Mathf.Pow(2.8f, - DumpedTime * dtime);
		if (amplitude < eps){ // 振幅が十分に小さい場合
			return Vector3.zero;
		}
		delta.x = amplitude * Mathf.Sin(dtime * AngularVelX);
		delta.y = amplitude * Mathf.Sin(dtime * AngularVelY + Random.Range(0, Mathf.PI));
		return delta;
	}
}