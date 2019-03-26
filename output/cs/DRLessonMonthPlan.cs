using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 课程月份计划
/// </summary>
[Serializable]
public class DRLessonMonthPlan : IDataRow {
	
	/// <summary>
	/// 唯一标识(课程月份id)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 课程年级
	/// </summary>
	public int GradeId { set; get; }
	
	/// <summary>
	/// 月份全拼名
	/// </summary>
	public string MonthPlanName { set; get; }
	
	/// <summary>
	/// 月份缩写名
	/// </summary>
	public string MonthShortName { set; get; }
	
	/// <summary>
	/// 名称注释（为了方便配表使用，实际代码中不用）
	/// </summary>
	public string MonthPlanNameNote { set; get; }
	
	/// <summary>
	/// 描述信息
	/// </summary>
	public string MonthPlanDesc { set; get; }
	
	/// <summary>
	/// 关联的课程分类类型集合
	/// </summary>
	public int[] Categories { set; get; }
	
	/// <summary>
	/// 关联的课时id集合
	/// </summary>
	public int[] Lessons { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRLessonMonthPlan model = GameUtility.DeserializeObject<DRLessonMonthPlan>(dataRowText);
		Id = model.Id;
		GradeId = model.GradeId;
		MonthPlanName = model.MonthPlanName;
		MonthShortName = model.MonthShortName;
		MonthPlanNameNote = model.MonthPlanNameNote;
		MonthPlanDesc = model.MonthPlanDesc;
		Categories = model.Categories;
		Lessons = model.Lessons;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRLessonMonthPlan>();
	}
}