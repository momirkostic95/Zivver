﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posts.App.DTO;

namespace Posts.App.Extension
{
    public static class ObjectArrayExtension
    {
        public static (bool isShowingId, PostDTO postDTO)? ToPostToupleConvertValue(this object[] values) => 
            values.Length == 2 ? ((bool)values[0], (PostDTO)values[1]) : null;
    }
}
