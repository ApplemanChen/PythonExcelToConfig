using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程模块
/// </summary>
[Serializable]
public class DRLessonModule : IDataRow {
	
	/// <summary>
	/// 唯一标识(模块id)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { set; get; }
	
	/// <summary>
	/// 名称注释（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string NameNote { set; get; }
	
	/// <summary>
	/// 模块简介
	/// </summary>
	public string ModuleDesc { set; get; }
	
	/// <summary>
	/// 适用年龄
	/// </summary>
	public int Age { set; get; }
	
	/// <summary>
	/// 图标
	/// </summary>
	public string Icon { set; get; }
	
	/// <summary>
	/// 音效id
	/// </summary>
	public int SoundId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonModule model = GameUtility.DeserializeObject<DRLessonModule>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		NameNote = model.NameNote;
		ModuleDesc = model.ModuleDesc;
		Age = model.Age;
		Icon = model.Icon;
		SoundId = model.SoundId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonModule>();
	}
}