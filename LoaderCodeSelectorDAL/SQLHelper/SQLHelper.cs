using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace LoaderCodeSelectorDAL
{
    class SQLHelper
    {
        //private static string connString = "Server=10.41.10.12;DataBase=CourseManageDB;Uid=sa;Pwd=123456";
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        /// <summary>
        /// 实现增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //这是一个异常处理的程序框架，当有框架约束时，程序按框架执行，不会因为return而不执行return后的语句。
            try//将可能会发生异常的代码放在try中
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)//当发生异常时，由catch捕获并显示
            {
                //本来此处是向上层try...catch...抛出，最内层一般用于日志记录，本函数只用一层，直接向用户抛出。
                throw new Exception("执行方法public static int Update(string sql)发生异常" + ex.Message);
            }
            finally//不管前边的程序执行结果如何，此步必须执行
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 实现单行单列数据的查询获取
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //这是一个异常处理的程序框架，当有框架约束时，程序按框架执行，不会因为return而不执行return后的语句。
            try//将可能会发生异常的代码放在try中
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)//当发生异常时，由catch捕获并显示
            {
                //本来此处是向上层try...catch...抛出，最内层一般用于日志记录，本函数只用一层，直接向用户抛出。
                throw new Exception("执行方法public static object GetSingleResult(string sql)发生异常" + ex.Message);
            }
            finally//不管前边的程序执行结果如何，此步必须执行
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 数据结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //这是一个异常处理的程序框架，当有框架约束时，程序按框架执行，不会因为return而不执行return后的语句。
            try//将可能会发生异常的代码放在try中
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);//随着reader对象的关闭而关闭
            }
            catch (Exception ex)//当发生异常时，由catch捕获并显示
            {
                //本来此处是向上层try...catch...抛出，最内层一般用于日志记录，本函数只用一层，直接向用户抛出。
                throw new Exception("执行方法public static SqlDataReader GetReader(string sql)发生异常" + ex.Message);
            }
            //在reader之前，不能提前关闭连接
            //finally//不管前边的程序执行结果如何，此步必须执行
            //{
            //    conn.Close();
            //}
        }
    }
}
