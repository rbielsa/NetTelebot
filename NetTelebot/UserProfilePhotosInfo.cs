﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTelebot
{
    /// <summary>
    /// This object represent a user's profile pictures.
    /// </summary>
    public class UserProfilePhotosInfo
    {
        internal UserProfilePhotosInfo(string jsonText)
        {
            Parse(jsonText);
        }

        internal UserProfilePhotosInfo(JObject jsonObject)
        {
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            TotalCount = jsonObject["total_count"].Value<int>();
            var arrayOfArrays = jsonObject["photos"].Value<JArray>();
            Photos =
                arrayOfArrays.Cast<JArray>().Select(array => PhotoSizeInfo.ParseArray(array)).ToArray();
        }

        private void Parse(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        /// <summary>
        /// Total number of profile pictures the target user has
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Requested profile pictures (in up to 4 sizes each)
        /// </summary>
        public PhotoSizeInfo[][] Photos { get; set; }
    }
}
