using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using LoaderCodeSelectorModels;

namespace LoaderCodeSelectorDAL
{
    public class SelectorService
    {       
        /// <summary>
        /// 向数据库LoaderCode表插入一条数据条目
        /// </summary>
        /// <param name="loaderCode"></param>
        /// <returns></returns>
        public int AddLoaderCode(LoaderCode loaderCode)
        {
            string sql = "insert into LoaderCode(wholeCode,wholeConfigration)";
            sql += $"values('{loaderCode.wholeCode}','{loaderCode.wholeConfigration}')";

            return SQLHelper.Update(sql);
        }
        /// <summary>
        /// 返回LoaderCode表的条目数
        /// </summary>
        /// <returns></returns>
        public object GetLoaderCodeCount()
        {
            string sql = "select count(*) from LoaderCode";
            return SQLHelper.GetSingleResult(sql);
        }
        /// <summary>
        /// 根据LoaderCodeId获得wholeCode,wholeConfigration
        /// </summary>
        /// <param name="loaderCodeId"></param>
        /// <returns></returns>
        public object GetLoaderCodeDataById(int loaderCodeId, string para)
        {
            string sql = $"select {para} from LoaderCode where LoaderCodeId = {loaderCodeId}";
            return SQLHelper.GetSingleResult(sql);
        }
        /// <summary>
        /// 返回ID对应LoaderCode表中条目
        /// </summary>
        /// <param name="loaderCodeId"></param>
        /// <returns></returns>
        public LoaderCode ReaderLoaderCodeById(int loaderCodeId)
        {
            string sql = $"select LoaderCodeId,wholeCode,wholeConfigration from LoaderCode where LoaderCodeId = {loaderCodeId}";
            LoaderCode loaderCode = new LoaderCode();
            SqlDataReader reader = SQLHelper.GetReader(sql);

            while (reader.Read())
            {
                loaderCode.LoaderCodeId = (int)reader["LoaderCodeId"];
                loaderCode.wholeCode = reader["wholeCode"].ToString();
                loaderCode.wholeConfigration = reader["wholeConfigration"].ToString();
            }
            reader.Close();
            return loaderCode;
        }
        /// <summary>
        /// Table2：根据机型确定ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object ReadTable2IdByModel(string model)
        {
            string sql = $"select Table2Id from Table2 where Model = '{model}'";
            return SQLHelper.GetSingleResult(sql);
        }
        /// <summary>
        /// Table2：根据ID选择参数
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public object ReadTable2SingleDataById(int tableId,string para)
        {
            string sql = $"select {para} from Table2 where Table2Id = {tableId}";
            return SQLHelper.GetSingleResult(sql);
        }
    }
}
