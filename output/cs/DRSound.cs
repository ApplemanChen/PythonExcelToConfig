using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 音效
/// </summary>
[Serializable]
public class DRSound : IDataRow {
	
	/// <summary>
	/// 唯一标识（音效id）
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { set; get; }
	
	/// <summary>
	/// 资源名
	/// </summary>
	public string Asset { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRSound model = GameUtility.DeserializeObject<DRSound>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		Asset = model.Asset;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRSound>();
	}
}