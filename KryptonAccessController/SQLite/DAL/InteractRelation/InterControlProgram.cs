﻿/**  版本信息模板在安装目录下，可自行修改。
* InterControlProgram.cs
*
* 功 能： N/A
* 类 名： InterControlProgram
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 17:10:13   N/A    初版
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
	/// 数据访问类:InterControlProgram
	/// </summary>
	public partial class InterControlProgram
	{
		public InterControlProgram()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ICPID", "InterControlProgram"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ICPID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InterControlProgram");
			strSql.Append(" where ICPID=@ICPID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ICPID", DbType.Int32,4)			};
			parameters[0].Value = ICPID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InterControlProgram(");
			strSql.Append("ICPID,ICPName,ICPWaitTimeLength,DesControllerInfoInLANID,PointType,PointID,PointState,OutPutLength)");
			strSql.Append(" values (");
			strSql.Append("@ICPID,@ICPName,@ICPWaitTimeLength,@DesControllerInfoInLANID,@PointType,@PointID,@PointState,@OutPutLength)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ICPID", DbType.Int32,4),
					new SQLiteParameter("@ICPName", DbType.String),
					new SQLiteParameter("@ICPWaitTimeLength", DbType.Int32,4),
					new SQLiteParameter("@DesControllerInfoInLANID", DbType.Int32,4),
					new SQLiteParameter("@PointType", DbType.Int32,4),
					new SQLiteParameter("@PointID", DbType.Int32,4),
					new SQLiteParameter("@PointState", DbType.Int32,4),
					new SQLiteParameter("@OutPutLength", DbType.Int32,4)};
			parameters[0].Value = model.ICPID;
			parameters[1].Value = model.ICPName;
			parameters[2].Value = model.ICPWaitTimeLength;
			parameters[3].Value = model.DesControllerInfoInLANID;
			parameters[4].Value = model.PointType;
			parameters[5].Value = model.PointID;
			parameters[6].Value = model.PointState;
			parameters[7].Value = model.OutPutLength;

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
		public bool Update(KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InterControlProgram set ");
			strSql.Append("ICPName=@ICPName,");
			strSql.Append("ICPWaitTimeLength=@ICPWaitTimeLength,");
			strSql.Append("DesControllerInfoInLANID=@DesControllerInfoInLANID,");
			strSql.Append("PointType=@PointType,");
			strSql.Append("PointID=@PointID,");
			strSql.Append("PointState=@PointState,");
			strSql.Append("OutPutLength=@OutPutLength");
			strSql.Append(" where ICPID=@ICPID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ICPName", DbType.String),
					new SQLiteParameter("@ICPWaitTimeLength", DbType.Int32,4),
					new SQLiteParameter("@DesControllerInfoInLANID", DbType.Int32,4),
					new SQLiteParameter("@PointType", DbType.Int32,4),
					new SQLiteParameter("@PointID", DbType.Int32,4),
					new SQLiteParameter("@PointState", DbType.Int32,4),
					new SQLiteParameter("@OutPutLength", DbType.Int32,4),
					new SQLiteParameter("@ICPID", DbType.Int32,4)};
			parameters[0].Value = model.ICPName;
			parameters[1].Value = model.ICPWaitTimeLength;
			parameters[2].Value = model.DesControllerInfoInLANID;
			parameters[3].Value = model.PointType;
			parameters[4].Value = model.PointID;
			parameters[5].Value = model.PointState;
			parameters[6].Value = model.OutPutLength;
			parameters[7].Value = model.ICPID;

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
		public bool Delete(int ICPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InterControlProgram ");
			strSql.Append(" where ICPID=@ICPID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ICPID", DbType.Int32,4)			};
			parameters[0].Value = ICPID;

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
		public bool DeleteList(string ICPIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InterControlProgram ");
			strSql.Append(" where ICPID in ("+ICPIDlist + ")  ");
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
		public KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram GetModel(int ICPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ICPID,ICPName,ICPWaitTimeLength,DesControllerInfoInLANID,PointType,PointID,PointState,OutPutLength from InterControlProgram ");
			strSql.Append(" where ICPID=@ICPID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ICPID", DbType.Int32,4)			};
			parameters[0].Value = ICPID;

			KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram model=new KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram();
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
		public KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram DataRowToModel(DataRow row)
		{
			KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram model=new KryptonAccessController.SQLite.Model.InteractRelation.InterControlProgram();
			if (row != null)
			{
				if(row["ICPID"]!=null && row["ICPID"].ToString()!="")
				{
					model.ICPID=int.Parse(row["ICPID"].ToString());
				}
				if(row["ICPName"]!=null)
				{
					model.ICPName=row["ICPName"].ToString();
				}
				if(row["ICPWaitTimeLength"]!=null && row["ICPWaitTimeLength"].ToString()!="")
				{
					model.ICPWaitTimeLength=int.Parse(row["ICPWaitTimeLength"].ToString());
				}
				if(row["DesControllerInfoInLANID"]!=null && row["DesControllerInfoInLANID"].ToString()!="")
				{
					model.DesControllerInfoInLANID=int.Parse(row["DesControllerInfoInLANID"].ToString());
				}
				if(row["PointType"]!=null && row["PointType"].ToString()!="")
				{
					model.PointType=int.Parse(row["PointType"].ToString());
				}
				if(row["PointID"]!=null && row["PointID"].ToString()!="")
				{
					model.PointID=int.Parse(row["PointID"].ToString());
				}
				if(row["PointState"]!=null && row["PointState"].ToString()!="")
				{
					model.PointState=int.Parse(row["PointState"].ToString());
				}
				if(row["OutPutLength"]!=null && row["OutPutLength"].ToString()!="")
				{
					model.OutPutLength=int.Parse(row["OutPutLength"].ToString());
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
			strSql.Append("select ICPID,ICPName,ICPWaitTimeLength,DesControllerInfoInLANID,PointType,PointID,PointState,OutPutLength ");
			strSql.Append(" FROM InterControlProgram ");
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
			strSql.Append("select count(1) FROM InterControlProgram ");
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
				strSql.Append("order by T.ICPID desc");
			}
			strSql.Append(")AS Row, T.*  from InterControlProgram T ");
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
			parameters[0].Value = "InterControlProgram";
			parameters[1].Value = "ICPID";
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

