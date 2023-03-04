using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Appliacation.Contract.Base
{
    public class PageResultDto<T>
    {
        /// <summary>
        /// 分页数据
        /// </summary>
        public IReadOnlyList<T> Items { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }


        public PageResultDto(int count,IReadOnlyList<T> items)
        {
            Items = items;
            Count = count;
        }



    }
}
