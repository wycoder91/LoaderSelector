using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderCodeSelectorModels
{
    //实体类，主要封装生成编码数据
    public class LoaderCode
    {
        public int LoaderCodeId { set; get; }
        public string wholeCode { set; get; } //整机编码
        public string wholeConfigration { set; get; } //整机车型配置
    }
}
