﻿using System.Collections.Generic;

namespace XamarinCRUD.APIServices
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public List<string> Messages { get; set; }
        public object Content { get; set; }
    }
}
