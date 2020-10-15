using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoaderCodeSelectorModels;
using LoaderCodeSelectorDAL;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.Runtime.CompilerServices;

namespace LoaderCodeSelectorBLL
{
    public class SelectorManager
    {
        private int loaderCodeIdRecord = 0;
        private string[] paraLCStr = { "wholeCode", "wholeConfigration" };
        private string[] paraTable2Str = { "OrdinaryBucket", "RockBucket", "CoalScuttle", "WoodGrapple", "SnowShovel", "Snowboard", "Fork", "QuickChangeDevice" };
        enum JudgePara
        {
            useWholeCode = 0,
            usewholeConfigration = 1
        };      
        /// <summary>
        /// 判断车型配置是否和数据库中的LoaderCode表中配置重复
        /// 重复弹出重复的配置表对应条目
        /// 不重复弹出null值，注意：还有一种读不到数据的情况，事后要考虑！
        /// </summary>
        private LoaderCode JudgeLoaderCodeRepeat(LoaderCode newLoaderCode, JudgePara judgePara)
        {
            LoaderCode tempLoaderCode;
            object tempObject = null;
            string tempString = null, tempLCstr = null;
            if (judgePara == JudgePara.useWholeCode) tempLCstr = newLoaderCode.wholeCode;
            if (judgePara == JudgePara.usewholeConfigration) tempLCstr = newLoaderCode.wholeConfigration;
            SelectorService selectorService = new SelectorService();
            loaderCodeIdRecord = (int)selectorService.GetLoaderCodeCount();
            loaderCodeIdRecord += 100;
            for (int id = 100; id < loaderCodeIdRecord; id++)
            {
                if (null == (tempObject = selectorService.GetLoaderCodeDataById(id, (string)paraLCStr[(int)judgePara])))
                { break; }
                tempString = tempObject.ToString();
                if (String.Compare(tempString, tempLCstr) == 0)
                {
                    tempLoaderCode = selectorService.ReaderLoaderCodeById(id);
                    return tempLoaderCode;
                }
            }
            return null;
        }
        private bool JudgeOptionRepeatChar(string newStr,string oldStr)
        {
            string[] newStrArray = newStr.Split('/');
            string[] oldStrArray = oldStr.Split('/');
            int newOptionNum = newStrArray.Length - 15 - 1;
            int oldOptionNum=0,judgeCount = 0;                
            int oldCompStartIndex = 0,newCompStartIndex=15;
            int tempOldIndex = 0;

            if (oldStrArray[7].Contains("手柄")) //是老的config
            {
                oldOptionNum = oldStrArray.Length - 8 - 1;
                oldCompStartIndex = 8;
            }
            else //是新式config
            {
                oldOptionNum = oldStrArray.Length - 15 - 1;
                oldCompStartIndex = 15;
            }
            tempOldIndex = oldCompStartIndex;

            if (newOptionNum != oldOptionNum)
                return false;
            judgeCount = newOptionNum;

            while (newStrArray[newCompStartIndex] != String.Empty)
            {
                while(oldStrArray[tempOldIndex] != String.Empty)
                {
                    if(oldStrArray[tempOldIndex] == newStrArray[newCompStartIndex])
                    {
                        judgeCount--;
                    }
                    tempOldIndex++;
                }
                tempOldIndex = oldCompStartIndex;
                newCompStartIndex++;
            }
            if (judgeCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询当前库中LoaderCode表中，WholeCode前十六位相同的个数并返回
        /// </summary>
        /// <returns></returns>
        private int JudgeLoaderCodeRepeat(string code, string wholeConfigration,out LoaderCode reLoaderCode)
        {
            object tempObject = null;
            string tempString;
            int countNum = 0;
            reLoaderCode = null;
            if ((code.Length != 16) || (Regex.Matches(wholeConfigration, "/").Count==15))
                return 0;
            SelectorService selectorService = new SelectorService();
            loaderCodeIdRecord = (int)selectorService.GetLoaderCodeCount();
            loaderCodeIdRecord += 100;
            for (int id = 100; id < loaderCodeIdRecord; id++)
            { 
                if (null == (tempObject = selectorService.GetLoaderCodeDataById(id, (string)paraLCStr[(int)JudgePara.useWholeCode])))
                { break; }
                tempString = tempObject.ToString();
                if (tempString.Length < 16) continue;
                tempString = tempString.Substring(0, 16);
                if (String.Compare(tempString, code) == 0)
                {
                    tempObject = selectorService.GetLoaderCodeDataById(id, (string)paraLCStr[(int)JudgePara.usewholeConfigration]);
                    tempString = tempObject.ToString();
                    if (JudgeOptionRepeatChar(wholeConfigration, tempString) == false)
                    {
                        countNum++;
                    }
                    else
                    {
                        reLoaderCode = selectorService.ReaderLoaderCodeById(id);
                        return 0;
                    }
                }
            }
            return countNum;
        }      
        /// <summary>
        /// 根据前端输入的配置生成最终编码，保存到LoaderCode类
        /// </summary>
        /// <returns></returns>
        private LoaderCode CreateCode(List<string> strUIIn, out LoaderCode reLoaderCode)
        {
            string code = null,config=null;
            reLoaderCode = null;
            LoaderCode loaderCode = new LoaderCode();
            foreach(string item in strUIIn)
            {
                if(item.Contains("："))
                {
                    string[] tempArray = item.Split('：');
                    code = String.Concat(code,tempArray[0]);
                    config = String.Concat(config, tempArray[1], '/');
                }
                else
                {
                    config = String.Concat(config, item, '/');
                }
            }
            //loaderCode.wholeConfigration = config;
            //if ((reLoaderCode = JudgeLoaderCodeRepeat(loaderCode, JudgePara.usewholeConfigration)) != null)
            //{
            //    return null;                          
            //}
            int tmpNum = JudgeLoaderCodeRepeat(code, config,out reLoaderCode);
            if (reLoaderCode != null)
                return null;
            if (tmpNum < 10) code += 0;
            code += tmpNum;
            loaderCode.wholeConfigration = config;
            loaderCode.wholeCode = code;            
            return loaderCode;
        }
        /// <summary>
        /// 生成编码，有重复保存到reLoaderCode
        /// </summary>
        /// <param name="enterLoaderConfig"></param>
        /// <param name="reLoaderCode"></param>
        /// <returns></returns>
        public LoaderCode CreateLoaderCode(List<string> strUIIn, out LoaderCode reCodeLoaderCode, out LoaderCode reConfigLoaderCode)
        {
            LoaderCode loaderCode = null;
            reCodeLoaderCode = null;
            reConfigLoaderCode = null;
           
            if ((loaderCode = CreateCode(strUIIn, out reConfigLoaderCode)) != null)
            {
                //if ((reCodeLoaderCode = JudgeLoaderCodeRepeat(loaderCode, JudgePara.useWholeCode)) == null)
                //{
                    int temp = InsertLoaderCode(loaderCode);
                //}
            }
            return loaderCode;
        }
        /// <summary>
        /// 插入数据到数据表LoaderCode中,返回受影响的行数
        /// </summary>
        /// <param name="loaderConfigBase"></param>
        /// <returns></returns>
        private int InsertLoaderCode(LoaderCode loaderCode)
        {
            SelectorService selectorService = new SelectorService();
            if ((loaderCode == null) || (loaderCode.wholeCode.Contains("*"))) return 0;
            return selectorService.AddLoaderCode(loaderCode);
        }
        
        #region

        /// <summary>
        /// 表2数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Table2Data LoadeTable2Data(string model)
        {
            Table2Data table2Data = new Table2Data();
            SelectorService selectorService = new SelectorService();

            List<List<string>> listStr = new List<List<string>>(){
                table2Data.strOneCol,  table2Data.strTwoCol, table2Data.strThreeCol, table2Data.strFourCol,
                table2Data.strFiveCol, table2Data.strSixCol, table2Data.strSevenCol, table2Data.strEightCol,
            };

            int table2Id = (int)selectorService.ReadTable2IdByModel((string)model);
            int maxlen = (int)selectorService.ReadTable2SingleDataById(table2Id, "MaxLen");

            for (int j = 0; j < 8; j++)
            {
                for (int i = table2Id; i < maxlen + table2Id; i++)
                {
                    object tempObject = selectorService.ReadTable2SingleDataById(i, paraTable2Str[j]);
                    if (tempObject == null)
                        break;
                    string type = tempObject.ToString();
                    listStr[j].Add(type);
                }
            }
            return table2Data;
        }
        #endregion
    }
}