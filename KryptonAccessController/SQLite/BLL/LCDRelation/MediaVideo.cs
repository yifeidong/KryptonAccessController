﻿/**  版本信息模板在安装目录下，可自行修改。
* MediaVideo.cs
*
* 功 能： N/A
* 类 名： MediaVideo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:09:02   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using KryptonAccessController.SQLite.Model.LCDRelation;
namespace KryptonAccessController.SQLite.BLL.LCDRelation
{
	/// <summary>
	/// MediaVideo
	/// </summary>
	public partial class MediaVideo
	{
		private readonly KryptonAccessController.SQLite.DAL.LCDRelation.MediaVideo dal=new KryptonAccessController.SQLite.DAL.LCDRelation.MediaVideo();
		public MediaVideo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MediaVideoID)
		{
			return dal.Exists(MediaVideoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MediaVideoID)
		{
			
			return dal.Delete(MediaVideoID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MediaVideoIDlist )
		{
			return dal.DeleteList(MediaVideoIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo GetModel(int MediaVideoID)
		{
			
			return dal.GetModel(MediaVideoID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo GetModelByCache(int MediaVideoID)
		{
			
			string CacheKey = "MediaVideoModel-" + MediaVideoID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MediaVideoID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo> DataTableToList(DataTable dt)
		{
			List<KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo> modelList = new List<KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				KryptonAccessController.SQLite.Model.LCDRelation.MediaVideo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

