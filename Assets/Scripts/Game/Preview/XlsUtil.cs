#if UNITY_EDITOR

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using NPOI.HSSF;
using System.ComponentModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;



public class XlsUtil {

	public static IRow findRow(ISheet sheet, string tid)
	{
		IRow res = null;	
		for (int i = 0; i < sheet.LastRowNum; ++i) 
		{
			IRow row = sheet.GetRow(i);
			if (row == null)
				continue;
			ICell cell = row.GetCell(0, MissingCellPolicy.RETURN_BLANK_AS_NULL);
			if (cell != null && getCellStringValue(cell) == tid) {
				res = row;
				break;
			}
		}
		return res;
	}

	public static ICell findIndexedCell(IRow row, IRow indexRow, int indirectIndex)
	{
		// find index
		ICell res = null;
		int realIndex = -1;
		for (int i = 0; i < indexRow.LastCellNum; ++i) {
			string strVal = getCellStringValue(indexRow.GetCell(i));
			if (strVal != "") {
				int n = Int32.Parse(strVal);
				if (n == indirectIndex) {
					realIndex = i;
					break;
				}
			}
		}

		// find cell
		if (realIndex >= 0) {
			res = row.GetCell(realIndex);
		}

		return res;
	}

	public static string getValue(IRow row, IRow indexRow, string key)
	{
		string res = "";
		for (int i = 0; i < indexRow.LastCellNum; ++i) {
			string keyStr = getCellStringValue(indexRow.GetCell(i));
			if (keyStr == key)
			{
				Debug.Log ("getValue found key: " + key);
				res = getCellStringValue(row.GetCell(i));
				break;
			}
		}
		return res;
	}

	public static Dictionary<string, string> getValueDict(IRow row, IRow indexRow)
	{
		Dictionary<string, string> res = new Dictionary<string, string>();
		for (int i = 0; i < indexRow.LastCellNum; ++i) {
			string keyStr = getCellStringValue(indexRow.GetCell(i));
			string valStr = getCellStringValue(row.GetCell(i));
			if (keyStr != "" && valStr != "") {
				res [keyStr] = valStr;
			}
		}
		return res;
	}

	public static Dictionary<string, string> getIndexedValueDict(IRow row, IRow indexRow, Dictionary<string, int> query)
	{
		Dictionary<string, string> res = new Dictionary<string, string>();
		foreach (KeyValuePair<string, int> entry in query) {
			ICell cell = findIndexedCell(row, indexRow, entry.Value);
			if (cell != null)
			{
				res[entry.Key] = getCellStringValue(cell);
			}
		}
		return res;
	}

	public static List<string> getIndexedValueList(IRow row, IRow indexRow, List<int> query)
	{
		List<string> res = new List<string>();
		foreach (int entry in query) {
			ICell cell = findIndexedCell(row, indexRow, entry);
			if (cell != null)
			{
				res.Add(getCellStringValue(cell));
			}
		}
		return res;
	}

	public static string getCellStringValue(ICell cell)
	{
		string res = "";
		if (cell != null) {
			if (cell.CellType == CellType.Numeric) {
				res = cell.NumericCellValue.ToString ();
			} else if (cell.CellType == CellType.String) {
				res = cell.StringCellValue;
			}
		}
		return res;
	}
}
#endif
