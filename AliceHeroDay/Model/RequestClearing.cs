using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AliceHeroDay.Model.AliceModel;

namespace AliceHeroDay.Model
{
    public class RequestClearing
    {
        public AliceRequest Сlean(AliceRequest req) {
            var words = new string[] { "на", "или", "впереди","в","с","из","за","как","когда","какой","кто","каком","покажи","расскажи","и","под","о","а","у" };
            req.Request.Command = Regex.Replace(req.Request.Command.ToLower(), "\\b" + string.Join("\\b|\\b", words) + "\\b", "");
            char[] chars = { '!', ' ', '?', '.', ',' };
            req.Request.Command = req.Request.Command.TrimEnd(chars);
            return req;
        }
    }
}
