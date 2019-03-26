using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 钢琴节奏谱
/// </summary>
[Serializable]
public class DRPianoBeat : IDataRow {
	
	/// <summary>
	/// 唯一标识
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { set; get; }
	
	/// <summary>
	/// 歌曲图标
	/// </summary>
	public string Icon { set; get; }
	
	/// <summary>
	/// 时间倍速（歌曲节奏难度）
	/// </summary>
	public float TimeSpeed { set; get; }
	
	/// <summary>
	/// 音符运动速度（控制音符间隔）
	/// </summary>
	public float BeatMoveSpeed { set; get; }
	
	/// <summary>
	/// 节奏音符数组
	/// </summary>
	public int[] Beats { set; get; }
	
	/// <summary>
	/// 对应的时间点
	/// </summary>
	public float[] TimePoints { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRPianoBeat model = GameUtility.DeserializeObject<DRPianoBeat>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		Icon = model.Icon;
		TimeSpeed = model.TimeSpeed;
		BeatMoveSpeed = model.BeatMoveSpeed;
		Beats = model.Beats;
		TimePoints = model.TimePoints;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRPianoBeat>();
	}
}