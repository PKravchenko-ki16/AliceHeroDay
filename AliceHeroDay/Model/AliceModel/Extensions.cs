namespace AliceHeroDay.Model.AliceModel
{
    public static class Extensions
    {
        public static AliceResponse Reply(this AliceRequest req, string text, bool endSession = false, ButtonModel[] buttons = null)
        {
            return new AliceResponse
            {
                Response = new ResponseModel
                {
                    Text = text.Replace("+", "").Replace("- ", ""),
                    Tts = text,
                    EndSession = endSession
                },
                Session = req?.Session
            };
        }

        public static AliceResponse Reply(this AliceRequest req, ResponseCard card, string text = "")
        {
            var response = req.Reply(text);
            response.Response.Card = card;
            return response;
        }
    }
}