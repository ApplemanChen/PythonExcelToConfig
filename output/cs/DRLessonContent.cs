using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程内容
/// </summary>
[Serializable]
public class DRLessonContent : IDataRow {
	
	/// <summary>
	/// 唯一标识(内容id)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 内容类型(模块id)
	/// </summary>
	public int ModuleId { set; get; }
	
	/// <summary>
	/// 名称注释（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string NameNote { set; get; }
	
	/// <summary>
	/// 模块资源配置id（对应自己模块中的资源配置表中的id）
	/// </summary>
	public int ModuleConfigId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonContent model = GameUtility.DeserializeObject<DRLessonContent>(dataRowText);
		Id = model.Id;
		ModuleId = model.ModuleId;
		NameNote = model.NameNote;
		ModuleConfigId = model.ModuleConfigId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonContent>();
	}
}