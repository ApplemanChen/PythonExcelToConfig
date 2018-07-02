using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 物品类
/// </summary>
[Serializable]
public class DRItemBag : IDataRow {
	
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
	/// 是否顶级
	/// </summary>
	public bool IsBest { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRItemBag model = GameUtility.DeserializeObject<DRItemBag>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		Des = model.Des;
		Quality = model.Quality;
		EquipType = model.EquipType;
		IsBest = model.IsBest;
		
	}
}