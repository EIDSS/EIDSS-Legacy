using System;

namespace bv.model.Model.Core
{
    public class ValidationModelException : BvModelException
    {
        public string MessageId { get; private set; }
        public string FieldName { get; private set; }
        public string PropertyName { get; private set; }
        public object[] Pars { get; private set; }
        public Type ValidatorType { get; private set; }
        public bool ShouldAsk { get; private set; }
        public IObject Obj { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="fldName"></param>
        /// <param name="prpName"></param>
        /// <param name="pars"></param>
        /// <param name="validatorType"></param>
        private void Init(string msgId, string fldName, string prpName, object[] pars, Type validatorType, bool shouldAsk, IObject obj)
        {
            MessageId = msgId;
            FieldName = fldName;
            PropertyName = prpName;
            Pars = pars;
            ValidatorType = validatorType;
            ShouldAsk = shouldAsk;
            Obj = obj;
        }

        public ValidationModelException(string msgId, string fldName, string prpName, object[] pars, Type validatorType, bool shouldAsk, IObject obj)
        {
            Init(msgId, fldName, prpName, pars, validatorType, shouldAsk, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public ValidationModelException(ValidationEventArgs args)
        {
            Init(args.MessageId, args.FieldName, args.PropertyName, args.Pars, args.Type, args.ShouldAsk, args.Obj);
        }
    }
}
