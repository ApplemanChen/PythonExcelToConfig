using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 弹钢琴资源配置
/// </summary>
[Serializable]
public class DRPianoResConfig : IDataRow {
	
	/// <summary>
	/// 唯一标识(资源配置id)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 可用钢琴节奏谱集合
	/// </summary>
	public int[] PianoBeatIds { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRPianoResConfig model = GameUtility.DeserializeObject<DRPianoResConfig>(dataRowText);
		Id = model.Id;
		PianoBeatIds = model.PianoBeatIds;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRPianoResConfig>();
	}
}