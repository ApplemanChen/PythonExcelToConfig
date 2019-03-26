using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程年级
/// </summary>
[Serializable]
public class DRLessonGrade : IDataRow {
	
	/// <summary>
	/// 唯一标识(课程年级id)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string GradeName { set; get; }
	
	/// <summary>
	/// 封面图标
	/// </summary>
	public string MainIcon { set; get; }
	
	/// <summary>
	/// 名称注释（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string NameNote { set; get; }
	
	/// <summary>
	/// 简介信息
	/// </summary>
	public string GradeDesc { set; get; }
	
	/// <summary>
	/// 年龄段
	/// </summary>
	public string Age { set; get; }
	
	/// <summary>
	/// 类型描述
	/// </summary>
	public string TypeDec { set; get; }
	
	/// <summary>
	/// 关联的月份id集合
	/// </summary>
	public int[] MonthPlanIds { set; get; }
	
	/// <summary>
	/// 音效id
	/// </summary>
	public int SoundId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonGrade model = GameUtility.DeserializeObject<DRLessonGrade>(dataRowText);
		Id = model.Id;
		GradeName = model.GradeName;
		MainIcon = model.MainIcon;
		NameNote = model.NameNote;
		GradeDesc = model.GradeDesc;
		Age = model.Age;
		TypeDec = model.TypeDec;
		MonthPlanIds = model.MonthPlanIds;
		SoundId = model.SoundId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonGrade>();
	}
}