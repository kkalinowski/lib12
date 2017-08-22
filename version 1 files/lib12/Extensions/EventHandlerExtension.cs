using System;

namespace lib12.Extensions
{
    public static class EventHandlerExtension
    {
        /// <summary>
        /// Raises the event
        /// </summary>
        /// <param name="handler">The event to rise</param>
        /// <param name="sender">The sender object</param>
        public static void Raise(this EventHandler handler, object sender)
        {
            handler.Raise(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event
        /// </summary>
        /// <param name="handler">The event to rise</param>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event args</param>
        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Raises the event
        /// </summary>
        /// <param name="handler">The event to rise</param>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event args</param>
        public static void Raise<T>(this EventHandler<T> handler, object sender, T e) where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
