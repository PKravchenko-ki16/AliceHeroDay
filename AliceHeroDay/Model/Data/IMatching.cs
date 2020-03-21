using System;
using System.Collections.Generic;
using System.Text;
using AliceHeroDay.Model.ActivationWords;

namespace AliceHeroDay.Model.Data
{
    public interface IMatching
    {
        AnswerManagement Match(string request, Matching matching, FillingData fillingData);
    }
}
