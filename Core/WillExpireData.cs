using System;

namespace Suucha.WeChat.Core
{
        public class WillExpireData
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public string Value { get; set; }
            /// <summary>
            /// Gets or sets the expire time.
            /// </summary>
            /// <value>
            /// The expire time.
            /// </value>
            public DateTime ExpireTime { get; set; }
            /// <summary>
            /// Gets or sets the ahead of time.Unit:ms
            /// </summary>
            /// <value>
            /// The ahead of time.
            /// </value>
            public int AheadOfTime { get; set; }

            /// <summary>
            /// Gets the expire time display.
            /// </summary>
            /// <value>
            /// The expire time display.
            /// </value>
            public string ExpireTimeDisplay
            {
                get
                {
                    return string.Format("yyyy-MM-dd HH:mm:ss", ExpireTime);
                }
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="WillExpireData"/> class.
            /// </summary>
            public WillExpireData() :
                this(null, DateTime.Now.AddMilliseconds(-1000), 0)
            {

            }
            /// <summary>
            /// Initializes a new instance of the <see cref="WillExpireData"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="expiresIn">The expires in. Unit:s</param>
            public WillExpireData(string value, int expiresIn)
            {
                var time = DateTime.Now;
                time.AddSeconds(expiresIn);
                Value = value;
                ExpireTime = time;
                AheadOfTime = expiresIn / 12 * 1000;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="WillExpireData"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="expireTime">The expire time.</param>
            /// <param name="aheadOfTime">The ahead of time.Unit:ms</param>
            public WillExpireData(string value, DateTime expireTime, int aheadOfTime)
            {
                Value = value;
                AheadOfTime = aheadOfTime;
            }
            /// <summary>
            /// Determines whether [is will expire].
            /// </summary>
            /// <returns>
            ///   <c>true</c> if [is will expire]; otherwise, <c>false</c>.
            /// </returns>
            public bool IsWillExpire()
            {
                DateTime now = DateTime.Now.AddMilliseconds(AheadOfTime);
                return now >= ExpireTime;
            }
            /// <summary>
            /// Gets the time to expire.Unit:s
            /// </summary>
            /// <returns></returns>
            public long GetTimeToExpire()
            {
                if (IsWillExpire())
                {
                    return 1000L;
                }
                DateTime now = DateTime.Now.AddMilliseconds(-AheadOfTime);
                return (ExpireTime - now).Milliseconds;
            }
        }
}
