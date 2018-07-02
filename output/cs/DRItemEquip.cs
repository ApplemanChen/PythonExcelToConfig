using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 装备类
/// </summary>
[Serializable]
public class DRItemEquip : IDataRow {
	
	/// <summary>
	/// 唯一标识
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { set; get; }
	
	/// <summary>
	/// 描述
	/// </summary>
	public string Des { set; get; }
	
	/// <summary>
	/// 品质
	/// </summary>
	public int Quality { set; get; }
	
	/// <summary>
	/// 装备类型
	/// </summary>
	public int EquipType { set; get; }
	
	/// <summary>
	/// 宝石列表
	/// </summary>
	public int[] GemList { set; get; }
	
	/// <summary>
	/// 宝石描述
	/// </summary>
	public string[] GemListDes { set; get; }
	
	/// <summary>
	/// 比例
	/// </summary>
	public double Percent { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRItemEquip model = GameUtility.DeserializeObject<DRItemEquip>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		Des = model.Des;
		Quality = model.Quality;
		EquipType = model.EquipType;
		GemList = model.GemList;
		GemListDes = model.GemListDes;
		Percent = model.Percent;
		
	}
}