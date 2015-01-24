using System;

namespace Ftp.InputCommand
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple = false) ]
    public sealed class InputCommandHandlerAttribute : Attribute
    {
        readonly Func<InputCommands, bool> _inputCommandCallbackFunc;
        private readonly InputCommands _inputCommands;

        public InputCommandHandlerAttribute(Func<InputCommands, bool> inputCommandCallbackFunc, InputCommands inputCommands)
        {
            if (inputCommandCallbackFunc == null) throw new InputCommandNullAttributeException("Command callback can't be null");
            if (_inputCommands == null) throw new InputCommandNullAttributeException("Commands can't be null");

            _inputCommandCallbackFunc = inputCommandCallbackFunc;
            _inputCommands = inputCommands;
        }

        public bool PerformAction()
        {
            return _inputCommandCallbackFunc.Invoke(_inputCommands);
        }
    }
}
