using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Video.Appliacation.Contract.Base
{
    public class VideoInput :PageResquestDto
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string? Keywords { get; set; } 

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
}
