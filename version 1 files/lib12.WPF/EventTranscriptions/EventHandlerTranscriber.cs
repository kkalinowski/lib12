using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace lib12.WPF.EventTranscriptions
{
    /// <summary>
    /// Transcribes one event handler into another, from http://stackoverflow.com/a/1814231/578560
    /// </summary>
    public static class EventHandlerTranscriber
    {
        #region Fields
        private static int methodIndex;
        #endregion

        #region Logic
        public static Delegate Transcribe(Type sourceEventHandlerType, Delegate destinationEventHandler)
        {
            if (destinationEventHandler == null)
                throw new ArgumentNullException("destinationEventHandler");
            if (destinationEventHandler.GetType() == sourceEventHandlerType)
                return destinationEventHandler; // already OK

            var sourceArgs = VerifyStandardEventHandler(sourceEventHandlerType);
            var destinationArgs = VerifyStandardEventHandler(destinationEventHandler.GetType());
            var name = "_wrap" + Interlocked.Increment(ref methodIndex);
            var paramTypes = new Type[sourceArgs.Length + 1];

            paramTypes[0] = destinationEventHandler.GetType();
            for (int i = 0; i < sourceArgs.Length; i++)
            {
                paramTypes[i + 1] = sourceArgs[i].ParameterType;
            }

            var dynamicMethod = new DynamicMethod(name, null, paramTypes);
            var invoker = paramTypes[0].GetMethod("Invoke");
            var ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_2);

            if (!destinationArgs[1].ParameterType.IsAssignableFrom(sourceArgs[1].ParameterType))
            {
                ilGenerator.Emit(OpCodes.Castclass, destinationArgs[1].ParameterType);
            }
            ilGenerator.Emit(OpCodes.Call, invoker);
            ilGenerator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(sourceEventHandlerType, destinationEventHandler);
        }

        private static ParameterInfo[] VerifyStandardEventHandler(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (!typeof(Delegate).IsAssignableFrom(type))
                throw new InvalidOperationException();

            var invokeMethod = type.GetMethod("Invoke");
            if (invokeMethod.ReturnType != typeof(void))
                throw new InvalidOperationException();

            var invokeArgs = invokeMethod.GetParameters();
            if (invokeArgs.Length != 2 || invokeArgs[0].ParameterType != typeof(object))
                throw new InvalidOperationException();

            if (!typeof(EventArgs).IsAssignableFrom(invokeArgs[1].ParameterType))
                throw new InvalidOperationException();

            return invokeArgs;
        }
        #endregion
    }
}