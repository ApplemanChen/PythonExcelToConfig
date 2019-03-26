using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程课时
/// </summary>
[Serializable]
public class DRLessonInfo : IDataRow {
	
	/// <summary>
	/// 唯一标识（课时id）
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 课程年级id
	/// </summary>
	public int GradeId { set; get; }
	
	/// <summary>
	/// 课程类型
	/// </summary>
	public int CategoryType { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string LessonName { set; get; }
	
	/// <summary>
	/// 名称注释（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string NameNote { set; get; }
	
	/// <summary>
	/// 关联的内容id集合
	/// </summary>
	public int[] ContentIds { set; get; }
	
	/// <summary>
	/// 关联的内容说明集合（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string[] ContentNotes { set; get; }
	
	/// <summary>
	/// 音效id
	/// </summary>
	public int SoundId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonInfo model = GameUtility.DeserializeObject<DRLessonInfo>(dataRowText);
		Id = model.Id;
		GradeId = model.GradeId;
		CategoryType = model.CategoryType;
		LessonName = model.LessonName;
		NameNote = model.NameNote;
		ContentIds = model.ContentIds;
		ContentNotes = model.ContentNotes;
		SoundId = model.SoundId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonInfo>();
	}
}