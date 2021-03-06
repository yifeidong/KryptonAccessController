﻿/**  版本信息模板在安装目录下，可自行修改。
* ControllerInfoInLAN.cs
*
* 功 能： N/A
* 类 名： ControllerInfoInLAN
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:10:08   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace KryptonAccessController.SQLite.DAL.InteractRelation
{
	/// <summary>
	/// 数据访问类:ControllerInfoInLAN
	/// </summary>
	public partial class ControllerInfoInLAN
	{
		public ControllerInfoInLAN()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ControllerID", "ControllerInfoInLAN"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ControllerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ControllerInfoInLAN");
			strSql.Append(" where ControllerID=@ControllerID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ControllerID", DbType.Int32,4)			};
			parameters[0].Value = ControllerID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ControllerInfoInLAN(");
			strSql.Append("ControllerID,ControllerName,ControllerType,ComunicateType,ControllerIP,ControllerPort,ControllerAddr485,ControllerBaudrate,ControllerDataBits,ControllerStopBits,ControllerParityCheck,ControllerFlowControl)");
			strSql.Append(" values (");
			strSql.Append("@ControllerID,@ControllerName,@ControllerType,@ComunicateType,@ControllerIP,@ControllerPort,@ControllerAddr485,@ControllerBaudrate,@ControllerDataBits,@ControllerStopBits,@ControllerParityCheck,@ControllerFlowControl)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ControllerID", DbType.Int32,4),
					new SQLiteParameter("@ControllerName", DbType.String),
					new SQLiteParameter("@ControllerType", DbType.Int32,4),
					new SQLiteParameter("@ComunicateType", DbType.Int32,4),
					new SQLiteParameter("@ControllerIP", DbType.String),
					new SQLiteParameter("@ControllerPort", DbType.Int32,4),
					new SQLiteParameter("@ControllerAddr485", DbType.Int32,4),
					new SQLiteParameter("@ControllerBaudrate", DbType.Int32,4),
					new SQLiteParameter("@ControllerDataBits", DbType.Int32,4),
					new SQLiteParameter("@ControllerStopBits", DbType.Int32,4),
					new SQLiteParameter("@ControllerParityCheck", DbType.String),
					new SQLiteParameter("@ControllerFlowControl", DbType.String)};
			parameters[0].Value = model.ControllerID;
			parameters[1].Value = model.ControllerName;
			parameters[2].Value = model.ControllerType;
			parameters[3].Value = model.ComunicateType;
			parameters[4].Value = model.ControllerIP;
			parameters[5].Value = model.ControllerPort;
			parameters[6].Value = model.ControllerAddr485;
			parameters[7].Value = model.ControllerBaudrate;
			parameters[8].Value = model.ControllerDataBits;
			parameters[9].Value = model.ControllerStopBits;
			parameters[10].Value = model.ControllerParityCheck;
			parameters[11].Value = model.ControllerFlowControl;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ControllerInfoInLAN set ");
			strSql.Append("ControllerName=@ControllerName,");
			strSql.Append("ControllerType=@ControllerType,");
			strSql.Append("ComunicateType=@ComunicateType,");
			strSql.Append("ControllerIP=@ControllerIP,");
			strSql.Append("ControllerPort=@ControllerPort,");
			strSql.Append("ControllerAddr485=@ControllerAddr485,");
			strSql.Append("ControllerBaudrate=@ControllerBaudrate,");
			strSql.Append("ControllerDataBits=@ControllerDataBits,");
			strSql.Append("ControllerStopBits=@ControllerStopBits,");
			strSql.Append("ControllerParityCheck=@ControllerParityCheck,");
			strSql.Append("ControllerFlowControl=@ControllerFlowControl");
			strSql.Append(" where ControllerID=@ControllerID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ControllerName", DbType.String),
					new SQLiteParameter("@ControllerType", DbType.Int32,4),
					new SQLiteParameter("@ComunicateType", DbType.Int32,4),
					new SQLiteParameter("@ControllerIP", DbType.String),
					new SQLiteParameter("@ControllerPort", DbType.Int32,4),
					new SQLiteParameter("@ControllerAddr485", DbType.Int32,4),
					new SQLiteParameter("@ControllerBaudrate", DbType.Int32,4),
					new SQLiteParameter("@ControllerDataBits", DbType.Int32,4),
					new SQLiteParameter("@ControllerStopBits", DbType.Int32,4),
					new SQLiteParameter("@ControllerParityCheck", DbType.String),
					new SQLiteParameter("@ControllerFlowControl", DbType.String),
					new SQLiteParameter("@ControllerID", DbType.Int32,4)};
			parameters[0].Value = model.ControllerName;
			parameters[1].Value = model.ControllerType;
			parameters[2].Value = model.ComunicateType;
			parameters[3].Value = model.ControllerIP;
			parameters[4].Value = model.ControllerPort;
			parameters[5].Value = model.ControllerAddr485;
			parameters[6].Value = model.ControllerBaudrate;
			parameters[7].Value = model.ControllerDataBits;
			parameters[8].Value = model.ControllerStopBits;
			parameters[9].Value = model.ControllerParityCheck;
			parameters[10].Value = model.ControllerFlowControl;
			parameters[11].Value = model.ControllerID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ControllerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ControllerInfoInLAN ");
			strSql.Append(" where ControllerID=@ControllerID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ControllerID", DbType.Int32,4)			};
			parameters[0].Value = ControllerID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ControllerIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ControllerInfoInLAN ");
			strSql.Append(" where ControllerID in ("+ControllerIDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN GetModel(int ControllerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ControllerID,ControllerName,ControllerType,ComunicateType,ControllerIP,ControllerPort,ControllerAddr485,ControllerBaudrate,ControllerDataBits,ControllerStopBits,ControllerParityCheck,ControllerFlowControl from ControllerInfoInLAN ");
			strSql.Append(" where ControllerID=@ControllerID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ControllerID", DbType.Int32,4)			};
			parameters[0].Value = ControllerID;

			KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN model=new KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN DataRowToModel(DataRow row)
		{
			KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN model=new KryptonAccessController.SQLite.Model.InteractRelation.ControllerInfoInLAN();
			if (row != null)
			{
				if(row["ControllerID"]!=null && row["ControllerID"].ToString()!="")
				{
					model.ControllerID=int.Parse(row["ControllerID"].ToString());
				}
				if(row["ControllerName"]!=null)
				{
					model.ControllerName=row["ControllerName"].ToString();
				}
				if(row["ControllerType"]!=null && row["ControllerType"].ToString()!="")
				{
					model.ControllerType=int.Parse(row["ControllerType"].ToString());
				}
				if(row["ComunicateType"]!=null && row["ComunicateType"].ToString()!="")
				{
					model.ComunicateType=int.Parse(row["ComunicateType"].ToString());
				}
				if(row["ControllerIP"]!=null)
				{
					model.ControllerIP=row["ControllerIP"].ToString();
				}
				if(row["ControllerPort"]!=null && row["ControllerPort"].ToString()!="")
				{
					model.ControllerPort=int.Parse(row["ControllerPort"].ToString());
				}
				if(row["ControllerAddr485"]!=null && row["ControllerAddr485"].ToString()!="")
				{
					model.ControllerAddr485=int.Parse(row["ControllerAddr485"].ToString());
				}
				if(row["ControllerBaudrate"]!=null && row["ControllerBaudrate"].ToString()!="")
				{
					model.ControllerBaudrate=int.Parse(row["ControllerBaudrate"].ToString());
				}
				if(row["ControllerDataBits"]!=null && row["ControllerDataBits"].ToString()!="")
				{
					model.ControllerDataBits=int.Parse(row["ControllerDataBits"].ToString());
				}
				if(row["ControllerStopBits"]!=null && row["ControllerStopBits"].ToString()!="")
				{
					model.ControllerStopBits=int.Parse(row["ControllerStopBits"].ToString());
				}
				if(row["ControllerParityCheck"]!=null)
				{
					model.ControllerParityCheck=row["ControllerParityCheck"].ToString();
				}
				if(row["ControllerFlowControl"]!=null)
				{
					model.ControllerFlowControl=row["ControllerFlowControl"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ControllerID,ControllerName,ControllerType,ComunicateType,ControllerIP,ControllerPort,ControllerAddr485,ControllerBaudrate,ControllerDataBits,ControllerStopBits,ControllerParityCheck,ControllerFlowControl ");
			strSql.Append(" FROM ControllerInfoInLAN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ControllerInfoInLAN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ControllerID desc");
			}
			strSql.Append(")AS Row, T.*  from ControllerInfoInLAN T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLite.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "ControllerInfoInLAN";
			parameters[1].Value = "ControllerID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

