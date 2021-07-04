using RandM_1._0.Mortys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandM_1._0.ProgramUI;

namespace RandM_1._0
{
    public class Event
    {
        public enum EventType { Get, Use }
        public EventType Type;
        public string TriggerPhrase;
        public Result EventResult;

        public Event(string triggerPhrase, EventType type, Result eventResult)
        {
            TriggerPhrase = triggerPhrase;
            Type = type;
            EventResult = eventResult;
        }
    }
    public class Result
    {
        public enum ResultType { NewExit, GetItem, GetMorty, MessageOnly }
        public ResultType Type { get; }
        public string ResultExit { get; }
        public Item ResultItem { get; }
        public IMorty ResultMorty { get; }
        public string ResultMessage { get; }

        public Result(string resultExit, string resultMessage)
        {
            Type = ResultType.NewExit;
            ResultExit = resultExit;
            ResultMessage = resultMessage;
        }
        public Result(Item resultItem, string resultMessage)
        {
            Type = ResultType.GetItem;
            ResultItem = resultItem;
            ResultMessage = resultMessage;
        }
        public Result(IMorty resultMorty, string resultMessage)
        {
            Type = ResultType.GetMorty;
            ResultMorty = resultMorty;
            ResultMessage = resultMessage;
        }
        public Result(string resultMessage)
        {
            Type = Result.ResultType.MessageOnly;
            ResultMessage = resultMessage;
        }
    }
}
