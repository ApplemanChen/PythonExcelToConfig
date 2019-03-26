using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程分类
/// </summary>
[Serializable]
public class DRLessonCategory : IDataRow {
	
	/// <summary>
	/// 唯一标示(课程类型)
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
	/// 音效id
	/// </summary>
	public int SoundId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonCategory model = GameUtility.DeserializeObject<DRLessonCategory>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		NameNote = model.NameNote;
		SoundId = model.SoundId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonCategory>();
	}
}